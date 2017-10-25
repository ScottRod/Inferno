using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

	public GameObject ExplosionParticles;

	void OnTriggerEnter(Collider other) {
		 
		GameObject newExplosionObj = Instantiate (ExplosionParticles, transform.position, Quaternion.identity);

		newExplosionObj.GetComponent<ParticleSystem> ().Play ();

		Destroy (newExplosionObj, newExplosionObj.GetComponent<ParticleSystem> ().main.duration);

		Destroy (gameObject);

	}

}
