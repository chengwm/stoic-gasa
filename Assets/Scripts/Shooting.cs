using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

	// Gun variables
	// -------------
	public GameObject bullethole;
	private int ammoCount;
	public GunDisplay gunDisplayScript;
	[SerializeField]
	// Rate of fire for the enemy
	protected float fireRateHMG = 0.05F;
	protected float nextFireHMG = 0.5F;
	[SerializeField]
	protected float fireRateShotgun = 0.1F;
	protected float nextFireShotgun = 0.5F;
	private bool shotgunShooting = false;
	// -------------

	// Shield variables
	// -------------
	public Shield shieldScript;
	// -------------

	// Score variables
	public InGameScoreScript scoreScript;

	// Update is called once per frame
	void Update () {
	
		Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		// Multiple raycasts for shotgun
		// ----------
		Ray myRay2 = Camera.main.ScreenPointToRay(Input.mousePosition - new Vector3(40,40,40));
		RaycastHit hit2;

		Ray myRay3 = Camera.main.ScreenPointToRay(Input.mousePosition + new Vector3(-40,40,-40));
		RaycastHit hit3;

		Ray myRay4 = Camera.main.ScreenPointToRay(Input.mousePosition + new Vector3(40,0,40));
		RaycastHit hit4;

		Ray myRay5 = Camera.main.ScreenPointToRay(Input.mousePosition + new Vector3(0,40,40));
		RaycastHit hit5;
		// ----------

		if(Time.timeScale > 0){ // can only shoot if not paused
			// if gun is pistol
			if(gunDisplayScript.currentSelection.Equals ("Pistol") && shieldScript.reloading == false)
			{
				if(Input.GetMouseButtonDown(0))
				{
					if(Physics.Raycast(myRay,out hit) && shieldScript.reloading == false) {
						if(gunDisplayScript.ammoCountPistol > 0 && hit.transform.gameObject.tag != "Shield" && hit.transform.gameObject.tag != "EnemyBullet"){ // prevent shooting the shield or bullet
							Instantiate(bullethole, hit.point, Quaternion.identity);		
							Debug.DrawRay(myRay.origin, myRay.direction*hit.distance, Color.red);
							gunDisplayScript.ammoCountPistol--; // decrease ammo count
			
							if(hit.transform.gameObject.tag == "Enemy") {
								GameObject target = hit.collider.gameObject;
								scoreScript.currentScore += 10;
								Enemy script = target.GetComponent<Enemy>();
								script.StartAnim();
							}
							else if(hit.transform.gameObject.tag == "EnemyHead") {
								GameObject target = hit.collider.gameObject;
								scoreScript.currentScore += 20;
								Enemy script = target.GetComponent<Enemy>();
								script.StartAnim();
							}
							else if(hit.transform.gameObject.tag == "EnemyLollipop") {
								GameObject target = hit.collider.gameObject;
								scoreScript.currentScore += 20;
								EnemyLollipop script = target.GetComponent<EnemyLollipop>();
								script.StartAnim();
							}
							else if(hit.transform.gameObject.tag == "EnemyEgg") {
								GameObject target = hit.collider.gameObject;
								scoreScript.currentScore += 30;
								EnemyEgg script = target.GetComponent<EnemyEgg>();
								script.StartAnim();
							}
						}
					}
				}
			}
			
			// if gun is HMG
			if(gunDisplayScript.currentSelection == "HMG")
			{
				if(Input.GetMouseButton(0) && Time.time - nextFireHMG > fireRateHMG )
				{

					if(Physics.Raycast(myRay,out hit) && shieldScript.reloading == false) {
						if(gunDisplayScript.ammoCountHMG > 0 && hit.transform.gameObject.tag != "Shield" && hit.transform.gameObject.tag != "EnemyBullet"){ // prevent shooting the shield or bullet
							Instantiate(bullethole, hit.point, Quaternion.identity);		
							Debug.DrawRay(myRay.origin, myRay.direction*hit.distance, Color.red);
			
							if(hit.transform.gameObject.tag == "Enemy") {
								GameObject target = hit.collider.gameObject;
								scoreScript.currentScore += 10;
								Enemy script = target.GetComponent<Enemy>();
								script.StartAnim();
							}
							else if(hit.transform.gameObject.tag == "EnemyLollipop") {
								GameObject target = hit.collider.gameObject;
								scoreScript.currentScore += 20;
								EnemyLollipop script = target.GetComponent<EnemyLollipop>();
								script.StartAnim();
							}
							else if(hit.transform.gameObject.tag == "EnemyEgg") {
								GameObject target = hit.collider.gameObject;
								scoreScript.currentScore += 30;
								EnemyEgg script = target.GetComponent<EnemyEgg>();
								script.StartAnim();
							}

							gunDisplayScript.ammoCountHMG--; // decrease ammo count
							nextFireHMG = Time.time + fireRateHMG; // shooting delay
						}
					}
				}
			}
			// If gun is shotgun
			if(gunDisplayScript.currentSelection == "Shotgun")
			{
				if(Input.GetMouseButtonDown(0) && shotgunShooting == false && shieldScript.reloading == false)
				{
									
					shotgunShooting = true; // let the script know that we are shooting with the shotgun
					StartCoroutine(ShotgunShooting()); // call this method

					// Bullet/raycast 1
					if(Physics.Raycast(myRay,out hit) && shieldScript.reloading == false) {
						if(gunDisplayScript.ammoCountShotgun > 0 && hit.transform.gameObject.tag != "Shield" && hit.transform.gameObject.tag != "EnemyBullet"){ // prevent shooting the shield or bullet
							gunDisplayScript.ammoCountShotgun--; // decrease ammo count 
							Instantiate(bullethole, hit.point, Quaternion.identity);		
							Debug.DrawRay(myRay.origin, myRay.direction*hit.distance, Color.red);
			
							if(hit.transform.gameObject.tag == "Enemy") {
								GameObject target = hit.collider.gameObject;
								scoreScript.currentScore += 10;
								Enemy script = target.GetComponent<Enemy>();
								script.StartAnim();
							}
							else if(hit.transform.gameObject.tag == "EnemyLollipop") {
								GameObject target = hit.collider.gameObject;
								scoreScript.currentScore += 20;
								EnemyLollipop script = target.GetComponent<EnemyLollipop>();
								script.StartAnim();
							}
							else if(hit.transform.gameObject.tag == "EnemyEgg") {
								GameObject target = hit.collider.gameObject;
								scoreScript.currentScore += 30;
								EnemyEgg script = target.GetComponent<EnemyEgg>();
								script.StartAnim();
							}
						}
					}

					// Bullet/raycast 2
					if(Physics.Raycast(myRay2,out hit2) && shieldScript.reloading == false) {
						if(gunDisplayScript.ammoCountShotgun > 0 && hit.transform.gameObject.tag != "Shield" && hit.transform.gameObject.tag != "EnemyBullet"){ // prevent shooting the shield or bullet
							Instantiate(bullethole, hit2.point, Quaternion.identity);		
							Debug.DrawRay(myRay2.origin, myRay2.direction*hit2.distance, Color.red);
							
							if(hit2.transform.gameObject.tag == "Enemy") {
								GameObject target = hit2.collider.gameObject;
								scoreScript.currentScore += 10;
								Enemy script = target.GetComponent<Enemy>();
								script.StartAnim();
							}
							else if(hit2.transform.gameObject.tag == "EnemyLollipop") {
								GameObject target = hit2.collider.gameObject;
								scoreScript.currentScore += 20;
								EnemyLollipop script = target.GetComponent<EnemyLollipop>();
								script.StartAnim();
							}
							else if(hit2.transform.gameObject.tag == "EnemyEgg") {
								GameObject target = hit2.collider.gameObject;
								scoreScript.currentScore += 30;
								EnemyEgg script = target.GetComponent<EnemyEgg>();
								script.StartAnim();
							}
						}
					}

					// Bullet/raycast 3
					if(Physics.Raycast(myRay3, out hit3) && shieldScript.reloading == false) {
						if(gunDisplayScript.ammoCountShotgun > 0 && hit.transform.gameObject.tag != "Shield" && hit.transform.gameObject.tag != "EnemyBullet"){ // prevent shooting the shield or bullet
							Instantiate(bullethole, hit3.point, Quaternion.identity);		
							Debug.DrawRay(myRay3.origin, myRay3.direction*hit3.distance, Color.red);
							
							if(hit3.transform.gameObject.tag == "Enemy") {
								GameObject target = hit3.collider.gameObject;
								scoreScript.currentScore += 10;
								Enemy script = target.GetComponent<Enemy>();
								script.StartAnim();
							}
							else if(hit3.transform.gameObject.tag == "EnemyLollipop") {
								GameObject target = hit3.collider.gameObject;
								scoreScript.currentScore += 20;
								EnemyLollipop script = target.GetComponent<EnemyLollipop>();
								script.StartAnim();
							}
							else if(hit3.transform.gameObject.tag == "EnemyEgg") {
								GameObject target = hit3.collider.gameObject;
								scoreScript.currentScore += 30;
								EnemyEgg script = target.GetComponent<EnemyEgg>();
								script.StartAnim();
							}
						}
					}

					// Bullet/raycast 4
					if(Physics.Raycast(myRay4, out hit4) && shieldScript.reloading == false) {
						if(gunDisplayScript.ammoCountShotgun > 0 && hit.transform.gameObject.tag != "Shield" && hit.transform.gameObject.tag != "EnemyBullet"){ // prevent shooting the shield or bullet
							Instantiate(bullethole, hit4.point, Quaternion.identity);		
							Debug.DrawRay(myRay4.origin, myRay4.direction*hit4.distance, Color.red);
							
							if(hit4.transform.gameObject.tag == "Enemy") {
								GameObject target = hit4.collider.gameObject;
								scoreScript.currentScore += 10;
								Enemy script = target.GetComponent<Enemy>();
								script.StartAnim();
							}
							else if(hit4.transform.gameObject.tag == "EnemyLollipop") {
								GameObject target = hit4.collider.gameObject;
								scoreScript.currentScore += 20;
								EnemyLollipop script = target.GetComponent<EnemyLollipop>();
								script.StartAnim();
							}
							else if(hit4.transform.gameObject.tag == "EnemyEgg") {
								GameObject target = hit4.collider.gameObject;
								scoreScript.currentScore += 30;
								EnemyEgg script = target.GetComponent<EnemyEgg>();
								script.StartAnim();
							}
						}
					}

					// Bullet/raycast 5
					if(Physics.Raycast(myRay5,out hit5) && shieldScript.reloading == false) {
						if(gunDisplayScript.ammoCountShotgun > 0 && hit.transform.gameObject.tag != "Shield" && hit.transform.gameObject.tag != "EnemyBullet"){ // prevent shooting the shield or bullet
							Instantiate(bullethole, hit5.point, Quaternion.identity);		
							Debug.DrawRay(myRay5.origin, myRay5.direction*hit5.distance, Color.red);
							
							if(hit5.transform.gameObject.tag == "Enemy") {
								GameObject target = hit5.collider.gameObject;
								scoreScript.currentScore += 10;
								Enemy script = target.GetComponent<Enemy>();
								script.StartAnim();
							}
							else if(hit5.transform.gameObject.tag == "EnemyLollipop") {
								GameObject target = hit5.collider.gameObject;
								scoreScript.currentScore += 20;
								EnemyLollipop script = target.GetComponent<EnemyLollipop>();
								script.StartAnim();
							}
							else if(hit5.transform.gameObject.tag == "EnemyEgg") {
								GameObject target = hit5.collider.gameObject;
								scoreScript.currentScore += 30;
								EnemyEgg script = target.GetComponent<EnemyEgg>();
								script.StartAnim();
							}
						}
					}
				}
			}
		}
	}

	// Delay for shooting with a shotgun
	IEnumerator ShotgunShooting(){
		yield return new WaitForSeconds(0.5F);
		shotgunShooting = false;
		yield break;
	}
}
