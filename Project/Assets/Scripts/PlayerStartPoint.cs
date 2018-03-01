using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour {

	public Vector2 startDirection;
	public string pointName;

	private PlayerController thePlayer;
	private MainCameraController theMainCamera;
	private VirtualCameraController theVirtualCamera;
	// private GameObject boundingAreaObject;
	// private PolygonCollider2D boundingArea;
	private Collider2D boundBox;

	// Use this for initialization
	void Start () {

		thePlayer = FindObjectOfType<PlayerController> ();
		boundBox = FindObjectOfType<BoundBox> ().GetComponent<PolygonCollider2D> ();

		if (thePlayer.startPoint == pointName) {

			thePlayer.transform.position = transform.position;
			thePlayer.direction = startDirection;

			theMainCamera = FindObjectOfType<MainCameraController> ();
			theMainCamera.transform.position = new Vector3 (transform.position.x, transform.position.y, theMainCamera.transform.position.z);
		
			theVirtualCamera = FindObjectOfType<VirtualCameraController> ();
			theVirtualCamera.transform.position = new Vector3 (transform.position.x, transform.position.y, theVirtualCamera.transform.position.z);
			// boundingAreaObject = GameObject.FindWithTag ("BoundingArea");
			// boundingArea = boundingAreaObject.gameObject.GetComponent<PolygonCollider2D> ();
			theVirtualCamera.gameObject.GetComponent<Cinemachine.CinemachineConfiner> ().m_BoundingShape2D = boundBox;
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}