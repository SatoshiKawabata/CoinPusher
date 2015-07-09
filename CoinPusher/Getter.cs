using UnityEngine;
using System.Collections;

public class Getter : MonoBehaviour {

	private GameObject manager;
	// Use this for initialization
	void Start () {
		manager = GameObject.Find ("GameManager");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		manager.SendMessage ("getCoin", other);
		Destroy(other.gameObject);
	}
}
