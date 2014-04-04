using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {
	// Note: Copy the Main Camera from the Menu GUI prefabs. The camera nested in the character does not work properly with this code.
	
	public Transform target1;
	public Transform target2;
	public Transform target3;
	public float RotationSpeed = 5;
	public float movementSpeed = 20;

	//values for internal use
	private Quaternion _lookRotation;
	private Vector3 _direction;
	private GameObject theCamera;
	public GameObject theCharacter;
	
	// Audio
	public AudioClip footsteps;
	
	void Start(){
		theCamera = Camera.main.gameObject;
		theCharacter = GameObject.FindWithTag("MainCharacter");
		audio.clip = footsteps;
	}

	// Update is called once per frame
	void Update () {
		// character hitbox follows the camera around
		theCharacter.transform.position = theCamera.transform.position;

		if ((!(GameObject.Find ("Target21"))) && (!(GameObject.Find ("Target22")))) {
			// Calculate the distance between the camera and the target
			float range1 = Vector3.Distance(theCamera.transform.position, target2.position );
			Debug.Log ("Range = " + range1);

			// Haven't reach
			if ( range1 > 5.0 ){
				//find the vector pointing from our position to the target
				_direction = (target2.position - transform.position).normalized;
				
				//create the rotation we need to be in to look at the target
				_lookRotation = Quaternion.LookRotation(_direction);
				
				//rotate us over time according to speed until we are in the required rotation
				transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
				theCharacter.transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);

				// calculate direction and move towards the target
				Vector3 dir = target2.transform.position - theCamera.transform.position;
				dir = dir.normalized;
				//theCharacter.transform.Translate(dir * movementSpeed * Time.deltaTime, Space.World);
				if(!audio.isPlaying){
					audio.Play ();
				}
				theCamera.transform.Translate(dir * movementSpeed * Time.deltaTime, Space.World);
				theCharacter.transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
			}
			// when reach the position, turn
			else if(range1 <= 5.0){
				audio.Stop ();
				//find the vector pointing from our position to the target
				_direction = (target3.position - transform.position).normalized;
				
				//create the rotation we need to be in to look at the target
				_lookRotation = Quaternion.LookRotation(_direction);
				
				//rotate us over time according to speed until we are in the required rotation
				transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
				theCharacter.transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
			}
		}

		else if ((!(GameObject.Find ("Target11"))) && (!(GameObject.Find ("Target12"))) && (!(GameObject.Find ("Target13")))) {

			//find the vector pointing from our position to the target
			_direction = (target1.position - transform.position).normalized;
				
			//create the rotation we need to be in to look at the target
			_lookRotation = Quaternion.LookRotation(_direction);
				
			//rotate us over time according to speed until we are in the required rotation
			transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
			theCharacter.transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
		}
	}
}
