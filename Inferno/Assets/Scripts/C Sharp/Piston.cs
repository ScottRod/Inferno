using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piston : MonoBehaviour {

	public bool In = false; // checks whether the pistons are inside their holes, excuse the sexual joke

	public bool Active = true; // detemines whether the piston is moving or not 

	public float Speed = 2.0f; // meters per second

	public GameObject PistonObj; // so u can get the distance from the piston arms and the back of the spikes

	public GameObject BackThingyOfSpikes; 

	// when the timer < 2 and > 0 then the piston is going out

	// when the timer > 2 and < 4 then the piston is going in

	// when the timer > 4 then the timer is set back to 0

	float Timer = 2.0f; 

	// Use this for initialization
	void Start () {

		Time.timeScale = 3.0f;

		Timer = 2.0f / Speed;

		if (In == true) {

			Timer = 0.0f;

		}
		
	}
	
	// Update is called once per frame
	void Update () {

		Timer += Time.deltaTime;

		if (Timer >= 4/Speed) {

			Timer = 0.0f;

		}

		if (Timer >= 2.0f/Speed && Timer < 4.0f/Speed) {

			transform.Translate (transform.rotation * Vector3.left * Time.deltaTime * transform.localScale.y * Speed);

		}

		if (Timer >= 0 && Timer < 2.0f/Speed) {

			transform.Translate (transform.rotation * Vector3.right * Time.deltaTime * transform.localScale.y * Speed);

		}

		if (Vector3.Distance (PistonObj.transform.position, BackThingyOfSpikes.transform.position) > 3.66*transform.lossyScale.y) {

			Timer = 2 / Speed;

		}
		
	}
}
