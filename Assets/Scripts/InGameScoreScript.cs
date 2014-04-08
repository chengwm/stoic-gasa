using UnityEngine;
using System.Collections;

public class InGameScoreScript : MonoBehaviour {

	public int currentScore = 0;
	public int highScore;
	//public LifeCounter lifecounterScript;

	void Start(){
		if (PlayerPrefs.HasKey ("highScore")) {
			highScore = PlayerPrefs.GetInt ("highScore");
		}
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = "Score: " + currentScore.ToString("F0");
	}
}
