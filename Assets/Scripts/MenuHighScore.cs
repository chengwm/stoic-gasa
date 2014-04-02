using UnityEngine;
using System.Collections;

// Handles saving of highscore, settings, etc.

public class MenuHighScore : MonoBehaviour {

	private int highScore = 0;
	public TextMesh textMesh;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("highScore")) {
			highScore = PlayerPrefs.GetInt ("highScore");
		}
		textMesh.text = "Highscore: " + highScore.ToString ();
	}
}
