using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowWhenInteractionPossible : MonoBehaviour {

	Interactor interactor;

	// Use this for initialization
	void Start () {
		interactor = GameObject.FindObjectOfType<Interactor> ();
	}

	// Update is called once per frame
	void Update () {
		float alpha = 0.0f;
		if (interactor.canInteract) {
			alpha = 1.0f;
		}
		GetComponent<CanvasGroup>().alpha = alpha;
	}
}
