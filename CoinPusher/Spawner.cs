using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	private GameObject manager;
	private bool isGameOver;

	// Use this for initialization
	void Start () {
		isGameOver = false;
		manager = GameObject.Find ("GameManager");

	}
	
	// Update is called once per frame
	void Update () {
		if (! isGameOver
		    && Input.GetButtonDown ("Fire1")) { 
			// send spawn coin
			manager.SendMessage("spawnCoin");
		}
	}

	public void onGameOver() {
		isGameOver = true;
	}
}
