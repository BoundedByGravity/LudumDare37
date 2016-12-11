using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulsate : MonoBehaviour {
	public bool active = false;
	float startTime;

	void Start() {
		startTime = Time.time;
	}

	void FixedUpdate () {
		if (active) {
			float sinceStart = Time.time - startTime;
			transform.localScale = Vector3.one * (1f + Mathf.Cos (sinceStart * 2.0f) / 15f);
		} else {
			startTime = Time.time;
		}
	}
}
