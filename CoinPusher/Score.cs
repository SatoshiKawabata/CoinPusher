using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public static int score;

	// Use this for initialization
	void Start () {
		score = 30;
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<GUIText> ().text = score.ToString();
	}
}
