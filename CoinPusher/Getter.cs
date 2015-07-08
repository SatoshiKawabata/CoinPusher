using UnityEngine;
using System.Collections;

public class Getter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		Score.score += 3;
		Destroy(other.gameObject);
	}
}
