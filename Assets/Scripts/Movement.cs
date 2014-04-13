using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
	public int coverpointListSize, waypointListSize, routeNo, routeWaypoint, arraySize, whichRoute;
	public GameObject[] list_waypoints;
	public GameObject[] list_coverpoints;
	public GameObject[][] route_waypoints;
	public GameObject[] minion_waypoints;
	
	private int positionInArray;
	private Vector3 wPos, ePos;
	public bool reached;
	public int pass;	//used in Enemy.cs

	private bool doInitialise;
	private bool waypointReached;
	private string temp;
	private int counter;

	const string coverpointString = "coverpoint", waypointString = "waypoint";
	
	// Use this for initialization
	void Start ()
	{
		//booleans
		reached = false;
		doInitialise = true;
		waypointReached = false;

		positionInArray = 0;
		counter = 0;



	}

	// Update is called once per frame
	void Update ()
	{
		if(counter == 0)
		{
			//set up the list of all the coverpoints
			coverpointListSize = 31; 
			list_coverpoints = new GameObject[coverpointListSize];
			for(int i = 0; i < coverpointListSize; i++)
			{
				temp = string.Concat(coverpointString, i.ToString());
				list_coverpoints[i] = GameObject.Find(temp);
			}
			
			//set up the list of all the waypoints
			waypointListSize = 22; //number of waypoint in the map plus one
			list_waypoints = new GameObject[waypointListSize];
			for(int i = 0; i < waypointListSize-1; i++)
			{
				temp = string.Concat(waypointString, i.ToString());
				list_waypoints[i] = GameObject.Find(temp);
			}
			//last node is always Main Camera so it will turn to face the camera
			list_waypoints[waypointListSize-1] = GameObject.Find("Main Camera");
			
			//organise waypoints into routes
			routeNo = 37;
			route_waypoints = new GameObject[routeNo][];
			
			//route 0
			routeWaypoint = 3;
			route_waypoints[0] = new GameObject[routeWaypoint];
			route_waypoints[0][0] = list_waypoints[0];
			route_waypoints[0][1] = list_coverpoints[0];
			route_waypoints[0][2] = list_waypoints[waypointListSize-1];
			
			//route 1
			routeWaypoint = 4;
			route_waypoints[1] = new GameObject[routeWaypoint];
			route_waypoints[1][0] = list_waypoints[0];
			route_waypoints[1][1] = list_waypoints[1];
			route_waypoints[1][2] = list_coverpoints[1];
			route_waypoints[1][3] = list_waypoints[waypointListSize-1];
			
			//route 2
			routeWaypoint = 4;
			route_waypoints[2] = new GameObject[routeWaypoint];
			route_waypoints[2][0] = list_waypoints[2];
			route_waypoints[2][1] = list_waypoints[3];
			route_waypoints[2][2] = list_coverpoints[2];
			route_waypoints[2][3] = list_waypoints[waypointListSize-1];
			
			//route 3
			routeWaypoint = 3;
			route_waypoints[3] = new GameObject[routeWaypoint];
			route_waypoints[3][0] = list_waypoints[4];
			route_waypoints[3][1] = list_coverpoints[9];
			route_waypoints[3][2] = list_waypoints[waypointListSize-1];
			
			//route 4
			routeWaypoint = 3;
			route_waypoints[4] = new GameObject[routeWaypoint];
			route_waypoints[4][0] = list_waypoints[5];
			route_waypoints[4][1] = list_coverpoints[5];
			route_waypoints[4][2] = list_waypoints[waypointListSize-1];
			
			//route 5
			routeWaypoint = 3;
			route_waypoints[5] = new GameObject[routeWaypoint];
			route_waypoints[5][0] = list_waypoints[6];
			route_waypoints[5][1] = list_coverpoints[4];
			route_waypoints[5][2] = list_waypoints[waypointListSize-1];
			
			//route 6
			routeWaypoint = 3;
			route_waypoints[6] = new GameObject[routeWaypoint];
			route_waypoints[6][0] = list_waypoints[4];
			route_waypoints[6][1] = list_coverpoints[8];
			route_waypoints[6][2] = list_waypoints[waypointListSize-1];
			
			//route 7
			routeWaypoint = 2;
			route_waypoints[7] = new GameObject[routeWaypoint];
			route_waypoints[7][0] = list_coverpoints[7];
			route_waypoints[7][1] = list_waypoints[waypointListSize-1];
			
			//route 8
			routeWaypoint = 5;
			route_waypoints[8] = new GameObject[routeWaypoint];
			route_waypoints[8][0] = list_waypoints[17];
			route_waypoints[8][1] = list_waypoints[18];
			route_waypoints[8][2] = list_waypoints[6];
			route_waypoints[8][3] = list_coverpoints[11];
			route_waypoints[8][4] = list_waypoints[waypointListSize-1];
			
			//route 9
			routeWaypoint = 3;
			route_waypoints[9] = new GameObject[routeWaypoint];
			route_waypoints[9][0] = list_waypoints[6];
			route_waypoints[9][1] = list_coverpoints[3];
			route_waypoints[9][2] = list_waypoints[waypointListSize-1];
			
			//route 10
			routeWaypoint = 3;
			route_waypoints[10] = new GameObject[routeWaypoint];
			route_waypoints[10][0] = list_waypoints[5];
			route_waypoints[10][1] = list_coverpoints[6];
			route_waypoints[10][2] = list_waypoints[waypointListSize-1];
			
			//route 11
			routeWaypoint = 3;
			route_waypoints[11] = new GameObject[routeWaypoint];
			route_waypoints[11][0] = list_waypoints[7];
			route_waypoints[11][1] = list_waypoints[8];
			route_waypoints[11][2] = list_waypoints[waypointListSize-1];
			
			//route 12
			routeWaypoint = 3;
			route_waypoints[12] = new GameObject[routeWaypoint];
			route_waypoints[12][0] = list_waypoints[9];
			route_waypoints[12][1] = list_coverpoints[12];
			route_waypoints[12][2] = list_waypoints[waypointListSize-1];
			
			//route 13
			routeWaypoint = 3;
			route_waypoints[13] = new GameObject[routeWaypoint];
			route_waypoints[13][0] = list_waypoints[4];
			route_waypoints[13][1] = list_coverpoints[13];
			route_waypoints[13][2] = list_waypoints[waypointListSize-1];
			
			//route 14
			routeWaypoint = 2;
			route_waypoints[14] = new GameObject[routeWaypoint];
			route_waypoints[14][0] = list_coverpoints[14];
			route_waypoints[14][1] = list_waypoints[waypointListSize-1];
			
			//route 15
			routeWaypoint = 2;
			route_waypoints[15] = new GameObject[routeWaypoint];
			route_waypoints[15][0] = list_coverpoints[15];
			route_waypoints[15][1] = list_waypoints[waypointListSize-1];
			
			//route 16
			routeWaypoint = 2;
			route_waypoints[16] = new GameObject[routeWaypoint];
			route_waypoints[16][0] = list_coverpoints[16];
			route_waypoints[16][1] = list_waypoints[waypointListSize-1];
			
			//route 17 serves no purpose for now
			routeWaypoint = 2;
			route_waypoints[17] = new GameObject[routeWaypoint];
			route_waypoints[17][0] = list_waypoints[6];
			route_waypoints[17][1] = list_waypoints[waypointListSize-1];
			
			//route 18
			routeWaypoint = 2;
			route_waypoints[18] = new GameObject[routeWaypoint];
			route_waypoints[18][0] = list_coverpoints[20];
			route_waypoints[18][1] = list_waypoints[waypointListSize-1];
			
			//route 19
			routeWaypoint = 2;
			route_waypoints[19] = new GameObject[routeWaypoint];
			route_waypoints[19][0] = list_coverpoints[19];
			route_waypoints[19][1] = list_waypoints[waypointListSize-1];
			
			//route 20
			routeWaypoint = 2;
			route_waypoints[20] = new GameObject[routeWaypoint];
			route_waypoints[20][0] = list_coverpoints[17];
			route_waypoints[20][1] = list_waypoints[waypointListSize-1];
			
			//route 21
			routeWaypoint = 4;
			route_waypoints[21] = new GameObject[routeWaypoint];
			route_waypoints[21][0] = list_waypoints[2];
			route_waypoints[21][1] = list_waypoints[10];
			route_waypoints[21][2] = list_waypoints[11];
			route_waypoints[21][3] = list_waypoints[waypointListSize-1];
			
			//route 22
			routeWaypoint = 2;
			route_waypoints[22] = new GameObject[routeWaypoint];
			route_waypoints[22][0] = list_coverpoints[22];
			route_waypoints[22][1] = list_waypoints[waypointListSize-1];
			
			//route 23
			routeWaypoint = 2;
			route_waypoints[23] = new GameObject[routeWaypoint];
			route_waypoints[23][0] = list_coverpoints[21];
			route_waypoints[23][1] = list_waypoints[waypointListSize-1];
			
			//route 24
			routeWaypoint = 2;
			route_waypoints[24] = new GameObject[routeWaypoint];
			route_waypoints[24][0] = list_coverpoints[18];
			route_waypoints[24][1] = list_waypoints[waypointListSize-1];
			
			//route 25
			routeWaypoint = 2;
			route_waypoints[25] = new GameObject[routeWaypoint];
			route_waypoints[25][0] = list_coverpoints[23];
			route_waypoints[25][1] = list_waypoints[waypointListSize-1];
			
			//route 26
			routeWaypoint = 3;
			route_waypoints[26] = new GameObject[routeWaypoint];
			route_waypoints[26][0] = list_waypoints[20];
			route_waypoints[26][1] = list_coverpoints[25];
			route_waypoints[26][2] = list_waypoints[waypointListSize-1];
			
			//route 27
			routeWaypoint = 4;
			route_waypoints[27] = new GameObject[routeWaypoint];
			route_waypoints[27][0] = list_waypoints[0];
			route_waypoints[27][1] = list_waypoints[12];
			route_waypoints[27][2] = list_waypoints[13];
			route_waypoints[27][3] = list_waypoints[waypointListSize-1];
			
			//route 28
			routeWaypoint = 3;
			route_waypoints[28] = new GameObject[routeWaypoint];
			route_waypoints[28][0] = list_waypoints[14];
			route_waypoints[28][1] = list_coverpoints[24];
			route_waypoints[28][2] = list_waypoints[waypointListSize-1];
			
			//route 29
			routeWaypoint = 2;
			route_waypoints[29] = new GameObject[routeWaypoint];
			//route_waypoints[29][0] = list_waypoints[15];
			route_waypoints[29][0] = list_coverpoints[26];
			route_waypoints[29][1] = list_waypoints[waypointListSize-1];
			
			//route 30
			routeWaypoint = 4;
			route_waypoints[30] = new GameObject[routeWaypoint];
			route_waypoints[30][0] = list_waypoints[2];
			route_waypoints[30][1] = list_waypoints[10];
			route_waypoints[30][2] = list_waypoints[13];
			route_waypoints[30][3] = list_waypoints[waypointListSize-1];
			
			//route 31
			routeWaypoint = 3;
			route_waypoints[31] = new GameObject[routeWaypoint];
			route_waypoints[31][0] = list_waypoints[16];
			route_waypoints[31][1] = list_coverpoints[30];
			route_waypoints[31][2] = list_waypoints[waypointListSize-1];
			
			//route 32
			routeWaypoint = 2;
			route_waypoints[32] = new GameObject[routeWaypoint];
			route_waypoints[32][0] = list_coverpoints[29];
			route_waypoints[32][1] = list_waypoints[waypointListSize-1];
			
			//route 33
			routeWaypoint = 2;
			route_waypoints[33] = new GameObject[routeWaypoint];
			route_waypoints[33][0] = list_coverpoints[27];
			route_waypoints[33][1] = list_waypoints[waypointListSize-1];
			
			//route 34
			routeWaypoint = 2;
			route_waypoints[34] = new GameObject[routeWaypoint];
			route_waypoints[34][0] = list_coverpoints[28];
			route_waypoints[34][1] = list_waypoints[waypointListSize-1];
			
			//route 35
			routeWaypoint = 3;
			route_waypoints[35] = new GameObject[routeWaypoint];
			route_waypoints[35][0] = list_waypoints[19];
			route_waypoints[35][1] = list_coverpoints[7];
			route_waypoints[35][2] = list_waypoints[waypointListSize-1];
			
			//route 36
			routeWaypoint = 4;
			route_waypoints[36] = new GameObject[routeWaypoint];
			route_waypoints[36][0] = list_waypoints[19];
			route_waypoints[36][1] = list_waypoints[5];
			route_waypoints[36][2] = list_coverpoints[6];
			route_waypoints[36][3] = list_waypoints[waypointListSize-1];
			counter++;
		}

		if(doInitialise == true && arraySize != 0)
		{
			minion_waypoints = new GameObject[arraySize];

			//print (this.name + " has arraySize = "+ arraySize);
			//print ("whichRoute = "+ whichRoute);
			for(int j = 0; j < arraySize; j++)
			{
				minion_waypoints[j] = route_waypoints[whichRoute][j];
			}
			/*
			for(int j = 0; j < arraySize; j++){
				print (this.name + " has " + minion_waypoints[j].name);
			}
			*/
			doInitialise = false;
			//print ("array created");
		}

		if(positionInArray== arraySize-1)
		{
			reached = true;
			//rigidbody.MovePosition(transform.position);
			if(this.tag == "Enemy")
			{
				rigidbody.velocity = Vector3.zero;
			
				//transform.up = Vector3.up;
				//rigidbody.freezeRotation = true;

				Vector3 direction = (transform.position - minion_waypoints[positionInArray].transform.position).normalized;
				Quaternion lookRotation = Quaternion.LookRotation(direction);
				if(lookRotation != transform.rotation)
					transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime);
				//rotateLookAt(waypoints[i].transform);
			}
		}
		else
		{
			//print ("name = " + this.name + " and positionInArray= "+ positionInArray+ " and reached = " + reached);
			wPos = minion_waypoints[positionInArray].transform.position;
			//print ("wPos = " + wPos);
			ePos = transform.position;

			if(this.tag != "EnemyEgg")
			{
				//Vector3 direction = (minion_waypoints[i].transform.position - transform.position).normalized;
				Vector3 direction = (transform.position - minion_waypoints[positionInArray].transform.position).normalized;
				Quaternion lookRotation = Quaternion.LookRotation(direction);

				transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime);
			}

			//reached way point
			if (Mathf.Abs(ePos.x - wPos.x) < 0.3f && Mathf.Abs(ePos.z - wPos.z) < 0.3f)
			{
				waypointReached = true;
				positionInArray++;
			}
			//haven't reach
			else
			{
				rigidbody.velocity = (wPos - ePos).normalized * 30.0f;
			}
			/*
			Vector3 direction = (minion_waypoints[positionInArray].transform.position - transform.position).normalized;
			float temp = -direction.z;
			direction.z = temp;
			Quaternion lookRotation = Quaternion.LookRotation(direction);

			if(waypointReached == true)
			{
				Vector3 direction = (transform.position - minion_waypoints[positionInArray+1].transform.position).normalized;
				Quaternion lookRotation = Quaternion.LookRotation(direction);
				if(transform.rotation != lookRotation)
				{
					transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime);
					print (this.name+" is rotating!");

				}
				else
				{
					positionInArray++;
					waypointReached = false;
				}
			}
			*/
		}
	}
}
