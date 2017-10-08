using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePosition : MonoBehaviour {


	public Material mat;

	public Transform Position;

	public string Name;

	// Update is called once per frame
	void Update () {

		mat.SetVector (Name, Position.position);
		
	}
}
