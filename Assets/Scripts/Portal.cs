using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour, Interactable {
	bool active = false;
	float startTime;
	ParticleSystem ps;

	void Start() {
		startTime = Time.time;
		ps = GetComponentInChildren<ParticleSystem> ();

		if (active) {
			ps.Play ();
			transform.localScale = Vector3.one;
		} else {
			ps.Stop ();
			transform.localScale = Vector3.zero;
		}
	}

	public void Interact() {
		GlobalStateController gsc = GameObject.Find ("GlobalState").GetComponent<GlobalStateController> ();
		gsc.setLevel (gsc.getLevel() + 1);
		ScreenFader sf = FindObjectOfType<ScreenFader> ();
		if (gsc.getLevel () == 3) {
			sf.EndScene (0, true);
		} else {
			sf.EndScene (0, false);
		}
	}

	public void toggle() {
		StartCoroutine (toggleRoutine ());
	}

	private IEnumerator toggleRoutine() {
		float progress = 0.0f;
		float step = 0.01f;
		float startState = active ? 1.0f : 0.0f;
		float endState = active ? 0.0f : 1.0f;

		if (!active) {
			ps.Play ();
		} else {
			ps.Stop ();
		}

		while(progress <= 1.0f) {
			yield return null;
			transform.localScale = Vector3.one * Mathf.Lerp (startState, endState, Mathf.Sin (progress * Mathf.PI / 2f));
			progress += step;
		}

		active = !active;
	}
		
	void FixedUpdate () {
		if (active) {
			float sinceStart = Time.time - startTime;
			float t = (Mathf.Sin(2.0f * sinceStart - Mathf.PI/2) + 1) / 2;
			//Debug.Log (sinceStart + " " + t);
			transform.localScale = Vector3.one * Mathf.Lerp(1.0f, 1.1f, t);
		} else {
			startTime = Time.time;
		}
	}
}
