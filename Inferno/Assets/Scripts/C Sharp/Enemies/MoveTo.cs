using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour {

	public Transform Target;

	public float ViewDistance = 10.0f; // in meters

	NavMeshAgent navMesh;

	// Use this for initialization
	void Start () {

		navMesh = GetComponent<NavMeshAgent> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Vector3.Distance (Target.transform.position, transform.position) < ViewDistance) {

			navMesh.SetDestination (Target.transform.position);

		}
		
	}
}
