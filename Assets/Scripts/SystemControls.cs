using UnityEngine;
using System.Collections;

// Used for backend stuff
// Functions in this script:
// 1. Back button
// 2. Prevent sleep
// 3. Game pauses when multitasking

// Script is found in:
// pause button
// main menu title
// settings title

public class SystemControls : MonoBehaviour {
	
	private bool paused;
	public GUITexture backAgainMessage;
	private int backPressCounter = 0;
	
	// Use this for initialization
	void Start () {
		// prevent the device from sleeping/dimming
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		backAgainMessage.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.platform == RuntimePlatform.Android)
		{
			if (Input.GetKeyDown("escape")/*Input.GetKey(KeyCode.Escape)*/) // when the back button is pressed on the device
			{
				// Currently in game
				if(Application.loadedLevelName == "MainHall" && Time.timeScale == 1)
				{
					// pause game
					Time.timeScale = 0;
				}
				// Game is paused
				else if(Time.timeScale == 0)
				{	
					// load the main menu
					Time.timeScale = 1;
					Application.LoadLevel("mainMenu");
				}
				else if(Application.loadedLevelName == "mainMenu")
				{
					if(backPressCounter == 0)
					{
						backPressCounter++;
						backAgainMessage.enabled = true;
					}
					else if(backPressCounter == 1)
					{
						Application.Quit();
					}
				}
				else if(Application.loadedLevelName == "settings")
				{
					Application.LoadLevel("mainMenu");
				}
			}
			
			 /*if(Input.GetKey (KeyCode.Menu)) // for the device menu button (leftmost button on the Note)
			 {
				Time.timeScale = 0;
			 }*/
		}
	}
	
	// Causes the app to pause when you press the home button, or if the app is interrupted with a phone call, etc.
	void OnApplicationPause(bool pauseStatus) {
		paused = pauseStatus;
		
		if(paused == true)
		{
			Time.timeScale = 0;
		}
	}
}
