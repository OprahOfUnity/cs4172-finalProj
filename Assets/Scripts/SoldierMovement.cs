using UnityEngine;
using System.Collections.Generic;
//using System.Collections;

public class SoldierMovement : MonoBehaviour {

	private GameObject currentWayPoint;
	public Queue<GameObject> q;
	GameObject[] gos;

	// Use this for initialization
	void Start () {
		currentWayPoint = null;
		q = new Queue<GameObject>();
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

		Debug.Log (q.ToString());
		Debug.Log (q.Count);

		if (currentWayPoint) {
			Vector3 wpPos = currentWayPoint.transform.position;
			wpPos.y = 5;//adjusted for realistic soldier movement
			transform.LookAt (wpPos);
			transform.position = Vector3.MoveTowards (transform.position, wpPos, 0.70f);
		} else {
			setCurrentWayPoint();
		}
	}

	void setCurrentWayPoint() {
		if (q.Count != 0) {
			currentWayPoint = q.Dequeue ();
		}
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("collision!");

		if (other.gameObject.tag == "waypoint") {
			Debug.Log (other);
			other.gameObject.SetActive(false);
			//	Object.Destroy (other);
			currentWayPoint = null;
		}
	}
}
