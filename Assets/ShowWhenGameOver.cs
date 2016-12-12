using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowWhenGameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		float alpha = 0.0f;

		GlobalStateController gsc;
		GameObject gs;
		gs = GameObject.Find ("GlobalState(Clone)");
		gsc = gs.GetComponent<GlobalStateController> ();

		if (gsc.gameIsOver()) {
			alpha = 1.0f;
		}
		GetComponent<CanvasGroup>().alpha = alpha;
	}
}
