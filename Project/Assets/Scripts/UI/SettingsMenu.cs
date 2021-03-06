﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {

	public Dropdown resolutionDropdown;
    public Dropdown qualityDropdown;

	private VolumeManager theVolumeManager;

	Resolution[] resolutions;


    void Start() {

		theVolumeManager = FindObjectOfType<VolumeManager> ();

		resolutions = Screen.resolutions;
		resolutionDropdown.ClearOptions();

		List<string> options = new List<string>();

		int currentResolutionIndex = 0;
		for (int i = 0; i < resolutions.Length; i++) {

			string option = resolutions [i].width + "x" + resolutions [i].height;
			options.Add (option);

			if (resolutions [i].width == Screen.currentResolution.width &&
				resolutions [i].height == Screen.currentResolution.height) {

				currentResolutionIndex = i;
			}
		}

		resolutionDropdown.AddOptions (options);
		resolutionDropdown.value = currentResolutionIndex;
		resolutionDropdown.RefreshShownValue ();

        // Setting PlayerPrefs volume
        for (int i = 0; i < theVolumeManager.volumeObjects.Length; i++)
        {

            theVolumeManager.volumeObjects[i].SetVolumeLevel(PlayerPrefs.GetFloat("volume"));
            PlayerPrefs.SetFloat("volume", PlayerPrefs.GetFloat("volume"));
        }

        // Setting PlayerPrefs quality
        qualityDropdown.value = PlayerPrefs.GetInt("quality");
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("quality"));
    }

	public void SetVolume (float volume) {

		for (int i = 0; i < theVolumeManager.volumeObjects.Length; i++) {

			theVolumeManager.volumeObjects [i].SetVolumeLevel (volume);
            PlayerPrefs.SetFloat("volume", volume);
		}

	}

	public void SetQuality(int qualityIndex) {

		QualitySettings.SetQualityLevel (qualityIndex);
        PlayerPrefs.SetInt("quality", qualityIndex);
	}

	public void SetFullscreen (bool isFullscreen) {

		Screen.fullScreen = isFullscreen;
	}

	public void SetResolution (int resolutionIndex) {

		Resolution resolution = resolutions [resolutionIndex];
		Screen.SetResolution (resolution.width, resolution.height, Screen.fullScreen);
	}
}
