using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

	public string enemyQuestName;
	public int enemyMaxHealth;
	public int enemyHealth;
	public int expDrop;

	private PlayerStats thePlayerStats;
	private QuestManager theQuestManager;

	// Use this for initialization
	void Start () {

		enemyHealth = enemyMaxHealth;

		thePlayerStats = FindObjectOfType<PlayerStats> ();
		theQuestManager = FindObjectOfType<QuestManager> ();
	}

	// Update is called once per frame
	void Update () {

		if (enemyHealth <= 0) {

			theQuestManager.enemyKilled = enemyQuestName;

			Destroy (gameObject);

			thePlayerStats.AddExperience (expDrop);
		}
	}

	public void DamageEnemy (int damage) {

		enemyHealth -= damage;
	}

	public void HealthToMax() {

		enemyHealth = enemyMaxHealth;
	}
}
