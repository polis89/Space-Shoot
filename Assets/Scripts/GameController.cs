using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject[] hazards;
	public Vector3 spawnValue;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameoverText;

	private int score;
	private bool gameOver;
	private bool restart;

	void Start(){
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameoverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (spawnWayves ());
	}

	void Update(){
		if(restart){
			if(Input.GetKeyDown(KeyCode.R))Application.LoadLevel(Application.loadedLevel);
		}
	}
	IEnumerator spawnWayves(){
		yield return new WaitForSeconds (startWait);
		while(true){
			for(int i = 0; i < hazardCount; i++){
				GameObject hazard = hazards[Random.Range(0,hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			if (gameOver) {
				restartText.text = "Press 'R' for restart";
				restart = true;
				break;
			}
		}
	}

	void UpdateScore(){
		scoreText.text = "Score: " + score;
	}

	public void AddScore(int newScoreVal){
		score += newScoreVal;
		UpdateScore ();
	}

	public void GameOver(){
		gameoverText.text = "Game Over";
		gameOver = true;
	}
}
