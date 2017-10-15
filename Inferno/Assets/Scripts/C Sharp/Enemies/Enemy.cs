using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float Health = 100.0f;

	public float Damage = 10.0f; // per hit

	public GameObject PlayerObj;

	void OnCollisionEnter(Collision other) {

		if (other.gameObject.tag == "Player") {

			other.gameObject.GetComponent<Player> ().Health -= Damage/2;

		}

		if (other.gameObject.tag == "Spell") {

			Health -= other.gameObject.GetComponent<Shoot>().Damage;

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

			PlayerObj.GetComponent<Player> ().Score += 1;

			Destroy (gameObject);

		}

	}

}
