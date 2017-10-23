using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour {

	public bool Active = false;

	public bool LevelAccessPortal = false;

	public string LevelName;

	public Material PortalMat;

	public GameObject CameraObj;

	public Material XrayCameraMaterial; 

	public Material NormalCameraMaterial;

	bool x = false;

	public GameObject PlayerObj;

	public string RingSizeName;

	public string SceneToLoad;


	void Start () {

		PlayerPrefs.SetInt ("0", 1); // 0 is the first level (the tutorial)

		// even is the portal that accesses the level (including 0)

		// odd is finishing the level

		// note that for the score pass script on the portals that access the level set the required kill count to 1

		if (PlayerPrefs.GetInt (LevelName.ToString(), 0) != 0) {

			Active = true;

		}
		
	}


	void Update () {

		if (Active == true) {

			if (Vector3.Distance (PlayerObj.transform.position, transform.position) < (transform.localScale.y * PortalMat.GetFloat (RingSizeName)) / 3) {

				int y = int.Parse(LevelName) + 1;

				string z = y.ToString ();

				PlayerPrefs.SetInt (z, 1); 

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
