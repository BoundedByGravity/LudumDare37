using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : MonoBehaviour {
	bool isOn = false;
	float changeProgress = 0.0f;

	Quaternion onRotation;
	Quaternion offRotation;

	Renderer rend;

	Portal portal;

	// Use this for initialization
	void Start () {
		offRotation = transform.localRotation;
		Vector3 onRotationEuler = transform.localRotation.eulerAngles;		
		onRotationEuler.y = 155;
		onRotation = Quaternion.Euler(onRotationEuler);

		rend = GetComponent<Renderer>();
		portal = FindObjectOfType<Portal> ();
	}

	public void toggle() {
		StartCoroutine (toggleRouting ());
	}

	private void afterToggle() {
		//rend.material.shader = Shader.Find("Material.004");
		Color newColor;
		if (isOn) {
			newColor = Color.green;
		} else {
			newColor = Color.red;
		}
		rend.materials [1].color = newColor;
		rend.materials [1].SetColor ("_EmissionColor", newColor * 0.1f);

		portal.toggle ();
	}
		
	private IEnumerator toggleRouting () {
		while(changeProgress < 1.0f) {
			if (isOn) {
				transform.localRotation = Quaternion.Lerp (onRotation, offRotation, changeProgress);
				//Debug.Log (transform.localRotation);
			} else {
				transform.localRotation = Quaternion.Lerp (offRotation, onRotation, changeProgress);
			}
			changeProgress += 0.05f;
			yield return null;
		}

		changeProgress = 0f;
		isOn = !isOn;

		afterToggle ();
	}
}
