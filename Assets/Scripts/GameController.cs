using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject hazard;
	public Vector3 spawnValue;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public GUIText scoreText;
	private int score;

	void Start(){
		score = 0;
		UpdateScore ();
		StartCoroutine (spawnWayves ());
	}

	IEnumerator spawnWayves(){
		yield return new WaitForSeconds (startWait);
		while(true){
			for(int i = 0; i < hazardCount; i++){
				Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}

	void UpdateScore(){
		scoreText.text = "Score: " + score;
	}

	public void AddScore(int newScoreVal){
		score += newScoreVal;
		UpdateScore ();
	}
}
