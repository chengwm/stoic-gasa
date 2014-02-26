using UnityEngine;
using System.Collections;

public class LifeCounter : MonoBehaviour {

	public GUITexture life1;
	public GUITexture life2;
	public GUITexture life3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnMouseDown () 
	{
		//if (Input.GetKeyDown ("space")) // if(player took damage) 
		//{ 
			// If player has 3 lives
			if (life3.enabled == true)
			{
				if (life3.enabled == true)
				{
					life3.enabled = false;
				}
				else // possible functionality to gain back life
				{ 
					life3.enabled = true;
				}
			}
			// Else if player has 2 lives
			else if (life2.enabled == true && life3.enabled == false)
			{
				if (life2.enabled == true){
					life2.enabled = false;
				}
				else // possible functionality to gain back life
				{ 
					life2.enabled = true;
				}
			}
			// Else if player has 1 life
			else if (life1.enabled == true && life2.enabled == false)
			{
				if (life1.enabled == true)
				{
					life1.enabled = false;
					// GAME OVER
				}
			}
		//}
	}
}
