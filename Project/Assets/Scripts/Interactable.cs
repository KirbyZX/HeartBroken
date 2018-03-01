using UnityEngine;

public class Interactable : MonoBehaviour {

	public float radius = 3f;
	public Transform interactionTransform;

	Transform player;

	bool hasInteracted = false;

	void Start() {

		player = FindObjectOfType<PlayerController> ().transform;
	}
	public virtual void Interact() {

		// This is meant to be overridden.
		Debug.Log("INTERACT with " + transform.name);
	}

	void Update () {

		if (!hasInteracted) {
			float distance = Vector2.Distance (player.position, interactionTransform.position);

			if (distance <= radius) {
				Interact ();
				hasInteracted = true;
			}
		}
	}
	void OnDrawGizmosSelected () {

		if (interactionTransform == null)
			interactionTransform = transform;
		
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere (interactionTransform.position, radius);
	}
}
