using UnityEngine;
using System.Collections;

public class CannonBall : MonoBehaviour {

	bool fire = true;

	// Use this for initialization
	void Start () {
//		rigidbody.AddForce (new Vector3 (5.0f, 5.0f, 0.0f));
	}
	
	// Update is called once per frame
	void Update () {
		while (fire) {
			rigidbody.AddForce (new Vector3 (25.0f, 25.0f, 0.0f));
		}
//		yield return new WaitForSeconds(5);
//		fire = false;
	}
}
