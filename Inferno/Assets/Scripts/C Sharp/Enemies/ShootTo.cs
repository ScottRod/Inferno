using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTo : MonoBehaviour {

	public GameObject ShootObj; 

	public Transform Target;

	public Vector2 ShootDelayRange = new Vector2 (2,5);

	float ShootTimer = 0.0f;

	public float Velocity = 100.0f;

	public float DestroyDelay = 5.0f;

	void Shoot(Transform TargetPos) {

		if (Vector3.Distance (TargetPos.position, transform.position) < GetComponent<MoveTo> ().ViewDistance) {

			GameObject newObj = Instantiate (ShootObj, transform.position + (transform.rotation * Vector3.forward * 2), Quaternion.identity);

			newObj.transform.LookAt (TargetPos);

			if (newObj.GetComponent<Rigidbody> ()) {

				newObj.GetComponent<Rigidbody> ().AddForce (newObj.transform.rotation * Vector3.forward * Velocity);

			} else {

				newObj.AddComponent<Rigidbody> ();

				newObj.GetComponent<Rigidbody> ().AddForce (newObj.transform.rotation * Vector3.forward * Velocity);

			}

			Destroy (newObj, DestroyDelay);

		}

	}

	// Use this for initialization
	void Start () {

		ShootTimer = Random.Range(ShootDelayRange.x,ShootDelayRange.y);
	
	}
	
	// Update is called once per frame
	void Update () {

		ShootTimer -= Time.deltaTime;

		if (ShootTimer <= 0.0f) {

			ShootTimer = Random.Range(ShootDelayRange.x,ShootDelayRange.y);

			Shoot (Target);

		}
		
	}
}
