using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSwitch : MonoBehaviour, Interactable {
	float cooldown = 0;

	public void Interact() {
		GlobalStateController gsc;
		GameObject gs;
		gs = GameObject.Find ("GlobalState(Clone)");
		gsc = gs.GetComponent<GlobalStateController> ();
		if (gsc.getLevel () == 2) {
			GameObject.Find ("FPSController").GetComponent<Piller> ().makeSmall ();
			gsc.activateRocket ();
		}
		if (cooldown <= 0.0f) {
			cooldown = 2.0f;
			Handle handle = GetComponentInChildren<Handle> ();
			handle.toggle ();
		}
	}

	public void Update() {
		cooldown -= Time.deltaTime;
	}
}
