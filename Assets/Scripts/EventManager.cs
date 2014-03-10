using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {
	
	public Transform target1;
	public Transform target2;
	public float RotationSpeed;

	//values for internal use
	private Quaternion _lookRotation;
	private Vector3 _direction;

	// Update is called once per frame
	void Update () {
		if ((!(GameObject.Find ("Target11"))) && (!(GameObject.Find ("Target12"))) && (!(GameObject.Find ("Target13")))) {

			//find the vector pointing from our position to the target
			_direction = (target1.position - transform.position).normalized;
				
			//create the rotation we need to be in to look at the target
			_lookRotation = Quaternion.LookRotation(_direction);
				
			//rotate us over time according to speed until we are in the required rotation
			transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);

		}

		if ((!(GameObject.Find ("Target21"))) && (!(GameObject.Find ("Target22"))) && (!(GameObject.Find ("Target23")))) {
			//find the vector pointing from our position to the target
			_direction = (target2.position - transform.position).normalized;
			
			//create the rotation we need to be in to look at the target
			_lookRotation = Quaternion.LookRotation(_direction);
			
			//rotate us over time according to speed until we are in the required rotation
			transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
		}
	}
}
