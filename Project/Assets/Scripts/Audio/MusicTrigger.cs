using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour {

	public int newTrack;
	public bool switchOnStart;

	private MusicController theMusicController;

	// Use this for initialization
	void Start () {

		theMusicController = FindObjectOfType<MusicController> ();

		if (switchOnStart) {

			theMusicController.SwitchTrack (newTrack);
			gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.name == "Player") {

			theMusicController.SwitchTrack (newTrack);
			gameObject.SetActive (false);
		}
	}
}
