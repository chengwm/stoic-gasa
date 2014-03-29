using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {
	public GameObject shield;
	private Vector3 shieldMoveVector = new Vector3(0,30,0); // shield move distance is here

	void Start(){
		PlayerPrefs.SetInt ( "shieldUp", 0);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) // Temporary way to use the shield
		{
			PlayerPrefs.SetInt ( "shieldUp", 1);
			shield.transform.Translate(shieldMoveVector * Time.deltaTime, Space.World);
		}
		else if(Input.GetKeyUp("space")){
			PlayerPrefs.SetInt ( "shieldUp", 0);
			shield.transform.Translate(-shieldMoveVector * Time.deltaTime, Space.World);
		}
	}
}
