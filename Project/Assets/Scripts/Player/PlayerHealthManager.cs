using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour {

	public int playerMaxHealth;
	public int playerHealth;
	public float flashLength;

	private bool flashActive;
	private float flashLengthCounter;

	private SpriteRenderer playerSprite;
	private SFXManager sfxManager;

	// Use this for initialization
	void Start () {

		playerHealth = playerMaxHealth;

		playerSprite = GetComponent<SpriteRenderer> ();
		sfxManager = FindObjectOfType<SFXManager> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (playerHealth <= 0) {

			sfxManager.playerDeath.Play ();

			gameObject.SetActive (false);
		}

		if (flashActive) {

			if (flashLengthCounter > flashLength * .66f) {

				playerSprite.color = new Color (playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);

			} else if (flashLengthCounter > flashLength * .33f) {

				playerSprite.color = new Color (playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);

			} else if (flashLengthCounter > 0f) {

				playerSprite.color = new Color (playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
			} else {

				playerSprite.color = new Color (playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
				flashActive = false;
			}

			flashLengthCounter -= Time.deltaTime;
		}
	}

	public void DamagePlayer(int damage) {

		playerHealth -= damage;

		flashActive = true;
		flashLengthCounter = flashLength;

		sfxManager.playerHurt.Play ();
	}

	public void HealthToMax() {

		playerHealth = playerMaxHealth;
	}
}
