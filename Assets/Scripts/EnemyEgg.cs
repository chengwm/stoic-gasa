using UnityEngine;
using System.Collections;

public class EnemyEgg : MonoBehaviour
{
	public GameObject player;
	public float delay;
	public int lifeEgg;
	public enum States {
		NullStateID = 0, // Use this ID to represent a non-existing State in your system	
		Attack,
		Wait,
		Charge
	}
	public States current;
	private float attackTimer;	//countdown till attack from one of the Fly states
	private float colourTimer; //for maintaining colour red after getting hit
	private Vector3 ePos, pPos;

	private int playerHealth = 0;

	// Use this for initialization
	void Start ()
	{
		renderer.material.SetColor("_Color", Color.yellow);
		lifeEgg = 10;
		current = States.Charge;
		attackTimer = -1.0f; //starts with negative number so that Egg will never enter Attack State until it reaches Player
		colourTimer = 0.5f;
	}

	// Update is called once per frame
	void Update ()
	{
		//print ("current = " + current);
		attackTimer -= Time.deltaTime;
		colourTimer -= Time.deltaTime;
		
		if(colourTimer <= 0.0f)
		{
			renderer.material.SetColor("_Color", Color.yellow);
		}

		//Charge State
		if(current == States.Charge)
		{
			ePos = transform.position;
			pPos = player.transform.position;
			//transition from Attack state to Retreat state
			//print ("e x diff = " + Mathf.Abs(ePos.x - pPos.x));
			//print ("e y diff = " + Mathf.Abs(ePos.y - pPos.y));
			//print ("e z diff = " + Mathf.Abs(ePos.z - pPos.z));
			//change according to model
			if (Mathf.Abs(ePos.x - pPos.x) < 3.0f && Mathf.Abs(ePos.y - pPos.y) < 2.0f
			    && Mathf.Abs(ePos.z - pPos.z) < 7.0f)
			{
				current = States.Attack;
				attackTimer = 0.0f;
			}
			else //charge towards player
			{
				rigidbody.velocity = (pPos - ePos);
			}
		}

		//Attack State
		if(current == States.Attack)
		{
			//print ("implement player minus one in health in Egg Attack State");
			current = States.Wait;
			attackTimer = 5.0f;

			// Get and update the health of the player
			if (PlayerPrefs.HasKey ("playerHealth")) {
				playerHealth = PlayerPrefs.GetInt ("playerHealth");
			}
			if(PlayerPrefs.GetInt ("shieldUp") == 0){
				playerHealth -= 1;
			}
			Debug.Log ("Health1 = " + playerHealth);
			PlayerPrefs.SetInt ("playerHealth", (int)playerHealth);

		}

		if(current == States.Wait)
		{
			rigidbody.velocity = new Vector3(0.0f, 0.0f, 0.0f);
			if(attackTimer <= 0.0f)
				current = States.Attack;
		}
	}

	//also responsible for injuring and killing the egg enemy
	public void StartAnim()
	{
		lifeEgg--;
		renderer.material.SetColor("_Color", Color.red);
		if(lifeEgg == 0)
		{
			DestroyObject(gameObject, delay);
			colourTimer = 0.5f;
		}
		else 
		{
			colourTimer = 0.5f;
		}
	}
}

