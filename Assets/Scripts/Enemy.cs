using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public float delay;

	// Use this for initialization
	void Start () {
		renderer.material.SetColor("_Color", Color.green);
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void StartAnim()
	{
		renderer.material.SetColor("_Color", Color.red);
		DestroyObject(gameObject, delay);
		//trackedTargets [0] = true;
		//if(trackedTargets StopAllCoroutines true) 
		//	Application.LoadLevel("endofdemo");
	}

}
