using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chests : MonoBehaviour {

	public string ItemName; // work it out

	public GameObject ItemObj;// the item's prefab, to show the item in the chest

	GameObject newItemObj;

	// Use this for initialization
	void Start () {

		 newItemObj = Instantiate (ItemObj, transform.position + Vector3.down, Quaternion.identity); 
		
	}

	// Update is called once per frame
	void Update () {

		newItemObj.transform.Rotate (0, 30 * Time.deltaTime, 0);
		
	}

	public void GetItem() {

		PlayerPrefs.SetInt (ItemName, 1);

	}

}
