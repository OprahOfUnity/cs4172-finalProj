using UnityEngine;
using System.Collections.Generic;
//using System.Collections;

public class SoldierMovement : MonoBehaviour {
	
	public bool moveSoldiers;
	private GameObject currentWayPoint;
	public Queue<GameObject> q;
	GameObject[] gos;
	
	// Use this for initialization
	void Start () {
		currentWayPoint = null;
		q = new Queue<GameObject>();
		moveSoldiers = false;
	}

	public void addNewWayPoint() {
		Debug.Log ("new waypoint on scene");
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
		Debug.Log ("currentWayPoint != null: " + (currentWayPoint != null) + "\nMove Soldiers: " + moveSoldiers);
		
		if (currentWayPoint != null && moveSoldiers) {
			Vector3 wpPos = currentWayPoint.transform.position;
			wpPos.y = 0.125f;//adjusted for realistic soldier movement
			transform.LookAt (wpPos);
			transform.position = Vector3.MoveTowards (transform.position, wpPos, 0.1f);
		} else if (currentWayPoint == null && moveSoldiers) {
			//			Debug.Log ("setcurrentway: " + currentWayPoint);
			setCurrentWayPoint();
		}
		this.gameObject.transform.rotation = Quaternion.Euler(0.0f, this.gameObject.transform.rotation.eulerAngles.y, this.gameObject.transform.rotation.eulerAngles.z); 
	}
	
	void setCurrentWayPoint() {
		if (q.Count != 0) {
			//			Debug.Log ("queue not empty");
			currentWayPoint = q.Dequeue ();
			Debug.Log(q.Count);
		} else {
			moveSoldiers = false;
			Debug.Log ("X Rotation: " + this.gameObject.transform.rotation.x);
//			this.gameObject.rigidbody.constraints = RigidbodyConstraints.FreezeRotationX;
		}
	}
	
	void OnTriggerEnter(Collider other) {
		Debug.Log ("collision!");
		
		if (other.gameObject.name == "Goal") {
			Debug.Log("hit goal");
			other.gameObject.SetActive(false);
		}
		
		if (other.gameObject.tag == "waypoint" && other.gameObject.Equals (currentWayPoint)) {
			Debug.Log (other);
			other.gameObject.SetActive(false);
			//			Destroy (other);
			//	Object.Destroy (other);
			currentWayPoint = null;
		}

		if (other.gameObject.tag == "goal") {
			Debug.Log("hit goal");
			this.gameObject.SetActive(false);
			RenderGUI.renderWin = true;
		}

	}
	
	public void setMoveSoldiers (bool val) {
		Debug.Log ("About to move soldiers..");
		// this works only for one at a time.
		moveSoldiers = val;
	}

	public void notifyArchers() {
		Debug.Log ("Notifying Archers..");
		GameObject[] archers = GameObject.FindGameObjectsWithTag ("archers");
		foreach(GameObject archer in archers) {
			if (archer) {
				archer.GetComponent<ArcherBehaviour> ().addNewTarget("footsoldiers");
			}
		}
	}
}