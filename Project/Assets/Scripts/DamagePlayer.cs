using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {

	public int damage;
	public GameObject damageNumber;

	private int currentDamage;
	private PlayerStats thePlayerStats;

	// Use this for initialization
	void Start () {

		thePlayerStats = FindObjectOfType<PlayerStats> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other) {

		if (other.gameObject.name == "Player") {

			currentDamage = damage - thePlayerStats.defence;
			if (currentDamage < 0) {
				
				currentDamage = 0;
			}

			other.gameObject.GetComponent<PlayerHealthManager> ().DamagePlayer (currentDamage);

			var clone = (GameObject) Instantiate (damageNumber, other.transform.position, Quaternion.Euler (Vector3.zero));
			clone.GetComponent<FloatingNumbers> ().damageNumber = currentDamage;
			clone.transform.position = other.transform.position;
		}
	}
}
