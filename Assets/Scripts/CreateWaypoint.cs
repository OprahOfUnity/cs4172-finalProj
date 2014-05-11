using UnityEngine;
using System.Collections;

public class CreateWaypoint : MonoBehaviour {
	
	bool added;
	// Use this for initialization
	void Start () {
		added = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!added) {
			GameObject footsoldiers = GameObject.FindGameObjectWithTag("footsoldiers");
			if (footsoldiers) {
				footsoldiers.GetComponent<SoldierMovement> ().addNewWayPoint ();
				//				footsoldiers.GetComponent<DebugMovement> ().addNewWayPoint ();
			}
			added = true;
		}
		
	}
}