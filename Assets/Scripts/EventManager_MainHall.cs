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
	public TimerScript timeScript;

	// Need to spawn minions using spawnerScript
	public GameObject spawner;
	public Spawner spawnerScript;

	//for checks 
	private int wave;

	void Start(){
		theCamera = Camera.main.gameObject;
		theCharacter = GameObject.FindWithTag("MainCharacter");
		audio.clip = footsteps;
		//num = 0;
		num = 4;
		theCharacter.transform.rotation = theCamera.transform.rotation;

		spawner = GameObject.Find("Spawner");
		spawnerScript = spawner.GetComponent<Spawner>();
		//wave = 0;	
		wave = 6;
	}

	// Update is called once per frame
	void Update () {
		// character hitbox follows the camera around
		theCharacter.transform.position = theCamera.transform.position;

		if(wave == 0)
		{
			//print("wave " +wave);
			print (spawnerScript.spawnpoint[0].name);
			spawnerScript.MakeABear(spawnerScript.spawnpoint[0], 1, 2, 4, 2);
			spawnerScript.MakeABear(spawnerScript.spawnpoint[1], 2, 1, 4, 1);
			spawnerScript.MakeABear(spawnerScript.spawnpoint[5], 3, 5, 3, 2);
			spawnerScript.MakeABear(spawnerScript.spawnpoint[6], 4, 3, 3, 0);
			spawnerScript.MakeABear(spawnerScript.spawnpoint[10], 5, 7, 2, 0);
			wave = 1;
		}
		else if(wave == 1)
		{
			if(!(GameObject.Find("bear1") || GameObject.Find("bear2") || GameObject.Find("bear3") || GameObject.Find("bear4") || GameObject.Find("bear5")))
			{
				spawnerScript.MakeABear(spawnerScript.spawnpoint[0], 6, 2, 4, 2);
				spawnerScript.MakeABear(spawnerScript.spawnpoint[9], 7, 3, 3, 0);
				spawnerScript.MakeABear(spawnerScript.spawnpoint[5], 8, 5, 3, 2);
				spawnerScript.MakeABear(spawnerScript.spawnpoint[1], 9, 0, 3, 2);
				spawnerScript.MakeABear(spawnerScript.spawnpoint[6], 10, 6, 3, 0);
				wave = 2;
			}
		}
		else if(wave == 2) 
		{
			if(!(GameObject.Find("bear6") || GameObject.Find("bear7") || GameObject.Find("bear8") || GameObject.Find("bear9") || GameObject.Find("bear10")))
			{
				spawnerScript.MakeABear(spawnerScript.spawnpoint[1], 11, 1, 4, 1);
				spawnerScript.MakeABear(spawnerScript.spawnpoint[0], 12, 2, 4, 2);
				wave = 3;
			}
		}
		else if(wave == 3)
		{
			if(!(GameObject.Find("bear11") || GameObject.Find("bear12")))
			{
				if (num == 0)
					num = TranslateTo( new Vector3(-65.4f, 8f, 266.1f), num);	
				else if (num == 1)
					num = TranslateTo( new Vector3(-64f, 8f, 227.7f), num);
				else if (num == 2)
					num = TranslateTo( new Vector3(-51.6f, 8f, 224f), num);
				else if (num == 3)
				{
					num = LookAt( new Vector3 (-46f, 12f, 202.5f), num);
					if(num == 4)
					{
						spawnerScript.MakeABear(spawnerScript.spawnpoint[10], 14, 7, 2, 0);
						//spawnerScript.MakeABear(spawnerScript.spawnpoint[12], 13, 36, 4, 0);
						spawnerScript.MakeABear(spawnerScript.spawnpoint[4], 15, 8, 5, 2);
						spawnerScript.MakeABear(spawnerScript.spawnpoint[5], 16, 9, 3, 1); //changed to shift right for cover
						wave = 4;
					}
				}
			}
		}
		else if(wave == 4)
		{
			if(!(//GameObject.Find("bear13") || 
			     GameObject.Find("bear14") || GameObject.Find("bear15") || GameObject.Find("bear16")))
			{
				spawnerScript.MakeABear(spawnerScript.spawnpoint[6], 17, 6, 3, 0);
				spawnerScript.MakeABear(spawnerScript.spawnpoint[12], 18, 36, 4, 0);
				//spawnerScript.MakeABear(spawnerScript.spawnpoint[10], 19, 4, 3, 0);
				//spawnerScript.MakeABear(spawnerScript.spawnpoint[9], 20, 35, 3, 0); 
				wave = 5;
			}
		}
		else if(wave == 5)
		{
			if(!(GameObject.Find("bear17") || GameObject.Find("bear18") 
			     //|| GameObject.Find("bear19") || GameObject.Find("bear20")
			     ))
			{
				spawnerScript.MakeALollipop(spawnerScript.spawnpoint[11], 1, 11, 3);
				spawnerScript.MakeABear(spawnerScript.spawnpoint[4], 21, 8, 5, 2);
				spawnerScript.MakeABear(spawnerScript.spawnpoint[6], 22, 6, 3, 0);
				wave = 6;
			}
		}
		else if(wave == 6)
		{
			if(!(GameObject.Find("bear21") || GameObject.Find("bear22") || GameObject.Find("lollipop1")))
			{
				if (num == 4)
					num = TranslateTo( new Vector3(-17.9f, 8f, 176.2f), num);
				else if (num == 5)
				{
					num = LookAt( new Vector3 (-10f, 11f, 161f), num);
					if(num == 6)
					{
						spawnerScript.MakeABear(spawnerScript.spawnpoint[3], 23, 12, 3, 1);
						spawnerScript.MakeABear(spawnerScript.spawnpoint[6], 24, 6, 3, 0);
						spawnerScript.MakeABear(spawnerScript.spawnpoint[9], 25, 14, 2, 0);
						spawnerScript.MakeABear(spawnerScript.spawnpoint[11], 26, 15, 2, 0);
						spawnerScript.MakeABear(spawnerScript.spawnpoint[10], 27, 16, 2, 0);
						wave = 7;
					}
				}
			}
		}
		else if(wave == 7)
		{
			if(!(GameObject.Find("bear23") || GameObject.Find("bear24") || GameObject.Find("bear25") || GameObject.Find("bear26") || GameObject.Find("bear27")))
			{
				spawnerScript.MakeABear(spawnerScript.spawnpoint[3], 28, 12, 3, 1);
				spawnerScript.MakeAnEgg(spawnerScript.spawnpoint[5], 1, 17, 2);
				spawnerScript.MakeABear(spawnerScript.spawnpoint[6], 29, 6, 3, 0);
				spawnerScript.MakeABear(spawnerScript.spawnpoint[9], 30, 14, 2, 0);
				wave = 8;
			}
		}
		else if(wave == 8)
		{
			if(!(GameObject.Find("bear28") || GameObject.Find("egg1") || GameObject.Find("bear29") || GameObject.Find("bear30")))
			{
				spawnerScript.MakeABear(spawnerScript.spawnpoint[10], 30, 16, 2, 0);
				spawnerScript.MakeABear(spawnerScript.spawnpoint[11], 31, 15, 2, 0);
				spawnerScript.MakeABear(spawnerScript.spawnpoint[6], 32, 6, 3, 0);
				spawnerScript.MakeAnEgg(spawnerScript.spawnpoint[5], 2, 17, 2);
				wave = 9;
			}
		}
		else if(wave == 9)
		{
			if(!(GameObject.Find("bear30") || GameObject.Find("egg2") || GameObject.Find("bear31") || GameObject.Find("bear32")))
			{
				if (num == 6)
					num = TranslateTo( new Vector3(0f, 8f, 68f), num);
				else if (num == 7)
				{
					num = LookAt( new Vector3 (33.8f, 25f, 140.5f), num);
					if(num == 8)
					{
						spawnerScript.MakeABear(spawnerScript.spawnpoint[7], 33, 18, 2, 1);
						//spawnerScript.MakeABear(spawnerScript.spawnpoint[12], 35, 20, 2, 0);
						//spawnerScript.MakeABear(spawnerScript.spawnpoint[9], 34, 20, 2, 0);
						spawnerScript.MakeALollipop(spawnerScript.spawnpoint[0], 2, 21, 4);
						spawnerScript.MakeABear(spawnerScript.spawnpoint[2], 36, 22, 2, 0);
						spawnerScript.MakeABear(spawnerScript.spawnpoint[8], 37, 23, 2, 0);
						wave = 10;
					}
				}
			}
		}
		else if(wave == 10)
		{
			if(!(GameObject.Find("bear33") //|| GameObject.Find("bear34") || GameObject.Find("bear35") 
			     || GameObject.Find("lollipop2") || GameObject.Find("bear36") || GameObject.Find("bear37")))
			{
				spawnerScript.MakeABear(spawnerScript.spawnpoint[9], 38, 13, 3, 0);
				spawnerScript.MakeALollipop(spawnerScript.spawnpoint[0], 3, 21, 4);
				//spawnerScript.MakeABear(spawnerScript.spawnpoint[9], 39, 24, 2, 0);
				spawnerScript.MakeABear(spawnerScript.spawnpoint[7], 40, 18, 2, 1);
				wave = 11;
			}
		}
		else if(wave == 11)
		{
			if(!(GameObject.Find("bear38") || GameObject.Find("lollipop3")
			     //|| GameObject.Find("bear39") 
			     || GameObject.Find("bear40")))
			{
				if (num == 8)
					num = TranslateTo( new Vector3(38.2f, 8f, 94.8f), num);	
				else if (num == 9)
					num = TranslateTo( new Vector3(38.2f, 31f, 134.7f), num);
				else if (num == 10)
					num = TranslateTo( new Vector3(33.1f, 33.8f, 160.6f), num);
				else if (num == 11)
				{
					num = LookAt( new Vector3 (30f, 32f, 170f), num);
					if(num == 12)
					{
						spawnerScript.MakeABear(spawnerScript.spawnpoint[8], 41, 25, 2, 0);
						//spawnerScript.MakeABear(spawnerScript.spawnpoint[7], 42, 26, 3, 1);
						spawnerScript.MakeALollipop(spawnerScript.spawnpoint[1], 4, 27, 4);
						spawnerScript.MakeABear(spawnerScript.spawnpoint[0], 43, 28, 3, 0);
						spawnerScript.MakeABear(spawnerScript.spawnpoint[1], 44, 29, 2, 0);
						wave = 12;
					}
				}
			}
		}
		else if(wave == 12)
		{
			if(!(GameObject.Find("bear41") 
			     //|| GameObject.Find("bear42") 
			     || GameObject.Find("lollipop4") 
			     || GameObject.Find("bear43") || GameObject.Find("bear44")))
			{
				//spawnerScript.MakeABear(spawnerScript.spawnpoint[7], 45, 26, 3, 0);
				spawnerScript.MakeABear(spawnerScript.spawnpoint[1], 46, 29, 2, 0);
				spawnerScript.MakeALollipop(spawnerScript.spawnpoint[0], 5, 30, 4);
				spawnerScript.MakeABear(spawnerScript.spawnpoint[0], 47, 28, 3, 0);
				spawnerScript.MakeABear(spawnerScript.spawnpoint[8], 48, 25, 2, 0);
				wave = 13;
			}
		}
		else if(wave == 13)
		{
			if(!(//GameObject.Find("bear45") || 
			     GameObject.Find("bear46") || GameObject.Find("lollipop5") 
			     || GameObject.Find("bear47") || GameObject.Find("bear48")))
			{
				
				if (num == 12)
					num = TranslateTo( new Vector3(65.1f, 33.8f, 136.6f), num);	
				else if (num == 13)
					num = TranslateTo( new Vector3(65.1f, 33.8f, 55.9f), num);
				else if (num == 14)
					num = TranslateTo( new Vector3(49f, 35.8f, 64.9f), num);
				else if (num == 15)
				{
					num = LookAt( new Vector3 (31.5f, 33f, 81f), num);
					if(num == 15)
					{
						spawnerScript.MakeABear(spawnerScript.spawnpoint[6], 49, 6, 3, 2);
						spawnerScript.MakeABear(spawnerScript.spawnpoint[8], 50, 23, 2, 1);
						//spawnerScript.MakeABear(spawnerScript.spawnpoint[7], 51, 31, 3, 0);
						spawnerScript.MakeALollipop(spawnerScript.spawnpoint[1], 6, 27, 4);
						spawnerScript.MakeABear(spawnerScript.spawnpoint[10], 52, 32, 2, 0);
						spawnerScript.MakeABear(spawnerScript.spawnpoint[3], 53, 33, 2, 0);
						spawnerScript.MakeABear(spawnerScript.spawnpoint[12], 54, 34, 2, 0);
						wave = 14;
					}
				}
			}
		}
		else if(wave == 14)
		{
			if(!(GameObject.Find("bear49") || GameObject.Find("bear50") 
			     //|| GameObject.Find("bear51") 
			     || GameObject.Find("lollipop6") 
			     || GameObject.Find("bear52") || GameObject.Find("bear53") 
			     || GameObject.Find("bear54")))
			{
				spawnerScript.MakeABear(spawnerScript.spawnpoint[10], 55, 4, 3, 0);
				spawnerScript.MakeALollipop(spawnerScript.spawnpoint[1], 7, 27, 4);
				spawnerScript.MakeABear(spawnerScript.spawnpoint[3], 56, 33, 2, 1);
				spawnerScript.MakeABear(spawnerScript.spawnpoint[10], 57, 32, 2, 0);
				spawnerScript.MakeABear(spawnerScript.spawnpoint[6], 58, 6, 3, 0);
				spawnerScript.MakeABear(spawnerScript.spawnpoint[12], 59, 34, 2, 0);
				//spawnerScript.MakeABear(spawnerScript.spawnpoint[7], 60, 31, 3, 0);
				wave = 15;
			}
		}
		else if(wave == 15)
		{
			if(!(GameObject.Find("bear55") || GameObject.Find("lollipop7") 
			     || GameObject.Find("bear56") || GameObject.Find("bear57") 
			     || GameObject.Find("bear58") || GameObject.Find("bear59") 
			     //|| GameObject.Find("bear60")
			     ))
			{
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
		}
			
	}

	
	
	private int LookAt( Vector3 position , int num) {
		
		//find the vector pointing from our position to the target
		_direction = (position - transform.position).normalized;
		
		//create the rotation we need to be in to look at the target
		_lookRotation = Quaternion.LookRotation(_direction);
		
		//rotate us over time according to speed until we are in the required rotation
		transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
		transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
		
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
