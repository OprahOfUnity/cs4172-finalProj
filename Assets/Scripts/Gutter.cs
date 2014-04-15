using UnityEngine;
using System.Collections;

public class Gutter : MonoBehaviour {

	Vector3 startPos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log (other);
		//		Destroy (GameObject.Find("Cylinder"));
		if (other.gameObject.tag == "Gutter") {
			//			other.gameObject.SetActive (false);
			Debug.Log("hit gutter.");
			other.transform.position = startPos;
		}
	}
}
