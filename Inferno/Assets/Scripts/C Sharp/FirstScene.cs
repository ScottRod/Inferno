using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstScene : MonoBehaviour {

	float Timer = 0.5f;
	
	// Update is called once per frame
	void Update () {

		Timer -= Time.deltaTime;

		if (Timer <= 0) {

			SceneManager.LoadScene ("Purgatory");

		}
		
	}
}
