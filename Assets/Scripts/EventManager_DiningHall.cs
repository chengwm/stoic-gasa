using UnityEngine;
using System.Collections;

public class EventManager_DiningHall : MonoBehaviour {
	// Note: Copy the Main Camera from the Menu GUI prefabs. The camera nested in the character does not work properly with this code.
	
	public float RotationSpeed = 15;
	public float movementSpeed = 25;

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

	// Need to spawn minions using spawnerScript
	public GameObject spawner;
	public Spawner spawnerScript;

	private int wave;
	
	void Start(){
		theCamera = Camera.main.gameObject;
		theCharacter = GameObject.FindWithTag("MainCharacter");
		audio.clip = footsteps;
		num = 0;
		theCharacter.transform.rotation = theCamera.transform.rotation;

		spawner = GameObject.Find("Spawner");
		spawnerScript = spawner.GetComponent<Spawner>();
		wave = 0;
	}

	// Update is called once per frame
	void Update () {
		// character hitbox follows the camera around
		theCharacter.transform.position = theCamera.transform.position;

		if ((!(GameObject.Find ("Target6")))) {

			if (num == 13)
				num = TranslateTo( new Vector3(4f, 3.5f, 36.4f), num);	
			else if (num == 14)
				num = TranslateTo( new Vector3(-7f, 3.5f, 58f), num);
			else if (num == 15)
				num = TranslateTo( new Vector3(-10.5f, 3.5f, 86f), num);
			else if (num == 16){
				saveGame ();
				Application.LoadLevel ("BossRoom");
			}
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
			

							
		}

		if(wave == 0)
		{
			spawnerScript.MakeABear(spawnerScript.spawnpoint[0], 1, 2, 4, 2);
			//no bear 2
			spawnerScript.MakeABear(spawnerScript.spawnpoint[1], 3, 0, 3, 2);
			//no bear 4
			//no bear 5
			spawnerScript.MakeABear(spawnerScript.spawnpoint[6], 6, 7, 2, 1);
			spawnerScript.MakeABear(spawnerScript.spawnpoint[8], 7, 14, 2, 2);
			//no bear 8
			spawnerScript.MakeALollipop(spawnerScript.spawnpoint[12], 1, 37, 2);
			wave = 1;
		}
		else if(wave == 1)
		{
			if(!(GameObject.Find("bear1") || GameObject.Find("bear3") || GameObject.Find("bear6") || GameObject.Find("bear7") || GameObject.Find("lollipop1")))
			{
				spawnerScript.MakeABear(spawnerScript.spawnpoint[7], 9, 3, 3, 1);
				spawnerScript.MakeABear(spawnerScript.spawnpoint[6], 10, 7, 2, 1);
				spawnerScript.MakeABear(spawnerScript.spawnpoint[0], 11, 2, 4, 2);
				//no bear 12
				spawnerScript.MakeABear(spawnerScript.spawnpoint[8], 13, 14, 2, 2);
				//no bear 14
				spawnerScript.MakeALollipop(spawnerScript.spawnpoint[12], 2, 37, 2);
				spawnerScript.MakeABear(spawnerScript.spawnpoint[1], 15, 0, 3, 2);
				//no bear 16
				//no bear 17
				spawnerScript.MakeABear(spawnerScript.spawnpoint[3], 18, 4, 3, 0);
				wave = 2;
			}
		}
		else if(wave == 2)
		{
			if(!(GameObject.Find("bear9") || GameObject.Find("bear10") || GameObject.Find("bear11") || GameObject.Find("lollipop2") 
			     || GameObject.Find("bear13") || GameObject.Find("bear15") || GameObject.Find("bear18") ))
			{
				if (num == 0)
					num = TranslateTo( new Vector3(51.2f, 3.5f, -43.3f), num);	
				else if (num == 1)
				{
					num = LookAt( new Vector3(51.2f, 3.5f, -30f), num);
					if(num == 2)
					{
						//no bear 19
						spawnerScript.MakeABear(spawnerScript.spawnpoint[3], 20, 4, 3, 0);
						spawnerScript.MakeABear(spawnerScript.spawnpoint[4], 21, 16, 2, 1);
						spawnerScript.MakeABear(spawnerScript.spawnpoint[5], 22, 15, 2, 1);
						wave = 3;
					}
				}
			}
		}
		else if(wave == 3)
		{
			if(!(GameObject.Find("bear20") || GameObject.Find("bear21") || GameObject.Find("bear22")))
			{
				spawnerScript.MakeAnEgg(spawnerScript.spawnpoint[9], 1, 10, 3);
				wave = 4;
			}
		}
		else if(wave == 4)
		{
			if(!(GameObject.Find("egg1")))
			{
				wave = 5;
			}
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
		PlayerPrefs.SetInt("playerLoadedHealth", (int)lifeScript.playerHealth);
		Debug.Log ("Game saved");
	}
}
