using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour {

	public VolumeController[] volumeObjects;
	public float maxVolumeLevel = 1.0f;
	public float currentVolumeLevel;
	public Slider volumeSlider;

    private void OnEnable()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
        currentVolumeLevel = PlayerPrefs.GetFloat("volume");
    }

    // Use this for initialization
    void Start () {

        volumeObjects = FindObjectsOfType<VolumeController> ();

		if (currentVolumeLevel > maxVolumeLevel) {

			currentVolumeLevel = maxVolumeLevel;
		}

		for (int i = 0; i < volumeObjects.Length; i++) {

			volumeObjects [i].SetVolumeLevel (currentVolumeLevel);
		}
	}
}
