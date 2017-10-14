using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	CharacterController cc; // player's character controller, used to move the player and make gravity effect it

	public GameObject Playercamera;

	public Material NormalCameraMaterial; // the camera rendering noramlly

	public Material LavaCameraMaterial; // what the camera looks like when the player is under lava or buring

	public string CurrentScene = "Level 1";

	public float Gravity = 1.0f; // gravity strength

	public float JumpPower = 10.0f;

	public bool Dead = false; // the variable that updates whether the 

	public float Health = 100.0f; // current player health

	public GameObject HealthText; // the text that displays the current player health 

	public float Stamina = 100.0f; // current stamina

	public GameObject StaminaText; // the text that displays the current stamina 

	public float Magica = 100.0f; // current magica 

	public float MagicaRegenSpeed = 1.0f; // the regen speed

	public GameObject AquaObject; // the water ball thing that the player can shoot

	public string EquippedSpell = "Aqua Ball"; // the current equipped spell 

	public GameObject MagicaText; // the text that displays the current magica text

	public float MoveSpeed = 10.0f; // the player speed in meters per second

	public float SprintSpeed = 15.0f; // the player sprint speed

	Vector3 speed = new Vector3(0,0,0); // current player speed in xyz

	public Vector2 LookSenstivity = new Vector3(1,1);

	public float RotateYaw = 0.0f;

	// Use this for initialization
	void Start () {



		Cursor.visible = false;

		Cursor.lockState = CursorLockMode.Locked;

		// if no character controller is found then it adds one

		if (GetComponent<CharacterController> () != null) {

			cc = GetComponent<CharacterController> (); 


		} else {

			gameObject.AddComponent<CharacterController> ();

			cc = GetComponent<CharacterController> ();

		}
		
	}
	
	// Update is called once per frame
	void Update () {

		Magica += Time.deltaTime * MagicaRegenSpeed;

		Magica = Mathf.Clamp (Magica, 0, 100);

		speed.x = 0.0f;

		speed.z = 0.0f;

		if(cc.isGrounded == false) { 

			// gravity

		speed.y += Physics.gravity.y * Time.deltaTime * Gravity;

		}

		if (Dead == false) {

			if (Input.GetButtonDown ("Jump") && cc.isGrounded == true) {

				// makes the player jump

				speed.y = JumpPower;

			}

			// move controls

			speed.x += Input.GetAxis ("Horizontal") * MoveSpeed;

			speed.z += Input.GetAxis ("Vertical") * MoveSpeed;

			// look controls x

			transform.Rotate (0, Input.GetAxis ("Mouse X") * LookSenstivity.x, 0);

			// look controls y

			RotateYaw -= Input.GetAxis ("Mouse Y") * LookSenstivity.y;

			RotateYaw = Mathf.Clamp (RotateYaw, -85, 90);

			// look y

			Playercamera.transform.localRotation = Quaternion.Euler (RotateYaw, 0, 0);

		}

		if (Health <= 0) {

			SceneManager.LoadScene (CurrentScene);

		}

		// sprinting

		if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {

			// speeds up the player speed

			speed.x *= 1.5f;  

			speed.z *= 1.5f; 

		}

		if (Input.GetMouseButtonDown(0) && EquippedSpell == "Aqua Ball" && Magica > 10) { // when the left mouse is clicked

			Magica -= 10.0f;

			GameObject newAqua = Instantiate (AquaObject, transform.position + (transform.rotation * Vector3.forward + new Vector3(0,Playercamera.transform.localPosition.y,0)), Quaternion.identity);

			newAqua.transform.rotation = transform.rotation * Playercamera.transform.localRotation;

			Destroy (newAqua, 5.0f);

		}

		// updates the text to display the current Health, stamina and magica

		HealthText.GetComponent<Text> ().text = "Health: " + Health;

		StaminaText.GetComponent<Text> ().text = "Stamina: " + Stamina;

		MagicaText.GetComponent<Text> ().text = "Magica: " + Mathf.Floor(Magica);

		cc.Move (transform.rotation * speed * Time.deltaTime); // moves the player
		 
	}

	// *triggered*

	void OnTriggerEnter(Collider other) {



   }

	void OnTriggerStay(Collider other) {

		if (other.tag == "Lava") {

			Health -= 5.0f;

			Playercamera.GetComponent<CameraMaterialChange> ().newMaterial = LavaCameraMaterial; 

		}

	}

	void OnTriggerExit(Collider other) {

		if (other.tag == "Lava") {

			Playercamera.GetComponent<CameraMaterialChange> ().newMaterial = NormalCameraMaterial;

		}

	}


}
