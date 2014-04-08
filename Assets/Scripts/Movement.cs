using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
	public int arraySize = 0;
	public GameObject[] waypoints;
	private int i = 0;
	private Vector3 wPos, ePos;
	public bool reached = false;
	public int pass = 1;
	private bool updateSize = true;

	// Use this for initialization
	void Start ()
	{
		// waypoints = new GameObject[arraySize];
	}

	// Update is called once per frame
	void Update ()
	{
		if(updateSize == true && arraySize != 0)
		{
			waypoints = new GameObject[arraySize];
			waypoints[0] = GameObject.Find("waypoint11");
			waypoints[1] = GameObject.Find("waypoint12");
			waypoints[2] = GameObject.Find("waypoint13");
			waypoints[3] = GameObject.Find("waypoint14");
			waypoints[4] = GameObject.Find("waypoint15");
			updateSize = false;
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
			wPos = waypoints[i].transform.position;
			//print ("wPos = " + wPos);
			ePos = transform.position;
			//if(i == arraySize-2)
				//rigidbody.MovePosition(wPos);
			//	rigidbody.velocity = (wPos - ePos);
			//else
				//rigidbody.MovePosition(wPos);
				//rigidbody.velocity = ((wPos - ePos) / (wPos - ePos).magnitude) * 30.0f;
			rigidbody.velocity = (wPos - ePos).normalized * 30.0f;

			Vector3 direction = (waypoints[i].transform.position - transform.position).normalized;
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
