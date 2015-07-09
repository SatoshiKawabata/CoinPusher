using UnityEngine;
using System.Collections;

public class JackPot : MonoBehaviour {

	private GameObject spawner;

	// Use this for initialization
	void Start () {
		spawner = GameObject.Find ("JackPotSpawner");
		addCoin (50);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void createRandomCoin(GameObject target) {
		Vector3 initPos = new Vector3 (
			target.transform.position.x + Random.Range (-2.5f, 2.5f), 
			target.transform.position.y + Random.Range (-1f, 1f), 
			target.transform.position.z + Random.Range (-1f, 1f)); 

		string type;
		if (Random.Range(0f, 1f) > 0.9f)
			type = "BonusCoin";
		else
			type = "Coin";
		GameObject manager = GameObject.Find ("GameManager");

		GameManager managerScript = manager.GetComponent<GameManager> ();
		managerScript.instantiateCoin (initPos, transform.rotation, type);
	}

	public void addCoin(int num) {
		for (int i = 0; i < num; i++) {
			createRandomCoin (spawner);
		}
	}
}
