using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public Transform prefab;
	public GameObject floorBase;
	public GameObject floorPusher;

	// Use this for initialization
	void Start () {
		Debug.Log (floorBase.transform.localScale.x);

		for (int i = 0; i < 10; i++) {
			createRandomCoin (floorBase);
//			createRandomCoin (floorPusher);
		}
	}
	
	// Update is called once per frame
	void Update () {
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
		Instantiate (prefab, initPos, transform.rotation); 
	}
}
