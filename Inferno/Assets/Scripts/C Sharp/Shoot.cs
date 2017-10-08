using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	CharacterController cc;

	public float Veclocity = 25.0f;

	// Use this for initialization
	void Start () {

		GetComponent<Rigidbody> ().AddForce(transform.rotation*Vector3.forward*Veclocity);
		
	}
	
	// Update is called once per frame
	void Update () {


		
	}
}
