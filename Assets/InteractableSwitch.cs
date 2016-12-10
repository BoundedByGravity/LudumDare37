using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSwitch : MonoBehaviour, Interactable {
	public void Interact() {
		Handle handle = GetComponentInChildren<Handle> ();
		handle.toggle ();
	}

	// Used in testing before player interaction is properly implemented
	void OnTriggerEnter() {
		Interact ();
	}
}
