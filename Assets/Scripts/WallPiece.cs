using UnityEngine;
using System.Collections;

public class WallPiece : MonoBehaviour {

	float destroyTime = 5.0f;
	public static bool destroy = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		//
		if(destroy) {
			Destroy(gameObject, destroyTime);
		}
	}
}
