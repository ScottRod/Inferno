using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour {

	public GameObject DialogueObj; // the dialogue that will be created 

	public GameObject Canvas;

	public string DialogueText; // the text that will 

	public float ReadingTime; // the time the player has to read the text

	public string TriggerObject = "Player"; // what object will trigger the Dialogue

	void OnTriggerEnter(Collider other) {

		if (other.tag == "Player") {

			Destroy (gameObject);

			GameObject newObj = Instantiate (DialogueObj);

			newObj.transform.SetParent (Canvas.transform, false);

			newObj.GetComponentInChildren<Text> ().text = DialogueText;

			Destroy (newObj, ReadingTime);


		}

	}

}
