using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;
	public float tilt;
	public GameObject shot;
	public Transform shotSpawnTransform;
	public Boundary boundary;
	public float fireRate;

	private Rigidbody rigitbody;
	private float nextFire = 0.0f;

	// Use this for initialization
	void Start () {
		rigitbody = GetComponent<Rigidbody>();
	}

	void Update(){
		if (Input.GetButton("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			//GameObject clone = 
			Instantiate (shot, shotSpawnTransform.position, shotSpawnTransform.rotation);// as GameObject;
		}
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
