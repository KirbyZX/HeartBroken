using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPickup : MonoBehaviour {

	public int value;

	public MoneyManager theMoneyManager;

	// Use this for initialization
	void Start () {

		theMoneyManager = FindObjectOfType<MoneyManager> ();
	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.gameObject.name == "Player") {

			theMoneyManager.AddMoney (value);
			Destroy (gameObject);
		}
	}
}
