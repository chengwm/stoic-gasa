using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

	public GameObject bullethole;
	public GameObject ShotgunBullethole;
	private int ammoCount;
	public GunDisplay gunDisplayScript;
	[SerializeField]
	// Rate of fire for the enemy
	protected float fireRateHMG = 0.05F;
	protected float nextFireHMG = 0.5F;
	[SerializeField]
	protected float fireRateShotgun = 0.1F;
	protected float nextFireShotgun = 0.5F;
	private bool reloading = false;
	private bool shotgunShooting = false;

	// Update is called once per frame
	void Update () {
	
		Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		
		if(Time.timeScale > 0){ // can only shoot if not paused
			// if gun is pistol
			if(gunDisplayScript.currentSelection.Equals ("Pistol") && reloading == false)
			{
				if(Input.GetMouseButtonDown(0) )
				{
					gunDisplayScript.ammoCountPistol--; // decrease ammo count
					if(gunDisplayScript.ammoCountPistol == -1){ // if the pistol is empty and we attempt to shoot
						reloading = true; // let the script know that we are reloading
						StartCoroutine(PistolReload()); // call this method
					}
					
					else if(Physics.Raycast(myRay,out hit) && reloading == false) {
						Instantiate(bullethole, hit.point, Quaternion.identity);		
						Debug.DrawRay(myRay.origin, myRay.direction*hit.distance, Color.red);
		
						if(hit.transform.gameObject.tag == "Enemy") {
							GameObject target = hit.collider.gameObject;
							Enemy script = target.GetComponent<Enemy>();
							script.StartAnim();
						}

						if(hit.transform.gameObject.tag == "EnemyLollipop") {
							GameObject target = hit.collider.gameObject;
							EnemyLollipop script = target.GetComponent<EnemyLollipop>();
							script.StartAnim();
						}
					}
				}
			}
			
			// if gun is HMG
			if(gunDisplayScript.currentSelection == "HMG")
			{
				if(Input.GetMouseButton(0) && Time.time - nextFireHMG > fireRateHMG )
				{
					if(gunDisplayScript.ammoCountHMG == 0){ // if the pistol is empty and we attempt to shoot
						reloading = true; // let the script know that we are reloading
						StartCoroutine(HMGReload()); // call this method
					}
					
					if(Physics.Raycast(myRay,out hit) && reloading == false) {
						Instantiate(bullethole, hit.point, Quaternion.identity);		
						Debug.DrawRay(myRay.origin, myRay.direction*hit.distance, Color.red);
		
						if(hit.transform.gameObject.tag == "Enemy") {
							GameObject target = hit.collider.gameObject;
							Enemy script = target.GetComponent<Enemy>();
							script.StartAnim();
						}

						if(hit.transform.gameObject.tag == "EnemyLollipop") {
							GameObject target = hit.collider.gameObject;
							EnemyLollipop script = target.GetComponent<EnemyLollipop>();
							script.StartAnim();
						}

						gunDisplayScript.ammoCountHMG--; // decrease ammo count
						nextFireHMG = Time.time + fireRateHMG; // shooting delay
					}
				}
			}
			// If gun is shotgun
			if(gunDisplayScript.currentSelection == "Shotgun")
			{
				if(Input.GetMouseButtonDown(0) && shotgunShooting == false && reloading == false)
				{
					gunDisplayScript.ammoCountShotgun--; // decrease ammo count
					if(gunDisplayScript.ammoCountShotgun == -1){ // if the pistol is empty and we attempt to shoot
						reloading = true; // let the script know that we are reloading
						StartCoroutine(ShotgunReload()); // call this method
					}
					
					shotgunShooting = true; // let the script know that we are shooting with the shotgun
					StartCoroutine(ShotgunShooting()); // call this method

					if(Physics.Raycast(myRay,out hit) && reloading == false) {
						// a bigger bullet hole
						Instantiate(ShotgunBullethole, hit.point, Quaternion.identity);		
						Debug.DrawRay(myRay.origin, myRay.direction*hit.distance, Color.red);
		
						if(hit.transform.gameObject.tag == "Enemy") {
							GameObject target = hit.collider.gameObject;
							Enemy script = target.GetComponent<Enemy>();
							script.StartAnim();
						}

						if(hit.transform.gameObject.tag == "EnemyLollipop") {
							GameObject target = hit.collider.gameObject;
							EnemyLollipop script = target.GetComponent<EnemyLollipop>();
							script.StartAnim();
						}

					}
				}
			}
		}
	}
	
	// Reloading takes time
	IEnumerator PistolReload(){
		gunDisplayScript.ammoCountPistol++;
		yield return new WaitForSeconds(0.1F);
		gunDisplayScript.ammoCountPistol++;
		yield return new WaitForSeconds(0.1F);
		gunDisplayScript.ammoCountPistol++;
		yield return new WaitForSeconds(0.1F);
		gunDisplayScript.ammoCountPistol++;
		yield return new WaitForSeconds(0.1F);
		gunDisplayScript.ammoCountPistol++;
		yield return new WaitForSeconds(0.1F);
		gunDisplayScript.ammoCountPistol++;
		yield return new WaitForSeconds(0.1F);
		gunDisplayScript.ammoCountPistol++;
		reloading = false;
		yield break;
	}
	
	// Delay for shooting with a shotgun
	IEnumerator ShotgunShooting(){
		yield return new WaitForSeconds(0.5F);
		shotgunShooting = false;
		yield break;
	}
	
	// Reloading takes time
	IEnumerator ShotgunReload(){
		gunDisplayScript.ammoCountShotgun++;
		yield return new WaitForSeconds(0.5F);
		gunDisplayScript.ammoCountShotgun++;
		yield return new WaitForSeconds(0.5F);
		gunDisplayScript.ammoCountShotgun++;
		yield return new WaitForSeconds(0.5F);
		gunDisplayScript.ammoCountShotgun++;
		yield return new WaitForSeconds(0.5F);
		gunDisplayScript.ammoCountShotgun++;
		yield return new WaitForSeconds(0.5F);
		gunDisplayScript.ammoCountShotgun++;
		reloading = false;
		yield break;
	}
	
	// Reloading takes time
	IEnumerator HMGReload(){
		while(gunDisplayScript.ammoCountHMG != 40){
			gunDisplayScript.ammoCountHMG++;
			yield return new WaitForSeconds(0.05F);
		}
		reloading = false;
		yield break;
	}
}
