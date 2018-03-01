using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

	public AudioSource[] musicTracks;
	public int currentTrack;
	public bool canPlay;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (canPlay && !PauseMenu.isPaused) {

			if (!musicTracks [currentTrack].isPlaying) {

				musicTracks [currentTrack].Play ();
			}

		} else {

			musicTracks [currentTrack].Stop ();
		}
	}

	public void SwitchTrack(int newTrack) {

		musicTracks [currentTrack].Stop ();
		currentTrack = newTrack;
		musicTracks [currentTrack].Play ();
	}
}
