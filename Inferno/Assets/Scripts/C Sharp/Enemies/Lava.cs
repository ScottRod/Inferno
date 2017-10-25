using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour {

	public float Damage = 60.0f; // damage per second

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider other) {

		if (other.tag == "Player") {

			other.GetComponent<Player> ().Health -= Damage * Time.deltaTime;

		}

	}

}
