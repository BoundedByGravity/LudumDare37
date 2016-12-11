using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour {

	public bool canInteract = false;
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		RaycastHit hit;
		Debug.DrawRay (transform.position, fwd * 10);
		if (Physics.Raycast (transform.position, fwd, out hit)) {
			Interactable interactable = hit.collider.gameObject.GetComponent<Interactable> ();
			if (interactable != null) {
				canInteract = true;
				//Debug.Log ("Interact possible!");
				if (Input.GetButtonUp ("Interact")) {
					interactable.Interact ();
				}
			} else {
				canInteract = false;
			}
		}
	}
}
