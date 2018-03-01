using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerMovement : MonoBehaviour {

	public float moveSpeed;
	public bool isMoving;
	public float moveTime;
	public float waitTime;
	public bool canMove;

	public Collider2D moveConstraint;
	private Vector2 minMovePoint;
	private Vector2 maxMovePoint;

	private float moveTimeCounter;
	private float waitTimeCounter;
	private int moveDirection;
	private bool constraintActive;

	private Rigidbody2D myRigidbody;
	private DialogueManager theDialogueManager;

	// Use this for initialization
	void Start () {

		myRigidbody = GetComponent<Rigidbody2D> ();
		theDialogueManager = FindObjectOfType<DialogueManager> ();

		waitTimeCounter = waitTime;
		moveTimeCounter = moveTime;

		ChooseDirection ();

		if (moveConstraint != null) {
			
			minMovePoint = moveConstraint.bounds.min;
			maxMovePoint = moveConstraint.bounds.max;
			constraintActive = true;
		}

		canMove = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (!theDialogueManager.dialogueActive) {

			canMove = true;
		}

		if (!canMove) {

			myRigidbody.velocity = Vector2.zero;
			return;
		}

		if (isMoving) {

			moveTimeCounter -= Time.deltaTime;

			switch (moveDirection) {
			// up
			case 0:
				myRigidbody.velocity = new Vector2 (0, moveSpeed);
				if (constraintActive && transform.position.y > maxMovePoint.y) {

					isMoving = false;
					waitTimeCounter = waitTime;
				}
				break;
			// right
			case 1:
				myRigidbody.velocity = new Vector2 (moveSpeed, 0);
				if (constraintActive && transform.position.x > maxMovePoint.x) {

					isMoving = false;
					waitTimeCounter = waitTime;
				}
				break;
			// down
			case 2:
				myRigidbody.velocity = new Vector2 (0, -moveSpeed);
				if (constraintActive && transform.position.y < minMovePoint.y) {

					isMoving = false;
					waitTimeCounter = waitTime;
				}
				break;
			// left
			case 3:
				myRigidbody.velocity = new Vector2 (-moveSpeed, 0);
				if (constraintActive && transform.position.x < minMovePoint.x) {

					isMoving = false;
					waitTimeCounter = waitTime;
				}
				break;
			}

			if (moveTimeCounter < 0) {

				isMoving = false;
				waitTimeCounter = waitTime;
			}

		} else {

			waitTimeCounter -= Time.deltaTime;
			myRigidbody.velocity = Vector2.zero;

			if (waitTimeCounter < 0) {

				ChooseDirection ();
			}
		}
	}

	public void ChooseDirection() {

		moveDirection = Random.Range (0, 4);
		isMoving = true;
		moveTimeCounter = moveTime;
	}
}
