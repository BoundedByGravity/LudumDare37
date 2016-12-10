using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piller : MonoBehaviour {

	public GameObject rooms;
	private int roomScale;
	private float currentRoomScale, speed;

	// Use this for initialization
	void Start () {
		roomScale = 1;
		currentRoomScale = 1;
		speed = 2f;
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.E)) {
			if (roomScale == 1)
				roomScale = 100;
			else if (roomScale == 100)
				roomScale = 1;
		}

		if (roomScale != currentRoomScale) {
			// Scale rooms
			rooms.transform.localScale = Vector3.Lerp (rooms.transform.localScale, Vector3.one * roomScale, Time.deltaTime * speed);

			// Move rooms
			Vector3 dv = rooms.transform.position - transform.position;
			Vector3 toVector = transform.position + dv * (roomScale / currentRoomScale);
			rooms.transform.localPosition = Vector3.Lerp (rooms.transform.localPosition, toVector, Time.deltaTime * speed);

			// Scale lights
			Light[] lights = rooms.GetComponentsInChildren<Light>();
			foreach (Light l in lights) {
				l.range *= rooms.transform.localScale.x/currentRoomScale;		// 10 == Initial range
			}

			// Clamp currentRoomScale
			currentRoomScale = rooms.transform.localScale.x;
			if ((roomScale > currentRoomScale && currentRoomScale * 1.01f > roomScale) ||
			   (roomScale < currentRoomScale && currentRoomScale / 1.01f < roomScale)) {
				currentRoomScale = roomScale;
			}
			Debug.Log (currentRoomScale);
		}
	}

	void FixedUpdate () {
		
	}
}
