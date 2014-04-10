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
		spawnpoint2 = GameObject.Find("spawnpoint2");

		//placeholders. final game need to set how many to spawn etc
		bearSpawnTimer1 = 1.0f;
		lollipopSpawnTimer1 = 3.5f;	
		eggSpawnTimer1 = 5.0f;

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
			GameObject bear1 = Instantiate(m_PrefabBear, spawnpoint1.transform.position, spawnpoint1.transform.rotation) as GameObject;
			GameObject bear2 = Instantiate(m_PrefabBear, spawnpoint2.transform.position, spawnpoint2.transform.rotation) as GameObject;
			//bear.transform.localScale += Vector3();
			//bear1.name = string.Concat(bearString, i.ToString(), j.ToString());
			//print ("bear1.name = " +bear1.name);

			//set the whichRoute and arraySize in route in Movement
			Movement move1 = bear1.GetComponent<Movement>();
			Movement move2 = bear2.GetComponent<Movement>();
			if(j % 2 == 0)
			{
				move1.whichRoute = 0;
				move1.arraySize = 5;
			}
			else 
			{
				move1.whichRoute = 1;
				move1.arraySize = 6;
			}

			move2.whichRoute = 2;
			move2.arraySize = 6;

			//set bear covertype
			Enemy e1 = bear1.GetComponent<Enemy>();
			e1.coverType = 4;

			Enemy e2 = bear2.GetComponent<Enemy>();
			e2.coverType = 4;

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
			move.whichRoute = 0;
			move.arraySize = 5;
			
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
			move.whichRoute = 0;
			move.arraySize = 5;

			eggSpawnTimer1 = 10.0f;
			j++;
		}
		//when camera is at a certain point
	}
}

