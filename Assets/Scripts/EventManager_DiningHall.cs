using UnityEngine;
using System.Collections;

public class EventManager_DiningHall : MonoBehaviour {
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
	
	// Need to access these scripts to save info
	public InGameScoreScript scoreScript;
	public GunDisplay gunScript;
	public LifeCounter lifeScript;
	public TimerScript timeScript;
	
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

		if ((!(GameObject.Find ("Target6")))) {
			
		}
		
		else if ((!(GameObject.Find ("Target5")))) {
			
			if (num == 9)
				num = TranslateTo( new Vector3(38f, 3.5f, 32.4f), num);	
			else if (num == 10)
				num = TranslateTo( new Vector3(33f, 3.5f, 35.3f), num);
			else if (num == 11)
				num = TranslateTo( new Vector3(26f, 3.5f, 36.4f), num);
			else if (num == 12)
				num = LookAt( new Vector3 (22f, 3.5f, 26.4f), num);
			
		}
		else if ((!(GameObject.Find ("Target4")))) {
			
			if (num == 7)
				num = TranslateTo( new Vector3(34.4f, 3.5f, 23f), num);	
			else if (num == 8)
				num = LookAt( new Vector3 (33f, 3.5f, 25f), num);
		}
		
		else if ((!(GameObject.Find ("Target3")))) {
			
			if (num == 5)
				num = TranslateTo( new Vector3(34.4f, 3.5f, 1.6f), num);
			else if (num == 6)
				num = LookAt( new Vector3 (31f, 3.5f, 7f), num);
			
		}
		
		else if ((!(GameObject.Find ("Target2")))) {

			if (num == 2)
				num = TranslateTo( new Vector3(51.2f, 3.5f, -19f), num);
			else if (num == 3)
				num = TranslateTo( new Vector3(42.7f, 3.5f, -9f), num);
			else if (num == 4)
				num = LookAt( new Vector3 (34f, 3.5f, -6.5f), num);


		}
		
		else if ((!(GameObject.Find ("Target1")))) {
			
			if (num == 0)
				num = TranslateTo( new Vector3(51.2f, 3.5f, -43.3f), num);	
			else if (num == 1)
				num = LookAt( new Vector3(51.2f, 3.5f, -30f), num);
							
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

		if (Mathf.Abs(Mathf.Abs (transform.rotation.y) - Mathf.Abs (_lookRotation.y)) < 0.000001f) {
			num += 1;
		}

		return num;
	}

	private int TranslateTo( Vector3 position , int num) {
		
		// Calculate the distance between the follower and the leader.
		float range1 = Vector3.Distance(theCamera.transform.position, position );
		//Debug.Log ("Range = " + range1);
		
		if (range1 > 0.5) {
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
			
			if(!audio.isPlaying && Time.timeScale == 1){
				audio.Play ();
			}
			// Stop playing the footsteps if paused
			else if(audio.isPlaying && Time.timeScale == 0){
				audio.Stop();
			}
			
			//theCharacter.transform.Translate(dir * movementSpeed * Time.deltaTime, Space.World);
			theCamera.transform.Translate (dir * movementSpeed * Time.deltaTime, Space.World);
			theCharacter.transform.rotation = Quaternion.Slerp (transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
			
		} else if (range1 <= 0.5) {
			// Reached position, enable shielding and shooting
			shootScript.enabled = true;
			shieldScript.enabled = true;
			
			audio.Stop ();
			num += 1;

		}
		return num;
	}
	
	private void saveGame(){
		PlayerPrefs.SetInt ("currentScore", (int)scoreScript.currentScore);
		PlayerPrefs.SetInt ("HMGTotalAmmo", (int)gunScript.ammoCountTotalHMG);
		PlayerPrefs.SetInt ("ShotgunTotalAmmo", (int)gunScript.ammoCountTotalShotgun);
		PlayerPrefs.SetInt ("HMGAmmo", (int)gunScript.ammoCountHMG);
		PlayerPrefs.SetInt ("ShotgunAmmo", (int)gunScript.ammoCountShotgun);
		PlayerPrefs.SetInt("playedTakeDamage", (int)lifeScript.playedTakeDamage);
		PlayerPrefs.SetInt("timeLeft", (int)timeScript.seconds);
		Debug.Log ("Game saved");
	}
}
