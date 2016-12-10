using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : MonoBehaviour {

	bool isOn = false;
	bool stateChanging = false;
	float changeProgress = 0.0f;

	Quaternion onRotation;
	Quaternion offRotation;

	// Use this for initialization
	void Start () {
		offRotation = transform.localRotation;
		Vector3 onRotationEuler = transform.localRotation.eulerAngles;		
		onRotationEuler.y = 155;
		onRotation = Quaternion.Euler(onRotationEuler);
	}

	public void toggle() {
		stateChanging = true;
	}
		
	void FixedUpdate () {
		if(stateChanging) {
			if (isOn) {
				transform.localRotation = Quaternion.Lerp (onRotation, offRotation, changeProgress);
				//Debug.Log (transform.localRotation);
			} else {
				transform.localRotation = Quaternion.Lerp (offRotation, onRotation, changeProgress);
			}
			changeProgress += 0.05f;
			if (changeProgress > 1f) {
				changeProgress = 0f;
				isOn = !isOn;
				stateChanging = false;
			}
		}
	}
}
