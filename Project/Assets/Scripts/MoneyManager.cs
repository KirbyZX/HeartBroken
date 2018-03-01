using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour {

	public Text moneyText;
	public int currentMoney;

	// Use this for initialization
	void Start () {

		if (PlayerPrefs.HasKey ("CurrentMoney")) {
			
			currentMoney = PlayerPrefs.GetInt ("CurrentMoney");

		} else {

			currentMoney = 0;
			PlayerPrefs.SetInt ("CurrentMoney", 0);
		}

		moneyText.text = "Gold: " + currentMoney;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddMoney(int moneyToAdd) {

		currentMoney += moneyToAdd;
		PlayerPrefs.SetInt ("CurrentMoney", currentMoney);
		moneyText.text = "Gold: " + currentMoney;
	}
}
