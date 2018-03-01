using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour {

	public float defaultVolume;

	private AudioSource theAudio;
	private float audioLevel;

	// Use this for initialization
	void Start () {

		theAudio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetVolumeLevel(float volume) {

		if (theAudio == null) {

			theAudio = GetComponent<AudioSource> ();
		}

		if (!PauseMenu.isPaused) {
			
			audioLevel = defaultVolume * volume;
			theAudio.volume = audioLevel;

		} else {

			audioLevel = defaultVolume * volume * 0.5f;
			theAudio.volume = audioLevel;
		}
	}
}
