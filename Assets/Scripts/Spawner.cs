using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

public class Spawner : MonoBehaviour
{
	public GameObject m_PrefabBear; 
	public GameObject m_PrefabLollipop; 
	public GameObject m_PrefabEgg; 

	public GameObject spawnpoint1, spawnpoint2;
	//public GameObject spawnpoint2 = GameObject.Find("spawnpoint2");

	private float bearSpawnTimer1, lollipopSpawnTimer1, eggSpawnTimer1;
	private int i; //counter for name of spawnpoint
	private int j; //counter for name of bear

	private	string bearString = "bear";
	private string lollipopString = "lollipop";
	private string eggString = "egg";

	// Use this for initialization
	void Start ()
	{
		spawnpoint1 = GameObject.Find("spawnpoint1");
//		spawnpoint2 = GameObject.Find("spawnpoint1");
		bearSpawnTimer1 = 1.0f;
		lollipopSpawnTimer1 = 3.5f;
		eggSpawnTimer1 = 10.0f;

		i = j = 0;
	}

	// Update is called once per frame
	void Update ()
	{
		bearSpawnTimer1 -= Time.deltaTime;
		lollipopSpawnTimer1 -= Time.deltaTime;
		eggSpawnTimer1 -= Time.deltaTime;
		//print ("bearSpawnTimer1 outside if statement= " + bearSpawnTimer1);
		if(bearSpawnTimer1 <= 0.0f)
		{
			//first bear at spawnpoint1
			GameObject bear = Instantiate(m_PrefabBear, spawnpoint1.transform.position, spawnpoint1.transform.rotation) as GameObject;
			//bear.transform.localScale += Vector3();
			bear.name = string.Concat(bearString, i.ToString(), j.ToString());
			print ("bear.name = " +bear.name);
			//set the attributes in Movement
			Movement move = bear.GetComponent<Movement>();
			move.arraySize = 5;
			/*
			move.waypoints[0] = GameObject.Find("waypoint11");
			move.waypoints[1] = GameObject.Find("waypoint12");
			move.waypoints[2] = GameObject.Find("waypoint13");
			move.waypoints[3] = GameObject.Find("waypoint14");
			move.waypoints[4] = GameObject.Find("waypoint15");
			*/
			//set bear covertype
			Enemy e = bear.GetComponent<Enemy>();
			e.coverType = 0;

			bearSpawnTimer1 = 10.0f;
			j++;
		}

		if(lollipopSpawnTimer1 <= 0.0f)
		{
			GameObject lollipop = Instantiate(m_PrefabLollipop, spawnpoint1.transform.position, spawnpoint1.transform.rotation) as GameObject;
			lollipop.name = string.Concat(lollipopString, i.ToString(), j.ToString());
			print ("lollipop.name = " +lollipop.name);
			//set the attributes in Movement
			Movement move = lollipop.GetComponent<Movement>();
			move.arraySize = 5;

			//set bear covertype
			//EnemyLollipop e = lollipop.GetComponent<EnemyLollipop>();
			
			lollipopSpawnTimer1 = 10.0f;
			j++;
		}

		if(eggSpawnTimer1 <= 0.0f)
		{
			GameObject egg = Instantiate(m_PrefabEgg, spawnpoint1.transform.position, spawnpoint1.transform.rotation) as GameObject;
			egg.name = string.Concat(eggString, i.ToString(), j.ToString());
			print ("egg.name = " +egg.name);
			//set the attributes in Movement
			Movement move = egg.GetComponent<Movement>();
			move.arraySize = 5;
			
			//set bear covertype
			//EnemyLollipop e = lollipop.GetComponent<EnemyLollipop>();
			
			eggSpawnTimer1 = 10.0f;
			j++;
		}
		//when camera is at a certain point
	}
}

