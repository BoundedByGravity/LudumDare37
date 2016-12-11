using UnityEngine;
using System.Collections;

public class AirplaneController: MonoBehaviour
{
	//The maximum Thrust provided by the thruster(s) at full throttle
	private float rollWeight = 3;
	//of the controls, and to allow calibration for more massive ships.
	private float yawWeight = 3;
	//Set these 3 floats to the mass of the GetComponent<Rigidbody>() for sensitive controls
	public static float throttle = 0;
	public Transform prop, plane;
	public AudioClip audiodisapointment;

	void Start() {
		enabled = false;
	}
	void OnDisable() {
		GetComponent<Rigidbody> ().drag = 0;
	}
	void FixedUpdate ()
	{
		
		// Get input axises
		float yaw = yawWeight * Input.GetAxis ("Horizontal");
		float roll = rollWeight * Input.GetAxis ("Vertical");

		GetComponent<AudioSource> ().pitch = -roll / 5 + throttle;

		if (yaw == 0 && roll == 0)
			GetComponent<Rigidbody> ().angularVelocity *= 0.95f;

		// Rotate and move the plane
		transform.Rotate (roll, 0, -yaw);
		transform.Translate (0, 0, throttle / 20f);

		// Rotate the propeller
		prop.Rotate(Vector3.right * throttle * 200);

		// Speed up the plane when using space
		if (Input.GetKey (KeyCode.Space) && throttle < 1)
			throttle += 0.05f;
		else if (throttle > 0)
			throttle -= 0.001f;

		// Let the plane get airborne
		GetComponent<Rigidbody> ().drag = 200 * throttle;
	}
}