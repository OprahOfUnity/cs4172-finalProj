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

	void OnCollisionEnter (Collision other) {
		Debug.Log ("Hit..");
		if (other.gameObject.tag == "cannonball") {
			Debug.Log ("Ball Collided with Wall..");
			if(count == 1) {
				if (myArcher) {
					GameObject.Destroy(myArcher); 
				}
				GameObject.Destroy(this.gameObject);
			}
			count++;
		}
	}
}
