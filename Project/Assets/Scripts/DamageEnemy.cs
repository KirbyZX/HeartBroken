using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour {

	public int damage;
	public GameObject damageBurst;
	public Transform point;
	public GameObject damageNumber;

	private int currentDamage;
	private PlayerStats thePlayerStats;
	private SFXManager sfxManager;

	// Use this for initialization
	void Start () {

		thePlayerStats = FindObjectOfType<PlayerStats> ();
		sfxManager = FindObjectOfType<SFXManager> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.gameObject.tag == "Enemy") {

			// Destroy (other.gameObject);
			currentDamage = damage + thePlayerStats.attack;
			other.gameObject.GetComponent<EnemyHealthManager>().DamageEnemy(currentDamage);
			// Particle animation
			Instantiate (damageBurst, point.position, point.rotation);
			sfxManager.enemyHit.Play ();
			// Damage numbers
			var clone = (GameObject) Instantiate (damageNumber, point.position, Quaternion.Euler (Vector3.zero));
			clone.GetComponent<FloatingNumbers> ().damageNumber = currentDamage;
			clone.transform.position = point.position;
		}
	}
}
