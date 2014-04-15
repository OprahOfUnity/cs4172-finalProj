using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	Vector3 startPos;

	// Use this for initialization
	void Start () {

		startPos = transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) == true) {
			rigidbody.useGravity = true;
		}
	}

	// if ball collides with pin
	// add gravity to pin
	// gameObject.attachedRigidbody.useGravity = false;
	void OnTriggerEnter(Collider other) {
		Debug.Log (other);
//		Destroy (GameObject.Find("Cylinder"));
		if (other.gameObject.tag == "Pin") {
//			other.gameObject.SetActive (false);
			other.rigidbody.useGravity = true;
		}

		if (other.gameObject.tag == "Gutter") {
			//			other.gameObject.SetActive (false);
			Debug.Log("hit gutter.");
			rigidbody.useGravity = false;
			transform.position = startPos;
			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;
		}
	}
}
