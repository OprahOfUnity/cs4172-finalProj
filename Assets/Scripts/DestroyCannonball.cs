using UnityEngine;
using System.Collections;

public class DestroyCannonball : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		// Destroy cannonball after 3 seconds
		Destroy (gameObject, 5.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log("hit anything");
		if (other.gameObject.tag == "trebuchet") {
			Debug.Log("hit trebuchet");
			Destroy (other.gameObject);
			Destroy (GameObject.Find("cannonEnd1"));
		}
	}
}
