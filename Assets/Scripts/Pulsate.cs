using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulsate : MonoBehaviour {
	// Update is called once per frame
	void FixedUpdate () {
		transform.localScale = Vector3.one * (1f + Mathf.Sin (Time.time*2.0f)/15f);
	}
}
