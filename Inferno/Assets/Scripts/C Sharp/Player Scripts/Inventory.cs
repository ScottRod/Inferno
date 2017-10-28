using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	public GameObject PlayerObj;

	public string WeaponName = "Aqua Sword";

	public string SpellName = "Aqua Ball";

	bool WeaponActive = false;

	bool SpellActive = false;

	public bool WeaponType = false;

	public bool ChangingWeapon = false;

	void Start() {

		PlayerPrefs.SetInt ("", 1);

		//PlayerPrefs.DeleteAll ();

		// so the player actually has some stuff to attack with

		//PlayerPrefs.SetInt ("Aqua Sword", 0);

		//PlayerPrefs.SetInt ("Aqua Ball", 0);

		if (WeaponType == true) {
			
			if (PlayerPrefs.GetInt (WeaponName, 0) == 0) {

				WeaponActive = false;

				GetComponent<Image> ().enabled = false;

				GetComponentInChildren<Text> ().enabled = false;

			} else {

				GetComponent<Image> ().enabled = true;

				GetComponentInChildren<Text> ().enabled = true;

				WeaponActive = true;

			}


		}

		if (WeaponType == false) {

			if (PlayerPrefs.GetInt (SpellName, 0) == 0) {

				SpellActive = false;

				GetComponent<Image> ().enabled = false;

				GetComponentInChildren<Text> ().enabled = false;

			} else {

				GetComponent<Image> ().enabled = true;

				GetComponentInChildren<Text> ().enabled = true;

				SpellActive = true;

			}

		}

	}

	void Update() {

		if (WeaponType == true) {

			if (PlayerPrefs.GetInt (WeaponName, 0) == 0) {

				WeaponActive = false;

				GetComponent<Image> ().enabled = false;

				GetComponentInChildren<Text> ().enabled = false;

			} else {

				GetComponent<Image> ().enabled = true;

				GetComponentInChildren<Text> ().enabled = true;

				WeaponActive = true;

			}

		}

		if (WeaponType == false) {

			if (PlayerPrefs.GetInt (SpellName, 0) == 0) {

				SpellActive = false;

				GetComponent<Image> ().enabled = false;

				GetComponentInChildren<Text> ().enabled = false;

			} else {

				GetComponent<Image> ().enabled = true;

				GetComponentInChildren<Text> ().enabled = true;

				SpellActive = true;

			}

		}

	}

	public void EquipNewWeapon() {

		if (WeaponActive == true && WeaponType == true) {
			
			PlayerObj.GetComponent<Player> ().SpawnWeapon (WeaponName);

			PlayerPrefs.SetString ("Equipped Weapon", WeaponName);

		}

	}

	public void EquipMagic() {

		if (SpellActive == true && WeaponType == false) {

			PlayerObj.GetComponent<Player> ().EquippedSpell = SpellName;

			PlayerPrefs.SetString ("Equipped Spell", SpellName);

		}

	}

}
