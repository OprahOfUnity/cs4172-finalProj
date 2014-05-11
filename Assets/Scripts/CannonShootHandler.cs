using UnityEngine;
using System.Collections;

public class CannonShootHandler : MonoBehaviour {
	public GameObject cannonball;
	public float fireRate = 0.5f;
	public float ballSpeed = 2.0f;

	private float fireDelay;
	public static bool toggleShooting = false;

	private SelectionHandler handler;


	// Use this for initialization
	void Start () {
		handler = this.GetComponent <SelectionHandler> ();
	}

	// Update is called once per frame
	void LateUpdate () {
		if (toggleShooting) {
			shootCannonball ();
		}
	}

	void shootCannonball () {
		fireDelay = Time.deltaTime + fireRate;
		GameObject clone = (GameObject)Instantiate (cannonball, handler.selectedObject.transform.position, handler.selectedObject.transform.rotation);
		clone.AddComponent<Rigidbody>();
		clone.AddComponent<SphereCollider>();
		clone.transform.tag = "cannonball";
		clone.transform.localScale = new Vector3 (2.0f, 2.0f, 2.0f);
		Vector3 direction = new Vector3 (0, ballSpeed, 0);
		clone.rigidbody.velocity = handler.selectedObject.transform.TransformDirection (direction);
		Physics.IgnoreCollision (clone.transform.collider, handler.selectedObject.transform.collider);
	}
}
