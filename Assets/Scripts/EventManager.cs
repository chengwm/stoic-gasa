using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {
	
	public Transform target1;
	public Transform target2;
	public Transform target3;
	public Transform target4;
	public Transform target5;
	public float RotationSpeed;
	public float movementSpeed = 5;

	//values for internal use
	private Quaternion _lookRotation;
	private Vector3 _direction;
	private GameObject theCamera;
	private GameObject theCharacter;
	
	void Start(){
		theCamera = Camera.main.gameObject;
		theCharacter = GameObject.FindWithTag("MainCharacter");
	}

	// Update is called once per frame
	void Update () {
		// character hitbox follows the camera around
		theCharacter.transform.position = theCamera.transform.position;
		
		if ((!(GameObject.Find ("Target41")))) {
			// Calculate the distance between the follower and the leader.
			float range2 = Vector3.Distance(theCamera.transform.position, target4.position );
			
			// if have not reach, turn and walk there.
			if(range2 > 0.1){
				//find the vector pointing from our position to the target
				_direction = (target4.position - transform.position).normalized;
				
				//create the rotation we need to be in to look at the target
				_lookRotation = Quaternion.LookRotation(_direction);
				
				//rotate us over time according to speed until we are in the required rotation
				transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
				
				// calculate direction and move towards the target
				Vector3 dir = target4.transform.position - theCamera.transform.position;
				dir = dir.normalized;
				theCamera.transform.Translate(dir * movementSpeed * Time.deltaTime, Space.World);
			}
			// when reach the position, turn
			else if(range2 <= 0.1){
				//find the vector pointing from our position to the target
				_direction = (target5.position - transform.position).normalized;
				
				//create the rotation we need to be in to look at the target
				_lookRotation = Quaternion.LookRotation(_direction);
				
				//rotate us over time according to speed until we are in the required rotation
				transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
			}
		}
		else if ((!(GameObject.Find ("Target31"))) && (!(GameObject.Find ("Target32"))) && (!(GameObject.Find ("Target33")))) {
			// Calculate the distance between the follower and the leader.
			float range1 = Vector3.Distance(theCamera.transform.position, target3.position );
			Debug.Log ("Range = " + range1);
			
			if ( range1 > 0.1 ){
				//find the vector pointing from our position to the target
				_direction = (target3.position - transform.position).normalized;
				
				//create the rotation we need to be in to look at the target
				_lookRotation = Quaternion.LookRotation(_direction);
				
				//rotate us over time according to speed until we are in the required rotation
				transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);

				// calculate direction and move towards the target
				Vector3 dir = target3.transform.position - theCamera.transform.position;
				dir = dir.normalized;
				//theCharacter.transform.Translate(dir * movementSpeed * Time.deltaTime, Space.World);
				theCamera.transform.Translate(dir * movementSpeed * Time.deltaTime, Space.World);
			}
		}
		else if ((!(GameObject.Find ("Target21"))) && (!(GameObject.Find ("Target22"))) && (!(GameObject.Find ("Target23")))) {
			//find the vector pointing from our position to the target
			_direction = (target2.position - transform.position).normalized;
			
			//create the rotation we need to be in to look at the target
			_lookRotation = Quaternion.LookRotation(_direction);
			
			//rotate us over time according to speed until we are in the required rotation
			transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
			
		}
		else if ((!(GameObject.Find ("Target11"))) && (!(GameObject.Find ("Target12"))) && (!(GameObject.Find ("Target13")))) {

			//find the vector pointing from our position to the target
			_direction = (target1.position - transform.position).normalized;
				
			//create the rotation we need to be in to look at the target
			_lookRotation = Quaternion.LookRotation(_direction);
				
			//rotate us over time according to speed until we are in the required rotation
			transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);

		}
	}
}
