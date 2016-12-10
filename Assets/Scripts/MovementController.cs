using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {
	public GameObject planeController;
	public GameObject planeCamera;
	public GameObject playerController;
	public GameObject player;
	private bool fly = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
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

			Debug.Log (fly);
		}
	}
}
