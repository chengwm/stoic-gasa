using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public float delay;
	//made public for EnemyShoot.cs to access
	public enum States {
		NullStateID = 0, // Use this ID to represent a non-existing State in your system	
		Attack,
		ChangeCover,
		TakeCover
	}
	public States current;
	public float positionOriginal;
	private float attackTimer;	//countdown till attack from TakeCoverState
	private float coverTimer;	//countdown till take cover from AttackState
	private bool first = false;	//test if first time entering a statement
	public int coverType;

	// Audio
	public AudioClip getDamaged;
	public AudioClip getDamaged2;

	// Use this for initialization
	void Start () {
		//renderer.material.SetColor("_Color", Color.green);
		attackTimer = 100000.0f;
		//UnityEngine.Random.seed = System.DateTime.Now.Second;
		//coverTimer = UnityEngine.Random.value % 20.0f;
		coverTimer = 100000.0f;
		current = States.NullStateID;

		//positionOriginal = transform.position.y;
	}

	// Update is called once per frame
	void Update () {
		attackTimer -= Time.deltaTime;
		coverTimer -= Time.deltaTime;

		Movement move = this.GetComponent<Movement>();
		if(move.reached == true && move.pass == 1)
		{
			current = States.Attack;
			move.pass++;

			UnityEngine.Random.seed = System.DateTime.Now.Second;
			coverTimer = UnityEngine.Random.value % 20.0f;

			if(coverType == 0)
				positionOriginal = transform.position.y;
			else
				positionOriginal = transform.position.x;
		}

		//transition from AttackState to TakeCoverState
		if(coverTimer <= 0)
		{
			current = States.TakeCover;
			attackTimer = 2.0f; //reset other timer
			coverTimer = 100000.0f; //big number so that it won't drop zero
			first = true;
		}

		//action in TakeCoverState
		if(current == States.TakeCover && first == true)
		{

			Vector3 temp = transform.position;
			if(coverType == 0) // move down to take cover
			{
				if(temp.y >= positionOriginal - 1.0f)
					temp.y -= 0.1f;
				else 
					first = false; 
			}
			else if(coverType == 1) //move right to take cover
			{
				if(temp.x <= positionOriginal + 1.0f)
					temp.x += 0.1f;
				else
					first = false;
			}
			else if(coverType == 2) //move left to take cover
			{
				if(temp.x >= positionOriginal - 1.0f)
					temp.x -= 0.1f;
				else
					first = false;
			}

			transform.position = temp;
			//disable firing in EnemyShoot.cs 
		}

		//transition from TakeCoverState to AttackState
		if(attackTimer <= 0)
		{
			current = States.Attack;
			UnityEngine.Random.seed = System.DateTime.Now.Second;
			coverTimer = UnityEngine.Random.value % 20.0f; //reset other timer
			attackTimer = 100000.0f; //big number so that it won't drop zero
			first = true;
		}

		//action in AttackState
		if(current == States.Attack && first == true)
		{
			Vector3 temp = transform.position;
			if(coverType == 0)
			{
				if(temp.y <= positionOriginal)
					temp.y += 0.2f;
				else 
					first = false; 
			}			
			else if(coverType == 1)
			{
				if(temp.x >= positionOriginal)
					temp.x -= 0.2f;
				else 
					first = false; 
			}
			else if(coverType == 2)
			{
				if(temp.x <= positionOriginal)
					temp.x += 0.2f;
				else
					first = false; 
			}
			transform.position = temp;

			//enable firing in EnemyShoot.cs
		}

		//transition to ChangeCoverState
		//if detect shield button
		//GameObject[] covers = GameObject.FindObjectsWithTag("cover");
		//check if cover.position.x and cover.position.z already has a gummy bear there
		//move there

		/*
		if(transform.position.y <= -0.8f)
		{
			print("attackTimer = " + attackTimer);
			print("coverTimer = " + coverTimer);
			print("current = " + current);
		}
		*/
	}

	public void StartAnim()
	{
		print ("startAnim in bear");
		float audioToPlay = Random.Range(0.0F, 1.0F);
		if(audioToPlay < 0.5){
			audio.PlayOneShot(getDamaged);
		}
		else{
			audio.PlayOneShot(getDamaged2);
		}
		if(gameObject.tag == "Enemy"){
			//renderer.material.SetColor("_Color", Color.red);
			DestroyObject(gameObject, delay);
		}
		// You shot the head. Actions have to be performed with respect to its parent
		else{
			//transform.parent.renderer.material.SetColor("_Color", Color.red);
			DestroyObject(transform.parent.gameObject, delay); // if the head is shot, destroy the parent (body) as well
		}
		
	}

}
