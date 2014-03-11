using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

	public GameObject bullethole;

	
	// Update is called once per frame
	void Update () {
	
		Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		RaycastHit hit;
		
		if(Time.timeScale > 0){ // can only shoot if not paused
			if(Input.GetMouseButtonDown(0))
			{
				if(Physics.Raycast(myRay,out hit)) {
					Instantiate(bullethole, hit.point, Quaternion.identity);		
					Debug.DrawRay(myRay.origin, myRay.direction*hit.distance, Color.red);
	
					if(hit.transform.gameObject.tag == "Enemy") {
						GameObject target = hit.collider.gameObject;
						Enemy script = target.GetComponent<Enemy>();
						script.StartAnim();
					}
				}
					
			}
		}
	}
}
