using UnityEngine;
using System.Collections;

public class EventManager_BossRoom : MonoBehaviour {
	// Note: Copy the Main Camera from the Menu GUI prefabs. The camera nested in the character does not work properly with this code.
	
	public float RotationSpeed = 10;
	public float movementSpeed = 40;

	//values for internal use
	private Quaternion _lookRotation;
	private Vector3 _direction;
	private GameObject theCamera;
	private int num;
	public GameObject theCharacter;
	
	// Audio
	public AudioClip footsteps;
	
	// Disable these scripts while moving
	public Shooting shootScript;
	public Shield shieldScript;
	
	// Need to access these scripts to save info
	public InGameScoreScript scoreScript;

	void Start(){
		theCamera = Camera.main.gameObject;
		theCharacter = GameObject.FindWithTag("MainCharacter");
		audio.clip = footsteps;
		num = 0;
		theCharacter.transform.rotation = theCamera.transform.rotation;
	}

	// Update is called once per frame
	void Update () {
		// character hitbox follows the camera around
		theCharacter.transform.position = theCamera.transform.position;

		if ((!(GameObject.Find ("Target4")))) {
			//cutscene before minigame
			if (num == 14)
				num = TranslateTo( new Vector3(-27f, 6f, 7f), num);
			else if (num == 15)
				num = TranslateTo( new Vector3 (-5.5f, 6f, -8f), num);
			else if (num == 16)
				num = LookAt( new Vector3(-2f, 6f, -20.7f), num);
			else if (num == 17)
				StartCoroutine(endLook( new Vector3(-5.5f, 12f, -21f)));
			else if (num == 18)
				num = TranslateTo( new Vector3(0f, 6f, -8f), 5f, num);
			else if (num == 19)
				num = TranslateTo( new Vector3 (0f, 4f, -16f), 5f, num);
			else if (num == 20){
				saveScore ();
				Application.LoadLevel ("MiniGameOne-Ingress");
			}
		}
		
		else if ((!(GameObject.Find ("Target3")))) {
			
			if (num == 10)
				num = TranslateTo( new Vector3(-40f, 30f, 81f), num);
			else if (num == 11)
				num = TranslateTo( new Vector3 (-40f, 6f, 34f), num);
			else if (num == 12)
				num = TranslateTo( new Vector3 (-39f, 6f, -5f), num);
			else if (num == 13)
				num = LookAt( new Vector3 (-20f, 14.5f, 43.4f), num);
			
		}
		
		else if ((!(GameObject.Find ("Target2")))) {

			if (num == 6)
				num = TranslateTo( new Vector3(-8.5f, 38f, 99f), num);
			else if (num == 7)
				num = TranslateTo( new Vector3(-54.5f, 38f, 90f), num);
			else if (num == 8)
				num = TranslateTo( new Vector3(-54.5f, 35f, 86f), num);
			else if (num == 9)
				num = LookAt( new Vector3 (0f, 49.5f, 105.8f), num);
			//theCamera.transform.LookAt( new Vector3 (-10f, 152.6f, 0f));
		}
		
		else if ((!(GameObject.Find ("Target1")))) {
			
			if (num == 3)
				num = TranslateTo( new Vector3(18f, 38f, 100f), num);	
			else if (num == 4)
				num = TranslateTo( new Vector3(-8.5f, 38f, 88.2f), num);
			else if (num == 5)
				num = LookAt( new Vector3(-8.5f, 40f, 98.2f), num);
			
		}

		else { //Starting cutscene

			if (num == 0) 
				num = TranslateTo( new Vector3(40f, 38f, 100f), 20f, num);	
			else if (num == 1)
				num = LookAt( new Vector3(11f, 16f, 12f), num);
			else if (num == 2)
				StartCoroutine(longLook( new Vector3(10f, 38f, 105f)));
			//else if (num == 3)
			//	num = LookAt( new Vector3 (-46f, 12f, 202.5f), num);

		}
	}
	
	
	private int LookAt( Vector3 position , int num) {
		
		//find the vector pointing from our position to the target
		_direction = (position - transform.position);//.normalized;
		
		//create the rotation we need to be in to look at the target
		_lookRotation = Quaternion.LookRotation(_direction);
		
		//rotate us over time according to speed until we are in the required rotation
		transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
		theCharacter.transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);

		Debug.Log ("intended = " + _lookRotation + ", actual = " + transform.rotation);


		if (Mathf.Abs(Mathf.Abs (transform.rotation.y) - Mathf.Abs (_lookRotation.y)) < 0.000001f)
			num += 1;
		
		return num;
	}
	
	private int TranslateTo( Vector3 position , int num) {
		
		// Calculate the distance between the follower and the leader.
		float range1 = Vector3.Distance(theCamera.transform.position, position );
		//Debug.Log ("Range = " + range1);
		
		if (range1 > 1.0) {
			// prevent shooting and using the shield while moving
			shootScript.enabled = false;
			shieldScript.enabled = false;
			
			//find the vector pointing from our position to the target
			_direction = (position - transform.position).normalized;
			
			//create the rotation we need to be in to look at the target
			_lookRotation = Quaternion.LookRotation (_direction);
			
			//rotate us over time according to speed until we are in the required rotation
			transform.rotation = Quaternion.Slerp (transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
			theCharacter.transform.rotation = Quaternion.Slerp (transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
			
			// calculate direction and move towards the target
			Vector3 dir = position - theCamera.transform.position;
			dir = dir.normalized;
			
			if(!audio.isPlaying){
				audio.Play ();
			}
			
			//theCharacter.transform.Translate(dir * movementSpeed * Time.deltaTime, Space.World);
			theCamera.transform.Translate (dir * movementSpeed * Time.deltaTime, Space.World);
			theCharacter.transform.rotation = Quaternion.Slerp (transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
			
		} else if (range1 <= 1.0) {
			// Reached position, enable shielding and shooting
			shootScript.enabled = true;
			shieldScript.enabled = true;
		
			audio.Stop ();
			num += 1;
			Debug.Log (num);
			
		}
		return num;
	}

	private int TranslateTo( Vector3 position , float spd, int num) {
		
		// Calculate the distance between the follower and the leader.
		float range1 = Vector3.Distance(theCamera.transform.position, position );
		//Debug.Log ("Range = " + range1);
		
		if (range1 > 1.0) {
			// prevent shooting and using the shield while moving
			shootScript.enabled = false;
			shieldScript.enabled = false;
			
			//find the vector pointing from our position to the target
			_direction = (position - transform.position).normalized;
			
			//create the rotation we need to be in to look at the target
			_lookRotation = Quaternion.LookRotation (_direction);
			
			//rotate us over time according to speed until we are in the required rotation
			transform.rotation = Quaternion.Slerp (transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
			theCharacter.transform.rotation = Quaternion.Slerp (transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
			
			// calculate direction and move towards the target
			Vector3 dir = position - theCamera.transform.position;
			dir = dir.normalized;
			
			if(!audio.isPlaying){
				audio.Play ();
			}
			
			//theCharacter.transform.Translate(dir * movementSpeed * Time.deltaTime, Space.World);
			theCamera.transform.Translate (dir * spd * Time.deltaTime, Space.World);
			theCharacter.transform.rotation = Quaternion.Slerp (transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
			
		} else if (range1 <= 1.0) {
			// Reached position, enable shielding and shooting
			shootScript.enabled = true;
			shieldScript.enabled = true;
			
			audio.Stop ();
			num += 1;
			Debug.Log (num);
			
		}
		return num;
	}

	IEnumerator longLook( Vector3 vec ) {

		yield return new WaitForSeconds(1.5f);

		_direction = (vec - transform.position);
		_lookRotation = Quaternion.LookRotation(_direction);
		
		transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
		theCharacter.transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
		
		if (Mathf.Abs (Mathf.Abs (transform.rotation.y) - Mathf.Abs (_lookRotation.y)) < 0.000001f) 
			num = 3;

	}

	IEnumerator endLook( Vector3 vec ) {
		
		yield return new WaitForSeconds(0.5f);
		
		_direction = (vec - transform.position);
		_lookRotation = Quaternion.LookRotation(_direction);
		
		transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
		theCharacter.transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
		
		if (Mathf.Abs (Mathf.Abs (transform.rotation.y) - Mathf.Abs (_lookRotation.y)) < 0.000001f) 
			num = 18;
		
	}
	
	private void saveScore(){
		PlayerPrefs.SetInt ("currentScore", (int)scoreScript.currentScore);
		Debug.Log ("Score saved");
	}
}
