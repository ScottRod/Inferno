using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

	public GameObject PlayerObj;

	public GameObject Pentagram;

	public GameObject Explosion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {

		PlayerObj.transform.position = transform.position + Vector3.up;

		GameObject newPentagram = Instantiate (Pentagram, transform.position, Quaternion.identity);

		Destroy (newPentagram, 10.0f);

		GameObject newExplosion = Instantiate (Explosion, transform.position, Quaternion.identity);

		newExplosion.GetComponent<ParticleSystem> ().Play ();

		Destroy (gameObject);

	}

}
