using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaSpreading : MonoBehaviour {

	public float SpawnDelay = 0.25f; // work it out

	float SpawnTimer;

	public GameObject LavaObj;

	public float DestroyDelay = 5.0f;

	// Use this for initialization
	void Start () {

		SpawnTimer = SpawnDelay;
		
	}
	
	// Update is called once per frame
	void Update () {

		SpawnTimer -= Time.deltaTime;

		if (SpawnTimer < 0) {

			GameObject newLavaObj = Instantiate (LavaObj, transform.position + Vector3.down / 2.0f, transform.rotation);

			Destroy (newLavaObj, DestroyDelay);

			SpawnTimer = SpawnDelay;

		}
		
	}
}
