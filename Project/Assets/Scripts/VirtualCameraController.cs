using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualCameraController : MonoBehaviour {

	private static bool virtualCameraExists;

	// Use this for initialization
	void Start () {

		if (!virtualCameraExists) {

			virtualCameraExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {

			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
