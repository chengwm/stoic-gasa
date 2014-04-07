using UnityEngine;
using System.Collections;

public class LifeCounter : MonoBehaviour {

	public GUITexture life1;
	public GUITexture life2;
	public GUITexture life3;
	public int playerHealth = 0;
	public InGameScoreScript script;
	
	// Sound variables
	public AudioClip heartBeat;
	private bool playedHeartBeat = false; // to ensure the clip does not play on each frame
	public AudioClip takeDamage;
	private int playedTakeDamage = 0; // to ensure the clip does not play on each frame
	public AudioClip die;
	private bool playedDie = false; // to ensure the clip does not play on each frame
	
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
			if(playedTakeDamage == 0){
				StartCoroutine(PlayOuch());
				playedTakeDamage = 1;
			}
		}
		// Else if player has 1 lives
		else if(playerHealth == 1)
		{
			life3.enabled = false;
			life2.enabled = false;
			life1.enabled = true;
			if(playedTakeDamage == 1){
				StartCoroutine(PlayOuch());
				playedTakeDamage = 2;
			}
			if(playedHeartBeat == false){
				audio.PlayOneShot(heartBeat);
				playedHeartBeat = true;
			}
		}
		// Else if player has 0 life
		else if(playerHealth < 1)
		{
			life3.enabled = false;
			life2.enabled = false;
			life1.enabled = false;
			if(playedDie == false){
				StartCoroutine(PlayDie ());
				playedDie = true;
			}

			// Update the highscore if it is higher
			if(script.highScore < script.currentScore){
				PlayerPrefs.SetInt ("highScore", (int)script.currentScore);
			}
			PlayerPrefs.SetInt ("currentScore", (int)script.currentScore);
		}
	}
	
	IEnumerator PlayDie(){
		audio.PlayOneShot(die);
		yield return new WaitForSeconds(1.0F);
		Application.LoadLevel ("GameOver");
		yield break;
	}
	
	IEnumerator PlayOuch(){
		yield return new WaitForSeconds(0.5F);
		audio.PlayOneShot(takeDamage);
		yield return new WaitForSeconds(0.5F);
		yield break;
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
	

