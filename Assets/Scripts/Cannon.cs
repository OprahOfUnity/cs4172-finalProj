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

		// Code for OnMouseDown in the iPhone. Unquote to test.
//		RaycastHit hit = new RaycastHit();
//		for (int i = 0; i < Input.touchCount; ++i) {
//			if (Input.GetTouch(i).phase.Equals(TouchPhase.Began)) {
//				// Construct a ray from the current touch coordinates
//				Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
//				if (Physics.Raycast(ray, out hit)) {
//					hit.transform.gameObject.SendMessage("OnMouseDown");
//					// cannon stuff
//					Rigidbody cannonballInstance;
//					cannonballInstance = Instantiate(prefab, cannonEnd.position, cannonEnd.rotation) as Rigidbody;
//					cannonballInstance.AddForce(cannonEnd.forward * 5000);
//				}
//			}
//		}

		if (Input.GetKeyDown(KeyCode.Space) == true) {
			Rigidbody cannonballInstance;
			cannonballInstance = Instantiate(prefab, cannonEnd.position, cannonEnd.rotation) as Rigidbody;
			cannonballInstance.AddForce(cannonEnd.forward * 5000);
		}
	
	}
}
