using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	// public float diagonalMoveSpeed;
	public float attackTime;
	public string startPoint;
	public bool canMove;

	private Vector2 moveInput;
	// private float currentMoveSpeed;
	private bool playerMoving;
	private bool playerAttacking;
	private float attackTimeCounter;
	private static bool playerExists;

	public Vector2 direction;
	private Animator anim;
	private Rigidbody2D myRigidbody;
	private SFXManager sfxManager;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
		myRigidbody = GetComponent<Rigidbody2D> ();
		sfxManager = FindObjectOfType<SFXManager> ();

		canMove = true;

		direction = new Vector2 (0, -1f);

		// Avoiding duplicate players
		if (!playerExists) {

			playerExists = true;
			DontDestroyOnLoad (transform.gameObject);

		} else {
			
			Destroy (gameObject);
		}


	}
	
	// Update is called once per frame
	void Update () {

		playerMoving = false;

		if (!canMove) {

			myRigidbody.velocity = Vector2.zero;
			return;
		}

		if (!playerAttacking || !EventSystem.current.IsPointerOverGameObject ()) {

			/*
			// X input
			if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f) {
			
				// transform.Translate (new Vector3 (Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
				myRigidbody.velocity = new Vector2 (Input.GetAxisRaw ("Horizontal") * currentMoveSpeed, myRigidbody.velocity.y);
				playerMoving = true;
				direction = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0f);
			}

			// Y input
			if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f) {

				// transform.Translate (new Vector3 (0f, Input.GetAxisRaw ("Vertical") * moveSpeed * Time.deltaTime, 0f));
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, Input.GetAxisRaw ("Vertical") * currentMoveSpeed);
				playerMoving = true;
				direction = new Vector2 (0f, Input.GetAxisRaw ("Vertical"));
			}

			if (Input.GetAxisRaw ("Horizontal") < 0.5f && Input.GetAxisRaw ("Horizontal") > -0.5f) {

				myRigidbody.velocity = new Vector2 (0f, myRigidbody.velocity.y);
			}

			if (Input.GetAxisRaw ("Vertical") < 0.5f && Input.GetAxisRaw ("Vertical") > -0.5f) {

				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, 0f);
			}
			*/

			moveInput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical")).normalized;

			if (moveInput != Vector2.zero) {

				myRigidbody.velocity = new Vector2 (moveInput.x * moveSpeed, moveInput.y * moveSpeed);
				playerMoving = true;
				direction = moveInput;

			} else {

				myRigidbody.velocity = Vector2.zero;
			}

			if (Input.GetButtonDown ("Fire1")) {

				attackTimeCounter = attackTime;
				playerAttacking = true;
				myRigidbody.velocity = Vector2.zero;
				anim.SetBool ("Attacking", true);

				sfxManager.playerAttack.Play ();
			}

			/*
			if (Mathf.Abs (Input.GetAxisRaw ("Horizontal")) > 0.5f && Mathf.Abs (Input.GetAxisRaw ("Vertical")) > 0.5f) {

				currentMoveSpeed = diagonalMoveSpeed;

			} else {
				
				currentMoveSpeed = moveSpeed;
			}
			*/
		}

		if (attackTimeCounter > 0) {

			attackTimeCounter -= Time.deltaTime;
		}

		if (attackTimeCounter <= 0) {

			playerAttacking = false;
			anim.SetBool ("Attacking", false);
		}

		anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
		anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
		anim.SetBool ("Moving", playerMoving);
		anim.SetFloat ("LastMoveX", direction.x);
		anim.SetFloat ("LastMoveY", direction.y);
	}
}
