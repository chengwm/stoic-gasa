using UnityEngine;
using System.Collections;

public class GunDisplay : MonoBehaviour {

	//public GUITexture weapon;
	public Texture2D HMG;
	public Texture2D Shotgun;
	public Texture2D Pistol;
	public string currentSelection;
	public Texture2D bullet;
	public int ammoCountPistol;
	public int ammoCountHMG;
	public int ammoCountShotgun;
	public int ammoCountTotalHMG;
	public int ammoCountTotalShotgun;
	private bool selectionOpen = false;

	// Use this for initialization
	void Start () 
	{
		guiTexture.texture = Pistol; 
		currentSelection = "Pistol";
		ammoCountPistol = 6;
		ammoCountHMG = 40;
		ammoCountShotgun = 5;
		ammoCountTotalHMG = 80;
		ammoCountTotalShotgun = 10;
	}

	void OnMouseUp(){
		// if you press the Gun Display, the selection is closed, and the game is unpaused
		if ((guiTexture.name == "GunDisplay" || guiTexture.name == "HMG" || guiTexture.name == "Shotgun") && selectionOpen == false && Time.timeScale > 0)
		{ 
			selectionOpen = true;
		}
		else if(selectionOpen == true && Time.timeScale > 0)
			selectionOpen = false;
	}

	// OnGUI is called every frame
	void OnGUI()
	{ 
		if (selectionOpen == true) {
			if (/*currentSelection != "HMG" &&*/ GUI.Button (new Rect (Screen.width*(float)0.78, Screen.height*(float)0.62, Screen.width*(float)0.2, Screen.height*(float)0.2), HMG)) { // bottom
				guiTexture.texture = HMG;
				currentSelection = "HMG";
				selectionOpen = false;
			}
			else if(/*currentSelection != "Shotgun" &&*/ GUI.Button (new Rect (Screen.width*(float)0.78, Screen.height*(float)0.4, Screen.width*(float)0.2, Screen.height*(float)0.2), Shotgun)) { // middle
				guiTexture.texture = Shotgun;
				currentSelection = "Shotgun";
				selectionOpen = false;
			}
			else if(/*currentSelection != "Pistol" &&*/ GUI.Button (new Rect (Screen.width*(float)0.78, Screen.height*(float)0.18, Screen.width*(float)0.2, Screen.height*(float)0.2), Pistol)) { // top
				guiTexture.texture = Pistol;
				currentSelection = "Pistol";
				selectionOpen = false;
			}
		} 
		else if (selectionOpen == false)
		{
			// display nothing
		}

		// Ammo display
		if(currentSelection == "Pistol"){
			for(int i = 0; i < ammoCountPistol; i++){
				// Draws the ammo (marbles) at the bottom of the screen
				GUI.DrawTexture(new Rect(Screen.width *(float)0.73 - (Screen.width*(float)0.019 * i), Screen.height *(float)0.88, Screen.width*(float)0.05, Screen.height*(float)0.08), bullet);
			}
		}
		else if(currentSelection == "Shotgun"){
			for(int i = 0; i < ammoCountShotgun; i++){
				// Draws the ammo (marbles) at the bottom of the screen
				GUI.DrawTexture(new Rect(Screen.width *(float)0.73 - (Screen.width*(float)0.019 * i), Screen.height *(float)0.88, Screen.width*(float)0.05, Screen.height*(float)0.08), bullet);
			}
		}
		else if(currentSelection == "HMG"){
			for(int i = 0; i < ammoCountHMG; i++){
				// Draws the ammo (marbles) at the bottom of the screen
				GUI.DrawTexture(new Rect(Screen.width *(float)0.73 - (Screen.width*(float)0.003 * i), Screen.height *(float)0.88, Screen.width*(float)0.05, Screen.height*(float)0.08), bullet);
			}
		}
	}
}

// Update is called once per frame
/*void Update () 
	{
		// press and hold
		if (guiTexture.HitTest(Input.GetTouch(0).position) && Input.GetTouch(0).phase != TouchPhase.Ended)
		{

		}
		// when you let go
		else if ((guiTexture.HitTest(Input.GetTouch(0).position) && Input.GetTouch(0).phase == TouchPhase.Ended))
		{
			//guiTexture.texture = button1;
			if(selectionOpen == false)
			{
				selectionOpen = true;
			}
			else if(selectionOpen == true)
			{
				selectionOpen = false;
			}
		}
	}*/
