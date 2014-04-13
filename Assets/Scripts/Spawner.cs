using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

public class Spawner : MonoBehaviour
{
	public GameObject m_PrefabBear; 
	public GameObject m_PrefabLollipop; 
	public GameObject m_PrefabEgg; 

	public GameObject[] spawnpoint;
	public int wave;

	private float bearSpawnTimer1, lollipopSpawnTimer1, eggSpawnTimer1;
	//private int i; //counter for name of spawnpoint
	//private int j; //counter for name of bear

	//constants
	const int spawnpointListSize = 13; 
	const string bearString = "bear", lollipopString = "lollipop", eggString = "egg", spawnpointString = "spawnpoint";

	private string temp;
	private int counter;

	// Use this for initialization
	void Start ()
	{
		counter = 0;
		wave = 1;

	}

	// Update is called once per frame
	void Update ()
	{
		if(counter == 0)
		{
			//set up the list of all the spawnpoints
			spawnpoint = new GameObject[spawnpointListSize];
			for(int i = 0; i < spawnpointListSize; i++)
			{
				temp = string.Concat(spawnpointString, i.ToString());
				spawnpoint[i] = GameObject.Find(temp);
			}
			counter++;
			print("once");
		}

		//bearSpawnTimer1 -= Time.deltaTime;
		//lollipopSpawnTimer1 -= Time.deltaTime;
		//eggSpawnTimer1 -= Time.deltaTime;
		//print ("bearSpawnTimer1 outside if statement= " + bearSpawnTimer1);

		//if(bearSpawnTimer1 <= 0.0f)
		//{
			/* pre-refactoring
			//first bear at spawnpoint0
			//GameObject bear1 = Instantiate(m_PrefabBear, spawnpoint0.transform.position, spawnpoint0.transform.rotation) as GameObject;
			//GameObject bear2 = Instantiate(m_PrefabBear, spawnpoint1.transform.position, spawnpoint1.transform.rotation) as GameObject;
			//bear1.name = string.Concat(bearString, i.ToString(), j.ToString());
			//print ("bear1.name = " +bear1.name);

			//set the whichRoute and arraySize in route in Movement
			//Movement move1 = bear1.GetComponent<Movement>();
			//Movement move2 = bear2.GetComponent<Movement>();
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
			*/
			//REMEMBER TO COMMENT AWAY LATER
			/*
			switch(wave)
			{
				//MakeABear(GameObject spawnpoint, int name, int route, int size, int cover)
			case 1:
				MakeABear(spawnpoint0, 1, 2, 4, 2);
				MakeABear(spawnpoint1, 2, 1, 4, 1);
				MakeABear(spawnpoint1, 3, 0, 3, 2);
				MakeABear(spawnpoint6, 4, 3, 3, 0);
				MakeABear(spawnpoint10, 5, 4, 3, 0);
				wave = 1000;
				break;
			case 2:
				MakeABear(spawnpoint0, 6, 2, 4, 2);
				MakeABear(spawnpoint6, 7, 3, 3, 0);
				MakeABear(spawnpoint5, 8, 5, 3, 2);
				MakeABear(spawnpoint1, 9, 0, 3, 2);
				MakeABear(spawnpoint6, 10, 6, 3, 0);
				wave = 1000;
				break;
			case 3:
				MakeABear(spawnpoint1, 11, 1, 4, 1);
				MakeABear(spawnpoint0, 12, 2, 4, 2);
				wave = 1000;
				break;
			case 4:
				MakeABear(spawnpoint10, 13, 4, 3, 0);
				MakeABear(spawnpoint10, 14, 7, 2, 0);
				MakeABear(spawnpoint5, 15, 8, 3, 2);
				MakeABear(spawnpoint5, 16, 9, 3, 1); //changed to shift right for cover
				wave = 1000;
				break;
			case 5:
				MakeABear(spawnpoint6, 17, 6, 3, 0);
				MakeABear(spawnpoint10, 18, 10, 3, 0);
				MakeABear(spawnpoint10, 19, 4, 3, 0);
				MakeABear(spawnpoint10, 20, 7, 2, 0); 
				break;
			case 6:
				MakeALollipop(spawnpoint11, 1, 11, 3);
				MakeABear(spawnpoint5, 21, 8, 3, 2);
				MakeABear(spawnpoint6, 22, 6, 3, 0);
			default:
				break;
			}
			*/
		//}
		/*
		if(lollipopSpawnTimer1 <= 0.0f)
		{
			GameObject lollipop = Instantiate(m_PrefabLollipop, spawnpoint0.transform.position, spawnpoint0.transform.rotation) as GameObject;
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
			GameObject egg = Instantiate(m_PrefabEgg, spawnpoint0.transform.position, spawnpoint0.transform.rotation) as GameObject;
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
		*/
	}

	public void MakeABear(GameObject spawnpoint, int name, int route, int size, int cover)
	{
		print ("spawning bear");
		GameObject bear = Instantiate(m_PrefabBear, spawnpoint.transform.position, spawnpoint.transform.rotation) as GameObject;

		bear.name = string.Concat(bearString, name.ToString());
		print (bear.name);
		Movement move = bear.GetComponent<Movement>();
		move.arraySize = size;
		move.whichRoute = route;

		Enemy e = bear.GetComponent<Enemy>();
		e.coverType = cover;
	}

	public void MakeALollipop(GameObject spawnpoint, int name, int route, int size)
	{
		GameObject lollipop = Instantiate(m_PrefabLollipop, spawnpoint.transform.position, spawnpoint.transform.rotation) as GameObject;
		lollipop.name = string.Concat(lollipopString, name.ToString());
		Movement move = lollipop.GetComponent<Movement>();
		move.arraySize = size;
		move.whichRoute = route;
	}

	public void MakeAnEgg(GameObject spawnpoint, int name, int route, int size)
	{
		GameObject lollipop = Instantiate(m_PrefabEgg, spawnpoint.transform.position, spawnpoint.transform.rotation) as GameObject;
		lollipop.name = string.Concat(eggString, name.ToString());
		Movement move = lollipop.GetComponent<Movement>();
		move.arraySize = size;
		move.whichRoute = route;
	}

}