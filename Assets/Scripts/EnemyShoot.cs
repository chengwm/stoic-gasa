using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour
{
	public GameObject m_PrefabBullet; 
	public GameObject player;

	[SerializeField]
	// Speed of the bullet. 
	protected float m_Speed = 10.0f;
	[SerializeField]
	// Rate of fire for the enemy
	protected float fireRate = 0.5F;
	protected float nextFire = 0.5F;

	//void Start(){
		//Debug.Log ("Player position = " + player.transform.position.x + " " + player.transform.position.y + " "+ player.transform.position.z);

	//}
	
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
				// Adds a force to the bullet so it can move
				clone.rigidbody.velocity = ((player.transform.position - transform.position));
			}
		}
	}
}
