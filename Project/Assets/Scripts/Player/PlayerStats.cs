using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	public int level;
	public int exp;
	public int health;
	public int attack;
	public int defence;
	public int[] levelUp;
	public int[] healthLevels;
	public int[] attackLevels;
	public int[] defenceLevels;

	private PlayerHealthManager thePlayerHealth;


	// Use this for initialization
	void Start () {

		thePlayerHealth = FindObjectOfType<PlayerHealthManager> ();

		health = healthLevels [1];
		attack = attackLevels [1];
		defence = defenceLevels [1];
	}
	
	// Update is called once per frame
	void Update () {

		if (exp >= levelUp [level]) {

			// level ++;
			LevelUp();
		}
	}

	public void AddExperience(int expGain) {

		exp += expGain;
	}

	public void LevelUp() {

		level++;

		health = healthLevels [level];
		thePlayerHealth.playerMaxHealth = health;
		thePlayerHealth.playerHealth = thePlayerHealth.playerMaxHealth;

		attack = attackLevels [level];


		defence = defenceLevels [level];
	}
}
