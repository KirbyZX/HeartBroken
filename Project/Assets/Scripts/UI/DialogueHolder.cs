using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour {

	public string dialogue;
	public string[] dialogueLines;

	private DialogueManager dialogueManager;

	// Use this for initialization
	void Start () {

		dialogueManager = FindObjectOfType<DialogueManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D other) {

		if (other.gameObject.name == "Player") {

			if (Input.GetKeyUp (KeyCode.Space)) {

				//dialogueManager.DialogueBox (dialogue);

				if (!dialogueManager.dialogueActive) {

					dialogueManager.dialogueLines = dialogueLines;
					dialogueManager.currentLine = 0;
					dialogueManager.ShowDialogue ();
				}

				if (transform.parent.GetComponent<VillagerMovement> () != null) {

					transform.parent.GetComponent<VillagerMovement> ().canMove = false;
				}
			}
		}
	}
}
