using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;
	public float tilt;
	public Boundary boundary;
	private Rigidbody rigitbody;

	// Use this for initialization
	void Start () {
		rigitbody = GetComponent<Rigidbody>();
	}

	void FixedUpdate () {
		float moveHorisontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 vector = new Vector3 (moveHorisontal, 0.0f, moveVertical);
		rigitbody.velocity = vector * speed;
		rigitbody.position = new Vector3 (
			Mathf.Clamp(rigitbody.position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp(rigitbody.position.z, boundary.yMin, boundary.yMax)
		);
		rigitbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigitbody.velocity.x * -tilt);
	}
}

[System.Serializable]
public class Boundary{
	public float xMin, xMax, yMin, yMax;
}
