using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chests : MonoBehaviour {

	// this script will go onto the lid of the chest

	public string ItemName; // work it out

	public GameObject ItemObj;// the item's prefab, to show the item in the chest

	public GameObject PlayerObj; // to get the position

	public float OpenDistance = 5.0f; // work it out

	public float OpenSpeed = 20.0f; // the degrees the chest rotates per second

	GameObject newItemObj;

	bool Open = false;

	// Use this for initialization
	void Start () {
			
		newItemObj = Instantiate (ItemObj, transform.position + (transform.rotation * (Vector3.left + Vector3.forward)), Quaternion.identity);

		newItemObj.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);

		newItemObj.transform.Rotate (25, 0, 0);

		if (newItemObj.GetComponent<Weapon> ()) {

			newItemObj.GetComponent<Weapon> ().enabled = false;

		}
		
	}

	// Update is called once per frame
	void Update () {

		if (newItemObj) {

			newItemObj.transform.Rotate (0, 30 * Time.deltaTime, 0);

		}

		if (Vector3.Distance (PlayerObj.transform.position, transform.position) < OpenDistance) {

			Open = true;

		} else {

			Open = false;

		}

		if (Open == true && transform.localRotation.x > 0.3) {

			transform.Rotate (0, -OpenSpeed * Time.deltaTime, 0); // rotates on the y because the mesh has already been rotated

		} else if(Open == false && transform.localRotation.x < 0.707) {

			transform.Rotate (0, OpenSpeed * Time.deltaTime, 0);

		}

		if (newItemObj) {

			if (Vector3.Distance (PlayerObj.transform.position, newItemObj.transform.position) < 3.0f && Input.GetKeyDown (KeyCode.E)) {

				GetItem ();

			}

		}
		
	}

	public void GetItem() {

		Destroy (newItemObj);

		PlayerPrefs.SetInt (ItemName, 1);

	}

}
