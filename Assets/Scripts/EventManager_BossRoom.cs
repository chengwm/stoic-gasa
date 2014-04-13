using UnityEngine;
using System.Collections;

public class EventManager_BossRoom : MonoBehaviour {
	// Note: Copy the Main Camera from the Menu GUI prefabs. The camera nested in the character does not work properly with this code.
	
	public float RotationSpeed = 15;
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

		if ((!(GameObject.Find ("Target5")))) {
			//cutscene after minigame, to end game

			
		}
		else if ((!(GameObject.Find ("Target4")))) {
			//cutscene before minigame

		}
		
		else if ((!(GameObject.Find ("Target3")))) {
			
			if (num == 7)
				num = TranslateTo( new Vector3(-40f, 30f, 81f), num);
			else if (num == 8)
				num = TranslateTo( new Vector3 (-40f, 6f, 34f), num);
			else if (num == 9)
				num = TranslateTo( new Vector3 (-39f, 6f, 6f), num);
			else if (num == 10)
				num = LookAt( new Vector3 (-20f, 15f, 43.4f), num);
			
		}
		
		else if ((!(GameObject.Find ("Target2")))) {

			if (num == 3)
				num = TranslateTo( new Vector3(-8.5f, 38f, 99f), num);
			else if (num == 4)
				num = TranslateTo( new Vector3(-54.5f, 38f, 90f), num);
			else if (num == 5)
				num = TranslateTo( new Vector3(-54.5f, 35f, 86f), num);
			else if (num == 6)
				num = LookAt( new Vector3 (0f, 49.5f, 105.8f), num);
			//theCamera.transform.LookAt( new Vector3 (-10f, 152.6f, 0f));
		}
		
		else if ((!(GameObject.Find ("Target1")))) {
			
			if (num == 0)
				num = TranslateTo( new Vector3(18f, 38f, 100f), num);	
			else if (num == 1)
				num = TranslateTo( new Vector3(-8.5f, 38f, 88.2f), num);
			else if (num == 2)
				num = LookAt( new Vector3(-8.5f, 40f, 98.2f), num);
			
		}

		else { //Starting cutscene

			if (num == 10) 
				num = TranslateTo( new Vector3(40f, 38f, 100f), 20f, num);	
			else if (num == 11)
				num = LookAt( new Vector3(11f, 16f, 12f), num);
			else if (num == 12)
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

		yield return new WaitForSeconds(2f);
		num = LookAt( vec , num);

	}

}
