using UnityEngine;
using System.Collections;

public class EventManager_MainHall : MonoBehaviour {
	// Note: Copy the Main Camera from the Menu GUI prefabs. The camera nested in the character does not work properly with this code.
	
	public float RotationSpeed = 5;
	public float movementSpeed = 20;

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
			Debug.Log("no 6 " + num);
			if (num == 15){
				Debug.Log ("here");
				num = TranslateTo( new Vector3(0f, 35.8f, 60f), num);	
			}else if (num == 16)
				num = LookAt( new Vector3(0f, 35.8f, 42f), num);
			else if (num == 17)
				num = TranslateTo( new Vector3(0f, 35.8f, 42f), num);
			else if (num == 18)
				num = TranslateTo( new Vector3(0f, 35.8f, 25.7f), num);
				
			// Load next level
			else if(num == 19){
				saveGame ();
				Application.LoadLevel("DiningHall");
			}
		}
		
		else if ((!(GameObject.Find ("Target5")))) {
			
			if (num == 12)
				num = TranslateTo( new Vector3(65.1f, 33.8f, 136.6f), num);	
			else if (num == 13)
				num = TranslateTo( new Vector3(65.1f, 33.8f, 55.9f), num);
			else if (num == 14)
				num = TranslateTo( new Vector3(49f, 35.8f, 64.9f), num);
			else if (num == 15)
				num = LookAt( new Vector3 (31.5f, 33f, 81f), num);
			
		}
		else if ((!(GameObject.Find ("Target4")))) {
			
			if (num == 8)
				num = TranslateTo( new Vector3(38.2f, 8f, 94.8f), num);	
			else if (num == 9)
				num = TranslateTo( new Vector3(38.2f, 31f, 134.7f), num);
			else if (num == 10)
				num = TranslateTo( new Vector3(33.1f, 33.8f, 160.6f), num);
			else if (num == 11)
				num = LookAt( new Vector3 (30f, 32f, 170f), num);
		}
		
		else if ((!(GameObject.Find ("Target3")))) {
			
			if (num == 6)
				num = TranslateTo( new Vector3(0f, 8f, 68f), num);
			else if (num == 7)
				num = LookAt( new Vector3 (33.8f, 25f, 140.5f), num);
			
		}
		
		else if ((!(GameObject.Find ("Target2")))) {
			
			if (num == 4)
				num = TranslateTo( new Vector3(-17.9f, 8f, 176.2f), num);
			else if (num == 5)
				num = LookAt( new Vector3 (-10f, 11f, 161f), num);
			//theCamera.transform.LookAt( new Vector3 (-10f, 152.6f, 0f));
		}
		
		else if ((!(GameObject.Find ("Target1")))) {
			
			if (num == 0)
				num = TranslateTo( new Vector3(-65.4f, 8f, 266.1f), num);	
			else if (num == 1)
				num = TranslateTo( new Vector3(-64f, 8f, 227.7f), num);
			else if (num == 2)
				num = TranslateTo( new Vector3(-51.6f, 8f, 224f), num);
			else if (num == 3)
				num = LookAt( new Vector3 (-46f, 12f, 202.5f), num);
			
		}
	}
	
	
	private int LookAt( Vector3 position , int num) {
		
		//find the vector pointing from our position to the target
		_direction = (position - transform.position).normalized;
		
		//create the rotation we need to be in to look at the target
		_lookRotation = Quaternion.LookRotation(_direction);
		
		//rotate us over time according to speed until we are in the required rotation
		transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
		theCharacter.transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
		
		if (transform.rotation == _lookRotation)
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
	
	private void saveGame(){
		//PlayerPrefs.SetInt ("playerHealth", (int)lifeScript.playerHealth);
		PlayerPrefs.SetInt ("currentScore", (int)scoreScript.currentScore);
		PlayerPrefs.SetInt ("HMGTotalAmmo", (int)gunScript.ammoCountTotalHMG);
		PlayerPrefs.SetInt ("ShotgunTotalAmmo", (int)gunScript.ammoCountTotalShotgun);
		PlayerPrefs.SetInt ("HMGAmmo", (int)gunScript.ammoCountHMG);
		PlayerPrefs.SetInt ("ShotgunAmmo", (int)gunScript.ammoCountShotgun);
		PlayerPrefs.SetInt("playedTakeDamage", (int)lifeScript.playedTakeDamage);
		//yield return new WaitForSeconds(1.0F);
		Debug.Log ("Game saved");
		//yield break;
	}
}
