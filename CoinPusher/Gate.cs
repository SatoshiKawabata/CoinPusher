using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour {

	private float originY;
	private float height;
	private bool open;

	// Use this for initialization
	void Start () {
		open = false;
		height = 4f;
		originY = GetComponent<Rigidbody>().position.y; 
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currentPos = GetComponent<Rigidbody> ().position;
		if (open) {
			if (originY + height > currentPos.y) {
				float offset = 0.05f;
				currentPos.Set (currentPos.x, currentPos.y + offset, currentPos.z);
				GetComponent<Rigidbody> ().MovePosition (currentPos);
			}
		} else {
			if (originY < currentPos.y) {
				float offset = -0.05f;
				currentPos.Set (currentPos.x, currentPos.y + offset, currentPos.z);
				GetComponent<Rigidbody> ().MovePosition (currentPos);
			}
		}
		if (originY + height <= currentPos.y) {
			open = false;
		}
	}

	public void toggleOpen() {
		open = !open;
	}
}
