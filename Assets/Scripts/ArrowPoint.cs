using UnityEngine;
using System.Collections;

public class ArrowPoint : MonoBehaviour {

	public static bool wall2 = false;
	public static bool wall3 = false;
	public static bool wall4 = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (wall2) {
			// 180 y rotation
			transform.Rotate(new Vector3 (0.0f, 180.0f, 0.0f));
		}
	
	}
}
