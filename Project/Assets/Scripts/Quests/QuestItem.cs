using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour {

	public int questNumber;
	public string itemName;

	private QuestManager theQuestManager;

	// Use this for initialization
	void Start () {

		theQuestManager = FindObjectOfType<QuestManager> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.name == "Player") {

			if (!theQuestManager.questCompleted [questNumber] && theQuestManager.quests[questNumber].gameObject.activeSelf) {

				theQuestManager.itemCollected = itemName;
				gameObject.SetActive (false);
			}
		}
	}
}
