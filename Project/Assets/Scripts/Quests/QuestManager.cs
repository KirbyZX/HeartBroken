using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

	public QuestObject[] quests;
	public bool[] questCompleted;
	public string itemCollected;
	public DialogueManager dialogueManager;
	public string enemyKilled;

	// Use this for initialization
	void Start () {

		questCompleted = new bool[quests.Length];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShowQuestDialogue(string questText) {

		dialogueManager.dialogueLines = new string[1];
		dialogueManager.dialogueLines [0] = questText;

		dialogueManager.currentLine = 0;
		dialogueManager.ShowDialogue ();
	}
}
