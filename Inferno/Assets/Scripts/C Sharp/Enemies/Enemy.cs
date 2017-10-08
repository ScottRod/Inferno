using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float Health = 100.0f;

	public float Damage = 10.0f; // per hit

	void OnCollisionEnter(Collision other) {

		if (other.gameObject.tag == "Player") {

			other.gameObject.GetComponent<Player> ().Health -= Damage/2;

		}

		if (other.gameObject.tag == "Spell") {

			Health -= 100.0f;

			//Destroy (other.gameObject);

		}

	}

	void OnTriggerStay(Collider other) {
		

	}

	void OnTriggerExit(Collider other) {

		if (other.gameObject.tag == "Player") {

			other.gameObject.GetComponent<Player> ().Health -= Damage/2;

		}

	}


	void Update() {

		if (Health <= 0) {

			Destroy (gameObject);

		}

	}

}
