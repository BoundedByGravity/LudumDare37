using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : MonoBehaviour {

	bool isOn = false;
	bool stateChanging = true;
	float changeProgress = 0.0f;

	Quaternion onRotation;
	Quaternion offRotation;

	// Use this for initialization
	void Start () {
		onRotation = transform.localRotation;
		Vector3 offRotationEuler = transform.localRotation.eulerAngles;		
		offRotationEuler.y = 155;
		offRotation = Quaternion.Euler(offRotationEuler);
	}
	
	// Update is called once per frame
	void Update () {
		
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
				//stateChanging = false;
			}
		}
	}
}
