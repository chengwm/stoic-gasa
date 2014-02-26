using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	float score = 0;
	
	// Update is called once per frame
	void Update () {
		score += Time.deltaTime; // I need timer which from a particular time goes to zero
		guiText.text = "Score: " + score.ToString("F0");
	}
}
