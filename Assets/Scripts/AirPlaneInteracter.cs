using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPlaneInteracter : MonoBehaviour, Interactable {
	public GameObject planeController;
	public GameObject planeCamera;
	public GameObject playerController;
	public GameObject player;
	private bool fly = false;

	// Use this for initialization
	void Start () {
		
	}
	
	public void Interact() {
		fly = !fly;

		if (!fly) {
			player.transform.position = transform.position + new Vector3 (0, 2, 0);
			planeCamera.gameObject.SetActive (fly);
			planeController.GetComponent<AirplaneController> ().enabled = fly;
			playerController.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController> ().enabled = !fly;
			player.SetActive (!fly);
		} else {
			playerController.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController> ().enabled = !fly;
			player.SetActive (!fly);
			planeCamera.gameObject.SetActive (fly);
			planeController.GetComponent<AirplaneController> ().enabled = fly;
		}

		Debug.Log ("Flying: " + fly);

	}
}
