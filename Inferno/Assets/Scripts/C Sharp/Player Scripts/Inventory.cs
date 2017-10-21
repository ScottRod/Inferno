using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	public GameObject PlayerObj;

	public string WeaponName = "Aqua Sword";

	public string SpellName = "Aqua Ball";

	public void EquipNewWeapon() {

		//PlayerObj.GetComponent<Player> ().EquippedWeapon = WeaponName;

		PlayerObj.GetComponent<Player> ().SpawnWeapon (WeaponName);

	}

	public void EquipMagic() {

		PlayerObj.GetComponent<Player> ().EquippedSpell = SpellName;

	}

}
