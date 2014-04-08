using UnityEngine;
using System.Collections;

public class screen : MonoBehaviour {

	public playIngressGlyph gameManagerScript;

	// Use this for initialization
	void Start () {
		renderer.material.SetColor("_Color", Color.black);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
//		Debug.Log("Mouse Down.");
		if(gameManagerScript.isMainGameInitialised && !gameManagerScript.getGameIsEnding())
			gameManagerScript.beginAttempt();
	}

}
