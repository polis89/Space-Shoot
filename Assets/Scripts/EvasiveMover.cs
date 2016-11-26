using UnityEngine;
using System.Collections;

public class EvasiveMover : MonoBehaviour {
	
	public float dodge;
	public Vector2 startWait;
	public Vector2 manouverTime;
	public Vector2 manouverWait;

	private float targetManeuver;

	void Start () {
		StartCoroutine (Evade ());
	}

	IEnumerator Evade(){
		yield return new WaitForSeconds (Random.Range (startWait.x, startWait.y));

		while (true) {
			targetManeuver = Random.Range (1, dodge) * -Mathf.Sign;
			yield return new WaitForSeconds ();
			targetManeuver = 0;
			yield return new WaitForSeconds ();
		}
	}

	void Update () {
	
	}
}
