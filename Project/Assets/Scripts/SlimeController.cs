using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeController : MonoBehaviour {

	public float moveSpeed;
	public float timeBetweenMove;
	public float timeToMove;
	public float reloadTime;

	private float timeBetweenMoveCounter;
	private float timeToMoveCounter;
	private bool moving;
	// private bool reloading;
	private Vector3 moveDirection;
	private GameObject thePlayer;

	private Rigidbody2D myRigidbody;
	private Animator anim;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
		myRigidbody = GetComponent<Rigidbody2D> ();

		// timeBetweenMoveCounter = timeBetweenMove;
		// timeToMoveCounter = timeToMove;

		timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
		timeToMoveCounter = Random.Range (timeToMove * 0.75f, timeToMove * 1.25f);
	}
	
	// Update is called once per frame
	void Update () {

		if (moving) {

			timeToMoveCounter -= Time.deltaTime;
			myRigidbody.velocity = moveDirection;

			if (timeToMoveCounter < 0f) {

				moving = false;
				// timeBetweenMoveCounter = timeBetweenMove;
				timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
			}

		} else {

			timeBetweenMoveCounter -= Time.deltaTime;
			myRigidbody.velocity = Vector2.zero;

			if (timeBetweenMoveCounter < 0f) {

				moving = true;
				// timeToMoveCounter = timeToMove;
				timeToMoveCounter = Random.Range (timeToMove * 0.75f, timeToMove * 1.25f);
				moveDirection = new Vector3 (Random.Range (-1f, 1f) * moveSpeed, Random.Range (-1f, 1f) * moveSpeed, 0f);
			}
		}

		anim.SetBool ("Moving", moving);

		/*
		if (reloading) {

			reloadTime -= Time.deltaTime;

			if (reloadTime < 0) {

				SceneManager.LoadScene ("main");
				thePlayer.SetActive (true);
			}
		} */
	}

	void OnCollisionEnter2D(Collision2D other) {

		/*if (other.gameObject.name == "Player") {

			// Destroy (other.gameObject);
			other.gameObject.SetActive(false);
			reloading = true;
			thePlayer = other.gameObject;

		}*/
	}
}
