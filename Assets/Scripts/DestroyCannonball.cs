using UnityEngine;
using System.Collections;

public class DestroyCannonball : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		// Destroy cannonball after 3 seconds
		Destroy (gameObject, 3.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
