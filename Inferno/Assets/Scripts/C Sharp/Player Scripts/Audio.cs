using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour {

	public AudioClip[] Music;

	// Use this for initialization
	void Start () {

		GetComponent<AudioSource> ().clip = Music [Random.Range(0, Music.Length-1)];

		GetComponent<AudioSource> ().Play ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
