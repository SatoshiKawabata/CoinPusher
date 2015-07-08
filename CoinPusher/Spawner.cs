using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public Transform prefab;

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1") 
		    && Score.score > 0) { 
			float halfWidth = Screen.width * 0.5f;
			float dist = (Input.mousePosition.x - halfWidth) * 0.01f;
			Vector3 spawnPos = transform.position;
			spawnPos.x += dist;
			Instantiate(prefab, spawnPos, transform.rotation);

			Score.score--;
		}
	}
}
