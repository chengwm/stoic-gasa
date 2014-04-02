using UnityEngine;
using System.Collections;

public class LifeCounter : MonoBehaviour {

	public GUITexture life1;
	public GUITexture life2;
	public GUITexture life3;
	public int playerHealth = 0;
	public InGameScoreScript script;
	
	// Use this for initialization
	void Start () {
		// initialize to 3
		playerHealth = 3;
		PlayerPrefs.SetInt ("playerHealth", (int)playerHealth);
	}

	void Update () 
	{
		if (PlayerPrefs.HasKey ("playerHealth")) {
			playerHealth = PlayerPrefs.GetInt ("playerHealth");
		}
		// If player has 3 lives
		if(playerHealth >= 3)
		{
			life3.enabled = true;
			life2.enabled = true;
			life1.enabled = true;
		}
		// If player has 2 lives
		else if(playerHealth == 2)
		{
			life3.enabled = false;
			life2.enabled = true;
			life1.enabled = true;
		}
		// Else if player has 1 lives
		else if(playerHealth == 1)
		{
			life3.enabled = false;
			life2.enabled = false;
			life1.enabled = true;
		}
		// Else if player has 0 life
		else if(playerHealth < 1)
		{
			life3.enabled = false;
			life2.enabled = false;
			life1.enabled = false;
			// Load game over screen
			Application.LoadLevel("GameOver");

			// Update the highscore if it is higher
			if(script.highScore < script.currentScore){
				PlayerPrefs.SetInt ("highScore", (int)script.currentScore);
			}
		}
	}
}

	// Old script
	/*void OnMouseDown () 
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
	}*/
	

