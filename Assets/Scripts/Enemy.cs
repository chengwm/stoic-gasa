using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public float delay;
	private float attackTimer;	//countdown till attack from TakeCoverState
	private float coverTimer;	//countdown till take cover from AttackState
	enum States {
		NullStateID = 0, // Use this ID to represent a non-existing State in your system	
		Attack,
		ChangeCover,
		TakeCover
	}
	private States current;
	private bool first = false;	//test if first time entering a statement
	//public EnemyShoot es = new EnemyShoot();

	// Use this for initialization
	void Start () {
		renderer.material.SetColor("_Color", Color.green);
		attackTimer = 2.0f;
		UnityEngine.Random.seed = System.DateTime.Now.Second;
		coverTimer = UnityEngine.Random.value % 10.0f;
		States current = States.Attack;
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
			//if(temp.y >= 0.08f)
				temp.y -= 1.0f;
			//else 
				first = false; 
			transform.position = temp;

			//enable EnemyShoot.cs
			//es.enabled = false;
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
			//if(temp.y <= 1.08f)
				temp.y += 1.0f;
			//else 
				first = false;
			transform.position = temp;

			//disable EnemyShoot.cs
			//es.enabled = false;
		}

		//transition to ChangeCoverState
		//if detect shield button
		//GameObject[] covers = GameObject.FindObjectsWithTag("cover");
		//check if cover.position.x and cover.position.z already has a gummy bear there
		//move there
	}

	public void StartAnim()
	{
		renderer.material.SetColor("_Color", Color.red);
		DestroyObject(gameObject, delay);
	}

}
