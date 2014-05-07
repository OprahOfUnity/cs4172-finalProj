using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArcherBehaviour : MonoBehaviour {

	private GameObject currentTarget;
	public Queue<GameObject> q;
	GameObject[] gos;
	public string targetTag;

	// fire arrows
	bool readyToFire = true;
	public Rigidbody arrow;
	public Transform archerEnd;
	// hack
	int count;

	// Use this for initialization
	void Start () {
		currentTarget = null;
		q = new Queue<GameObject>();
		targetTag = "footsoldiers";
	}
	
	// Update is called once per frame
	void Update () {
		if (currentTarget) {
			Vector3 tarPos = currentTarget.transform.position;
			Quaternion neededRotation = Quaternion.LookRotation(tarPos - this.transform.position);
			Quaternion interpolatedRotation = Quaternion.Slerp(this.transform.rotation, neededRotation, Time.deltaTime * .01f);

			this.transform.rotation = interpolatedRotation;
			//			wpPos.y = 5;//adjusted for realistic soldier movement
//			transform.LookAt (wpPos);
//			transform.position = Vector3.MoveTowards (transform.position, wpPos, 0.10f);
		} else {
			setCurrentTarget();
		}

		count++;

		// readyToFire == true
		if(count % 100 == 0) {
//			Debug.Log ("fire");
			Rigidbody arrowInstance;
			arrowInstance = Instantiate(arrow, archerEnd.position, archerEnd.rotation) as Rigidbody;
			arrowInstance.AddForce(archerEnd.forward * 500);
//			readyToFire = false;
		}
//		StartCoroutine ("WaitToFireAgain");
	}

	public void addNewTarget() {
		gos = GameObject.FindGameObjectsWithTag (targetTag);
		foreach (GameObject go in gos) {
			if (!q.Contains(go)) {
				q.Enqueue(go);
			}
		}
	}

	void setCurrentTarget() {
		if (q.Count != 0) {
			currentTarget = q.Dequeue ();
		}
	}

//	IEnumerator WaitToFireAgain() {
//		readyToFire = false;
//		Debug.Log ("reachable");
//		yield return new WaitForSeconds (5);
//		readyToFire = true;
//	}
}
