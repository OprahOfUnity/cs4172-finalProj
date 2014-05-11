using UnityEngine;
using System.Collections;

public class DestroyWall : MonoBehaviour {

	public GameObject myArcher;

	int count;

	// Use this for initialization
	void Start () {

		count = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onCollisionEnter (Collider other) {
		if (other.gameObject.tag == "cannonball") {
			if(count == 1) {
				Destroy(other);
				if (myArcher) {
					GameObject.Destroy(myArcher); 
				}
			}
			count++;
		}
	}
}
