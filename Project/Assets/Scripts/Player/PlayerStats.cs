using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	public int level = 0;
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

        exp = GameManager.gameManager.experience;

		health = healthLevels [level];
		attack = attackLevels [level];
		defence = defenceLevels [level];
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
        GameManager.gameManager.experience = exp;
    }

	public void LevelUp() {

		level++;

		health = healthLevels [level];
		thePlayerHealth.playerMaxHealth = health;
		thePlayerHealth.playerHealth = thePlayerHealth.playerMaxHealth;

		attack = attackLevels [level];

		defence = defenceLevels [level];

        GameManager.gameManager.experience = exp;
        GameManager.gameManager.defence = defence;
        GameManager.gameManager.attack = attack;
    }
}
