using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	public float Veclocity = 25.0f;

	public float Damage = 50.0f; // the amount of damage that is dealt to the enemies

	// Use this for initialization
	void Start () {

		GetComponent<Rigidbody> ().AddForce(transform.rotation*Vector3.forward*Veclocity);
		
	}
	
	// Update is called once per frame
	void Update () {


		
	}
}
