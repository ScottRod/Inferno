using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piston : MonoBehaviour {

	public bool In = false; // checks whether the pistons are inside their holes, excuse the sexual joke

	public bool Active = true; // detemines whether the piston is moving or not 

	public Vector2 SpeedRange = new Vector2(2, 5); // meters per second

	float Speed;

	public GameObject PistonObj; // so u can get the distance from the piston arms and the back of the spikes

	public GameObject BackThingyOfSpikes; 

	float Timer = 2.0f; 

	// Use this for initialization
	void Start () {

		if (SpeedRange.x >= SpeedRange.y) {

			SpeedRange.x = SpeedRange.y - 2.0f;

		}

		Speed = Random.Range (SpeedRange.x, SpeedRange.y);

		Timer = 2.0f / Speed;

		if (In == true) {

			Timer = 0.0f;

		}
		
	}
	
	// Update is called once per frame
	void Update () {

		Timer += Time.deltaTime;

		if (Timer >= 8/Speed) {

			Timer = 0.0f;

		}

		// going in

		if (Timer >= 4.0f/Speed && Timer < 8.0f/Speed) {

			transform.Translate (transform.rotation * Vector3.left * Time.deltaTime * Speed);

		}

		// going out

		if (Timer >= 0 && Timer < 4.0f/Speed) {

			transform.Translate (transform.rotation * Vector3.right * Time.deltaTime * Speed);

		}

		//Debug.Log (Vector3.Distance (PistonObj.transform.position, BackThingyOfSpikes.transform.position));

		float Distance = PistonObj.transform.position.z - BackThingyOfSpikes.transform.position.z;

		/*

		if (Vector3.Distance (PistonObj.transform.position, BackThingyOfSpikes.transform.position) > 2.7) {

			Timer = 2 / Speed;

		}

		if (Vector3.Distance (PistonObj.transform.position, BackThingyOfSpikes.transform.position) < 1.2) {

			Timer = 0.0f;

		}

		if (Vector3.Distance (PistonObj.transform.position, BackThingyOfSpikes.transform.position) < 1.1) {

			Debug.Log("Wubba lubba Dub Dub");

		}

*/

		//

		if (Mathf.Abs(Distance) > 4.67) {

			// starts going in

			Timer = 4 / Speed;

		}

		if (Mathf.Abs(Distance) < 1.8) {

			// goes out

			Timer = 0.0f;

		}

		if (Mathf.Abs(Distance) < 1.1) {

			//Debug.Log("Wubba lubba Dub Dub");

		}
		
	}
}
