using UnityEngine;
using System.Collections.Generic;
//using System.Collections;

public class SoldierMovement : MonoBehaviour {

	public static bool moveSoldiers;

	private GameObject currentWayPoint;
	public Queue<GameObject> q;
	GameObject[] gos;

	bool added;

	// Use this for initialization
	void Start () {
		currentWayPoint = null;
		q = new Queue<GameObject>();

		added = false;
	}

	public void addNewWayPoint() {
		gos = GameObject.FindGameObjectsWithTag ("waypoint");
		foreach (GameObject go in gos) {
			if (!q.Contains(go)) {
				q.Enqueue(go);
			}
		}
	}

	// Update is called once per frame
	void Update () {

//		Debug.Log (q.ToString());
//		Debug.Log (q.Count);
//
//		Debug.Log (currentWayPoint);
//		Debug.Log (moveSoldiers);


		if (currentWayPoint != null && moveSoldiers) {
			Vector3 wpPos = currentWayPoint.transform.position;
			wpPos.y = 5;//adjusted for realistic soldier movement
			transform.LookAt (wpPos);
			transform.position = Vector3.MoveTowards (transform.position, wpPos, 0.70f);
		} else if (currentWayPoint == null && moveSoldiers) {
//			Debug.Log ("setcurrentway: " + currentWayPoint);
			setCurrentWayPoint();
		}
	}

	void setCurrentWayPoint() {
		if (q.Count != 0) {
//			Debug.Log ("queue not empty");
			currentWayPoint = q.Dequeue ();
		} else {
			moveSoldiers = false;
		}
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("collision!");

		if (other.gameObject.tag == "waypoint") {
			Debug.Log (other);
			other.gameObject.SetActive(false);
//			Destroy (other);
			//	Object.Destroy (other);
			currentWayPoint = null;
		}
	}

	public void setMoveSoldiers () {
		// this works only for one at a time.
		moveSoldiers = !moveSoldiers;
	}
}
