using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour {

	private static bool mainCameraExists;

	// Use this for initialization
	void Start () {

		if (!mainCameraExists) {

			mainCameraExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {

			Destroy (gameObject);
		}
	}
}
