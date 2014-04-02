using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour
{
	public GameObject m_PrefabBullet; // Drag the prefab "EnemyBullet" here.
	public GameObject player; // Drag the prefab "Character" here.

	[SerializeField]
	// Speed of the bullet. 
	protected float m_Speed = 10.0f;
	[SerializeField]
	// Rate of fire for the enemy
	protected float fireRate = 0.5F;
	protected float nextFire = 0.5F;
	/*
	void Start(){
		Debug.Log ("Player position = " + player.transform.position.x + " " + player.transform.position.y + " "+ player.transform.position.z);
		
	}
	*/
	// Update is called once per frame
	void Update ()
	{
		GameObject enemy = GameObject.FindWithTag("Enemy");
		Enemy e = enemy.GetComponent<Enemy>();
		//only attacks when enemy is in attack state and when enemy has fully risen up
		if(e.current == Enemy.States.Attack && e.positionOriginal >= e.transform.position.y)
		{
			if(Time.time - nextFire > fireRate){
				nextFire = Time.time + fireRate;
				// Create a clone of the 'Bullet' prefab
				GameObject clone = Instantiate(m_PrefabBullet, transform.position, transform.rotation) as GameObject;
				//Debug.Log ("Bullet position = " + clone.transform.position.x + " " + clone.transform.position.y + " "+ clone.transform.position.z);
				//Debug.Log ("Target position = " + (player.transform.position - transform.position).x + " " + (player.transform.position - transform.position).y + " "+ (player.transform.position - transform.position).z);
				
				float hitOrNot = Random.Range(0.0F, 1.0F);
				float offsetValueX = Random.Range (-4.0F, 4.0F);
				float offsetValueY = Random.Range (-4.0F, 4.0F);
				
				// Exclude values where offset is between -1 and 1.
				while(offsetValueX < -2.0F && offsetValueX > 2.0F){
					offsetValueX = Random.Range (-4.0F, 4.0F);
				}
				while(offsetValueY < -2.0F && offsetValueY > 2.0F){
					offsetValueY = Random.Range (-4.0F, 4.0F);
				}
				
				Vector3 randomOffset;
				if(hitOrNot < 0.15F){ // hit
					Debug.Log ("Hit");
					randomOffset = new Vector3(0,0,0);
				}
				else{ // no hit
					randomOffset = new Vector3(offsetValueX, offsetValueY, offsetValueY);
				}

				// Adds a force to the bullet so it can move
				clone.rigidbody.velocity = ((player.transform.position + randomOffset - transform.position));
			}
		}
	}
}



