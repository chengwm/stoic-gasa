using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
	public int listSize, routeNo, routeWaypoint, arraySize, whichRoute;
	public GameObject[] list_waypoints;
	public GameObject[][] route_waypoints;
	public GameObject[] minion_waypoints;

	private int i = 0;
	private Vector3 wPos, ePos;
	public bool reached = false;
	public int pass = 1;

	private bool doInitialise = true;

	// Use this for initialization
	void Start ()
	{
		//set up the list of all the waypoints

		listSize = 11;
		list_waypoints = new GameObject[listSize];
		list_waypoints[0] = GameObject.Find("waypoint0");
		list_waypoints[1] = GameObject.Find("waypoint1");
		list_waypoints[2] = GameObject.Find("waypoint2");
		list_waypoints[3] = GameObject.Find("waypoint3");
		list_waypoints[4] = GameObject.Find("waypoint4");
		list_waypoints[5] = GameObject.Find("waypoint5");
		list_waypoints[6] = GameObject.Find("waypoint6");
		list_waypoints[7] = GameObject.Find("waypoint7");
		list_waypoints[8] = GameObject.Find("waypoint8");
		list_waypoints[9] = GameObject.Find("waypoint9");
		//last node is always Main Camera
		list_waypoints[listSize-1] = GameObject.Find("Main Camera");

		//organise waypoints into routes
		routeNo = 3;
		route_waypoints = new GameObject[routeNo][];

		//route 0
		routeWaypoint = 5;
		route_waypoints[0] = new GameObject[routeWaypoint];
		route_waypoints[0][0] = list_waypoints[0];
		route_waypoints[0][1] = list_waypoints[1];
		route_waypoints[0][2] = list_waypoints[2];
		route_waypoints[0][3] = list_waypoints[3];
		route_waypoints[0][4] = list_waypoints[listSize-1];

		//route 1
		routeWaypoint = 6;
		route_waypoints[1] = new GameObject[routeWaypoint];
		route_waypoints[1][0] = list_waypoints[0];
		route_waypoints[1][1] = list_waypoints[1];
		route_waypoints[1][2] = list_waypoints[2];
		route_waypoints[1][3] = list_waypoints[3];
		route_waypoints[1][4] = list_waypoints[4];
		route_waypoints[1][5] = list_waypoints[listSize-1];

		//route 2
		routeWaypoint = 6;
		route_waypoints[2] = new GameObject[routeWaypoint];
		route_waypoints[2][0] = list_waypoints[5];
		route_waypoints[2][1] = list_waypoints[6];
		route_waypoints[2][2] = list_waypoints[7];
		route_waypoints[2][3] = list_waypoints[8];
		route_waypoints[2][4] = list_waypoints[9];
		route_waypoints[2][5] = list_waypoints[listSize-1];
	}

	// Update is called once per frame
	void Update ()
	{
		if(doInitialise == true && arraySize != 0)
		{
			minion_waypoints = new GameObject[arraySize];
			/*
			minion_waypoints[0] = GameObject.Find("waypoint11");
			minion_waypoints[1] = GameObject.Find("waypoint12");
			minion_waypoints[2] = GameObject.Find("waypoint13");
			minion_waypoints[3] = GameObject.Find("waypoint14");
			minion_waypoints[4] = GameObject.Find("waypoint15");
			*/
			//for(int i = 0; i < arraySize; i++)
			//{
				minion_waypoints = route_waypoints[whichRoute];
			//}
			doInitialise = false;
			print ("array created");
		}
		if(i == arraySize-1)
		{
			reached = true;
			//rigidbody.MovePosition(transform.position);
			if(this.tag == "Enemy")
				rigidbody.velocity = Vector3.zero;
			transform.up = Vector3.up;
			//rigidbody.freezeRotation = true;
			//print ("here");
			//transform.rotation = Quaternion.Slerp(transform.rotation, transform.rotation, 1.0f);
			//rotateLookAt(waypoints[i].transform);
		}
		else
		{
			//print ("name = " + this.name + " and i = "+ i + " and reached = " + reached);
			wPos = minion_waypoints[i].transform.position;
			//print ("wPos = " + wPos);
			ePos = transform.position;
			//if(i == arraySize-2)
				//rigidbody.MovePosition(wPos);
			//	rigidbody.velocity = (wPos - ePos);
			//else
				//rigidbody.MovePosition(wPos);
				//rigidbody.velocity = ((wPos - ePos) / (wPos - ePos).magnitude) * 30.0f;
			rigidbody.velocity = (wPos - ePos).normalized * 30.0f;

			Vector3 direction = (minion_waypoints[i].transform.position - transform.position).normalized;
			float temp = -direction.z;
			direction.z = temp;
			Quaternion lookRotation = Quaternion.LookRotation(direction);

			transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime);


			if (Mathf.Abs(ePos.x - wPos.x) < 0.5f && Mathf.Abs(ePos.z - wPos.z) < 0.5f)
			{
				i++;
				//print ("i after increase = "+ i);
			}
		}
	}
}
