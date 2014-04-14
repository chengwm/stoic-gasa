using UnityEngine;
using System.Collections;

public class TimerScript: MonoBehaviour {

	// Update these depending on which style is used
	public float minutes;
	public float seconds;
	public float miliseconds;
	
	void Start(){
		if(Application.loadedLevelName == "MainHall"){
			minutes = 0;
			seconds = 500;
			miliseconds = 0;
		}
		else{
			seconds = PlayerPrefs.GetInt("timeLeft");
		}
	}
	
	void Update(){
		/*// ----------------------
		// Seconds : Milliseconds style
		if(miliseconds <= 0){
			if(seconds >= 0){
				seconds--;
			}
			
			miliseconds = 100;
		}
		
		miliseconds -= Time.deltaTime * 100;
		
		guiText.text = string.Format("{0} : {1}", seconds, (int)miliseconds);
		//-------------------------- 
		*/

		/* ------------------------
		// Minutes : Seconds : Milliseconds Style
		if(miliseconds <= 0){
			if(seconds <= 0){
				minutes--;
				seconds = 59;
			}
			else if(seconds >= 0){
				seconds--;
			}
			
			miliseconds = 100;
		}
		
		miliseconds -= Time.deltaTime * 100;
		
		//Debug.Log(string.Format("{0}:{1}:{2}", minutes, seconds, (int)miliseconds));
		guiText.text = string.Format("{0}:{1}:{2}", minutes, seconds, (int)miliseconds);
		------------------------- */

		// Seconds only style
		
		seconds -= Time.deltaTime; // I need timer which from a particular time goes to zero
		
		if (seconds > 0)
		{
			guiText.text = seconds.ToString("F0");
		}
		else{
			Application.LoadLevel ("GameOver");
		}


		/* // Do something when time runs out
		else // timer is <= 0
		{
			guiText.text = "TIME OVER\nPress X to restart"; // when it goes to the end-0,game ends (shows text: time over...)
			
		if (Input.GetKeyDown("x")) // And then i can restart game: pressing restart.
		{
			Application.LoadLevel(Application.loadedLevel); // reload the same level
		}*/

	}
}