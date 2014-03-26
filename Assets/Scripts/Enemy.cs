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

	// Use this for initialization
	void Start () {
		renderer.material.SetColor("_Color", Color.green);
		attackTimer = 100000.0f;
		UnityEngine.Random.seed = System.DateTime.Now.Second;
		coverTimer = UnityEngine.Random.value % 20.0f;
		States current = States.Attack;

		positionOriginal = transform.position.y;
	}

	// Update is called once per frame
	void Update () {
		attackTimer -= Time.deltaTime;
		coverTimer -= Time.deltaTime;

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
			if(temp.y >= positionOriginal - 1.0f)
			{
				temp.y -= 0.1f;
			}
			else 
			{
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

		//action in TakeCoverState
		if(current == States.Attack && first == true)
		{
			Vector3 temp = transform.position;
			if(temp.y <= positionOriginal)
			{
				temp.y += 0.2f;
			}
			else 
			{
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

		if(transform.position.y <= -0.8f)
		{
			print("attackTimer = " + attackTimer);
			print("coverTimer = " + coverTimer);
			print("current = " + current);
		}

	}

	public void StartAnim()
	{
		renderer.material.SetColor("_Color", Color.red);
		DestroyObject(gameObject, delay);
	}

}
