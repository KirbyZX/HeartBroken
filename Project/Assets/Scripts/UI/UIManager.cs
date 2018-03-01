using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Slider healthBar;
	public Text healthText;
	public Text levelText;
	public PlayerHealthManager playerHealth;

	private static bool UIExists;
	private PlayerStats thePlayerStats;

	// Use this for initialization
	void Start () {

		if (!UIExists) {

			UIExists = true;
			DontDestroyOnLoad (transform.gameObject);

		} else {

			Destroy (gameObject);
		}

		thePlayerStats = GetComponent<PlayerStats> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		healthBar.maxValue = playerHealth.playerMaxHealth;
		healthBar.value = playerHealth.playerHealth;
		if (playerHealth.playerHealth > 0) {
			
			healthText.text = "HP: " + playerHealth.playerHealth + "/" + playerHealth.playerMaxHealth;

		} else {

			healthText.text = "DEAD";
		}

		levelText.text = "Lvl: " + thePlayerStats.level; //+ " (EXP: " + thePlayerStats.exp + "/" + thePlayerStats.levelUp[thePlayerStats.level] + ")";
	}
}
