using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour {

	public bool Active = false;

	public Material PortalMat;

	public GameObject CameraObj;

	public Material XrayCameraMaterial; 

	public Material NormalCameraMaterial;

	bool x = false;

	public GameObject PlayerObj;

	public string RingSizeName;

	public string SceneToLoad;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Active == true) {

			if (Vector3.Distance (PlayerObj.transform.position, transform.position) < (transform.localScale.y * PortalMat.GetFloat (RingSizeName)) / 3) {

				SceneManager.LoadScene (SceneToLoad);

			}

			if (Vector3.Distance (PlayerObj.transform.position, transform.position) < (transform.localScale.y * PortalMat.GetFloat (RingSizeName)) / 2 && x == false) {

				CameraObj.GetComponent<CameraMaterialChange> ().newMaterial = XrayCameraMaterial;

				x = true;


			} else if (x == true && Vector3.Distance (PlayerObj.transform.position, transform.position) >= (transform.localScale.y * PortalMat.GetFloat (RingSizeName))) {

				x = false;

				CameraObj.GetComponent<CameraMaterialChange> ().newMaterial = NormalCameraMaterial;

			}

		}
		
	}

	void OnTriggerEnter(Collider other) {



	}

}
