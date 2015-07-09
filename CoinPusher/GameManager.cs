using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public Transform prefabCoin;
	public Transform prefabBonusCoin;

	public GameObject floorBase;
	public GameObject floorPusher;
	public GameObject gameOver;
	public GameObject directionalLight;
	public GameObject spawner;

	public static int score;
	private int scoreBuf;

	private float gameOverTime;
	private bool isGameOver;

	// Use this for initialization
	void Start () {
		isGameOver = false;
		score = 30;
		scoreBuf = score;
		// disable gameOber object
		gameOver.SetActive (false);

		for (int i = 0; i < 10; i++) {
			createRandomCoin (floorBase);
//			createRandomCoin (floorPusher);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (score <= 0 && scoreBuf > 0) {
			gameOverTime = Time.time;
			isGameOver = true;
		} else if (score > 0) {
			isGameOver = false;
		}

		if (isGameOver 
			&& score <= 0 
			&& Time.time - gameOverTime > 10f) {
			// gameOver
			onGameOver();
		}
		scoreBuf = score;

		if (isGameOver) {
			Debug.Log ("game over now : " + (Time.time - gameOverTime).ToString());
		}
	}

	public void getCoin(Collider other) {

		Debug.Log ("get : " + other.gameObject.name);

		switch (other.gameObject.name) {
		case "CoinPrefab(Clone)":
			score += 3;
			// add coin to JackPot
			GameObject jackPot = GameObject.Find("JackPot");
			jackPot.SendMessage("addCoin", 3);
			break;
		case "7-Tip-Star 1(Clone)":
			GameObject gate = GameObject.Find("Gate");
			gate.SendMessage("toggleOpen");
			break;
		}
	}

	public void instantiateCoin(Vector3 pos, Quaternion rot, string type) {
		switch (type) {
		case "Coin":
			Instantiate (prefabCoin, pos, rot);
			break;
		case "BonusCoin":
			Instantiate (prefabBonusCoin, pos, rot);
			break;
		}
	}

	public void spawnCoin() {
		if (score <= 0)
			return;
		score--;

		// spawn coin
		float halfWidth = Screen.width * 0.5f;
		float dist = (Input.mousePosition.x - halfWidth) * 0.01f;
		Vector3 spawnPos = spawner.transform.position;
		spawnPos.x += dist;

		instantiateCoin (spawnPos, transform.rotation, "Coin");
	}

	private void onGameOver() {
		gameOver.SetActive (true);
		directionalLight.SetActive (false);
		spawner.SendMessage ("onGameOver");
	}

	private void createRandomCoin(GameObject target) {
		Vector3 dist = target.transform.localScale * 0.5f;
//		float distX = target.transform.localScale.x * 0.5f;
//		float distY = target.transform.localScale.y * 0.5f;
//		float distZ = target.transform.localScale.z * 0.5f; 
		Vector3 initPos = new Vector3 (
			target.transform.position.x + Random.Range (-dist.x, dist.x), 
			target.transform.position.y + dist.y + 0.2f, 
			target.transform.position.z + Random.Range (-dist.z, dist.z * .1f)); 
		if (Random.Range(0f, 1f) > 0.9f)
			instantiateCoin (initPos, transform.rotation, "BonusCoin");
		else
			instantiateCoin (initPos, transform.rotation, "Coin");
	}
}
