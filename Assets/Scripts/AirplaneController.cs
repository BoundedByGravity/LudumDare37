using UnityEngine;
using System.Collections;

public class AirplaneController: MonoBehaviour {

	//The maximum Thrust provided by the thruster(s) at full throttle
	private float rollWeight = 0.1f;
	private float rollmax = 1f;
	//of the controls, and to allow calibration for more massive ships.
	private float yawWeight = 0.1f;
	private float yawmax = 1f;

	//Set these 3 floats to the mass of the GetComponent<Rigidbody>() for sensitive controls
	private float throttle = 0;
	private float maxThrottle = 5;
	//public Transform prop;
	public Transform plane;
	public AudioClip audiodisapointment;

	private float yaw = 0;
	private float roll = 0;

	private Rigidbody rb;

	void Start() {
		enabled = false;
		rb = GetComponent<Rigidbody> ();
	}
	void OnDisable() {
		//rb.drag = 0;
	}
	void FixedUpdate ()
	{
		
		// Get input axises
		float yawin = yawWeight * Input.GetAxis ("Vertical");
		float rollin = rollWeight * Input.GetAxis ("Horizontal");


		yaw = Mathf.Clamp(yaw + yawin, -yawmax, yawmax);
		roll = Mathf.Clamp(roll + rollin, -rollmax, rollmax);


		//GetComponent<AudioSource> ().pitch = -roll / 5 + throttle;


		// Rotate and move the plane
		if (yaw != 0 || roll != 0) {
			Debug.Log ("Applying rot");
			transform.Rotate (yaw, 0, -roll);
		}
		transform.Translate (0, 0, throttle / 20f);



		if (yawin == 0) {
			yaw *= 0.5f;
			if (Mathf.Abs(yaw) < 2*yawWeight)
				yaw = 0;
		}
		if (rollin == 0) {
			roll *= 0.5f;
			if (Mathf.Abs(roll) < 2*rollWeight)
				roll = 0;
		}

		
			

		// Rotate the propeller
		//prop.Rotate(Vector3.right * throttle * 200);

		// Speed up the plane when using space
		if (Input.GetKey (KeyCode.Space) && throttle < maxThrottle) throttle += 0.05f;
		else if (throttle > 0) throttle -= 0.01f;

		//Debug.Log (throttle);

		// Let the plane get airborne
		//rb.drag = 50 * throttle + 5;
	}
}