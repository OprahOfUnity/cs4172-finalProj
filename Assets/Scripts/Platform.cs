using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

	float speed = 50;

	// Use this for initialization
	void Start () {
		Debug.Log ("start test");
	
	}

	void Update() {
//		Debug.Log ("update test");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
//		Debug.Log ("test");
		Debug.Log (GameObject.Find ("ARCamera").transform.rotation.y);

		// fix this, need to rotate the platform with camera
		// make child of camera?
		transform.Rotate(new Vector3 (0, GameObject.Find ("ARCamera").transform.rotation.y, 0));
	}
}
