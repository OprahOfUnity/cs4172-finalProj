using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour {

	public Rigidbody prefab;
	public Transform cannonEnd;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

//		transform.RotateAround(0, Input.GetAxis("Horizontal") * 10.0f * Time.deltaTime, 0);
		transform.RotateAround (Vector3.zero, Vector3.up, Input.GetAxis ("Horizontal") * -25.0f * Time.deltaTime);

		if (Input.GetKeyDown(KeyCode.Space) == true) {
			Rigidbody cannonballInstance;
			cannonballInstance = Instantiate(prefab, cannonEnd.position, cannonEnd.rotation) as Rigidbody;
			cannonballInstance.AddForce(cannonEnd.forward * 5000);
		}
	
	}
}
