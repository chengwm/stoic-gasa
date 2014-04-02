using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {
	public GameObject shield;
	private bool shieldIsUp = false;
	private Vector3 shieldMoveVector = new Vector3(0,0.5F,0); // shield move distance is here

	void Start(){
		PlayerPrefs.SetInt ( "shieldUp", 0);
	}

	// Update is called once per frame
	void Update () {
		//if (Input.GetKeyDown(KeyCode.Space)) // Temporary way to use the shield
		//{
		if(Input.GetMouseButton(0))
		{
			if(shieldIsUp == false){
				shieldIsUp = true;
				PlayerPrefs.SetInt ( "shieldUp", 1);
				shield.transform.Translate(shieldMoveVector, Camera.main.transform);
			}
		}
		else if(Input.GetMouseButtonUp(0)){
			if(shieldIsUp == true){
				shieldIsUp = false;
				PlayerPrefs.SetInt ( "shieldUp", 0);
				shield.transform.Translate(-shieldMoveVector, Camera.main.transform);
			}
		}
	}
	/*
	void OnMouseDown () {
			PlayerPrefs.SetInt ( "shieldUp", 1);
		shield.transform.Translate(shieldMoveVector, Space.World);

	}
	void OnMouseUp() {
			PlayerPrefs.SetInt ("shieldUp", 0);
			shield.transform.Translate (-shieldMoveVector, Space.World);
	}*/
}
