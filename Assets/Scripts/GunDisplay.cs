﻿using UnityEngine;
using System.Collections;

public class GunDisplay : MonoBehaviour {

	//public GUITexture weapon;
	public Texture2D HMG;
	public Texture2D Shotgun;
	public Texture2D Pistol;
	public string currentSelection;
	public Texture2D bullet;
	private int ammoCount;
	private bool selectionOpen = false;

	// Use this for initialization
	void Start () 
	{
		guiTexture.texture = Pistol; 
		currentSelection = "Pistol";
		ammoCount = 6;
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

	void OnMouseUp(){
		if ((guiTexture.name == "GunDisplay" || guiTexture.name == "HMG" || guiTexture.name == "Shotgun") && selectionOpen == false)
			selectionOpen = true;
		else if(selectionOpen == true)
			selectionOpen = false;
	}


	void OnGUI()
	{
		if (selectionOpen == true) {
			if (/*currentSelection != "HMG" &&*/ GUI.Button (new Rect (10, Screen.height*(float)0.62, Screen.width*(float)0.2, Screen.height*(float)0.2), HMG)) { // bottom
				guiTexture.texture = HMG;
				currentSelection = "HMG";
				ammoCount = 40;
				selectionOpen = false;
			}
			else if(/*currentSelection != "Shotgun" &&*/ GUI.Button (new Rect (10, Screen.height*(float)0.4, Screen.width*(float)0.2, Screen.height*(float)0.2), Shotgun)) { // middle
				guiTexture.texture = Shotgun;
				currentSelection = "Shotgun";
				ammoCount = 5;
				selectionOpen = false;
			}
			else if(/*currentSelection != "Pistol" &&*/ GUI.Button (new Rect (10, Screen.height*(float)0.18, Screen.width*(float)0.2, Screen.height*(float)0.2), Pistol)) { // top
				guiTexture.texture = Pistol;
				currentSelection = "Pistol";
				ammoCount = 6;
				selectionOpen = false;
			}
		} 
		else if (selectionOpen == false)
		{
			// display nothing
		}

		for(int i = 0; i < ammoCount; i++){
			GUI.DrawTexture(new Rect(Screen.width *(float)0.18 + (Screen.width*(float)0.019 * i), Screen.height *(float)0.88, Screen.width*(float)0.05, Screen.height*(float)0.08), bullet);
		}
	}

	string getCurrentSelection(){
		return currentSelection;
	}
}
