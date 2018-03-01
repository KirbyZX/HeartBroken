using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour {

	public int questNumber;
	public string startText;
	public string endText;
	public bool isItemQuest;
	public string targetItem;
	public bool isEnemyQuest;
	public string targetEnemy;
	public int enemiesToKill;

	public QuestManager theQuestManager;

	private int enemyKillCount;

	// Use this for initialization
	void Start () {

		theQuestManager.enemyKilled = null;
	}
	
	// Update is called once per frame
	void Update () {

		if (isItemQuest) {

			if (theQuestManager.itemCollected == targetItem) {

				theQuestManager.itemCollected = null;
				EndQuest ();
			}
		}

		if (isEnemyQuest) {

			if (theQuestManager.enemyKilled == targetEnemy) {

				theQuestManager.enemyKilled = null;
				enemyKillCount++;
			}

			if (enemyKillCount >= enemiesToKill) {

				EndQuest ();
			}
		}
	}

	public void StartQuest() {

		theQuestManager.ShowQuestDialogue (startText);
	}

	public void EndQuest() {

		theQuestManager.ShowQuestDialogue (endText);
		theQuestManager.questCompleted [questNumber] = true;
		gameObject.SetActive (false);
	}
}
