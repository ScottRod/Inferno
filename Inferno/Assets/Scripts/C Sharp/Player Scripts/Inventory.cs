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

	void Start() {

		PlayerPrefs.SetInt ("", 1);

		PlayerPrefs.SetInt ("Aqua Sword", 1);

		PlayerPrefs.SetInt ("Aqua Ball", 1);

		if (PlayerPrefs.GetInt (WeaponName, 0) == 0) {

			WeaponActive = false;

			GetComponent<Image> ().enabled = false;

			GetComponentInChildren<Text> ().enabled = false;

		} else {

			WeaponActive = true;

		}

		if (PlayerPrefs.GetInt (SpellName, 0) == 0) {

			SpellActive = false;

			GetComponent<Image> ().enabled = false;

			GetComponent<Text> ().enabled = false;

		} else {

			SpellActive = true;

		}

	}

	public void EquipNewWeapon() {

		if (WeaponActive == true) {

			PlayerObj.GetComponent<Player> ().SpawnWeapon (WeaponName);

		}

	}

	public void EquipMagic() {

		if (SpellActive == true) {

			PlayerObj.GetComponent<Player> ().EquippedSpell = SpellName;

		}

	}

}
