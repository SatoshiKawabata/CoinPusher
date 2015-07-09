using UnityEngine;
using System.Collections;

public class Pusher : MonoBehaviour {
	float count;
	Vector3 origin;
	// Use this for initialization
	void Start () {
	
	}

	void Awake() {
		origin = GetComponent<Rigidbody>().position; 
	}

	// Update is called once per frame
	void Update () {
		count += 0.02f;
		float offset = Mathf.Sin (count);
		Vector3 offsetPos = new Vector3 (0, 0, offset);

		GetComponent<Rigidbody>().MovePosition(origin + offsetPos);
	}
}
