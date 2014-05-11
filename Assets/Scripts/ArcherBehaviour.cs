using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArcherBehaviour : MonoBehaviour {

	public GameObject world;
	private GameObject currentTarget;
//	public Queue<GameObject> q;
	public List<GameObject> list;
	GameObject[] gos;
	
	// fire arrows
	public Rigidbody arrow;
	public Transform archerEnd;

	private float threatDistance;
	private int threatIndex;
	
	// Use this for initialization
	void Start () {
		currentTarget = null;
		list = new List<GameObject> ();
		threatDistance = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		setCurrentTarget();

		if (currentTarget) {
			float damping = 1.0f;
			Transform target = currentTarget.transform;
			Vector3 lookPos = target.position - this.transform.position;
			lookPos.y = 0;
			Quaternion rotation = Quaternion.LookRotation(lookPos);
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, Time.deltaTime * damping);
		}
		
		// readyToFire == true
		if (threatDistance < 8.0f) {
			Rigidbody arrowInstance;
			arrowInstance = Instantiate(arrow, archerEnd.position, archerEnd.rotation) as Rigidbody;

			Vector3 lookPosition = new Vector3(currentTarget.transform.position.x, currentTarget.transform.position.y + 0.5f, currentTarget.transform.position.z);

			arrowInstance.transform.LookAt(lookPosition);
			arrowInstance.rigidbody.AddForce(arrowInstance.transform.forward * 1000.0f);

			removeDestroyedTarget();
			removeWaypoints();
		}
	}

	private void removeDestroyedTarget () {
		list.RemoveAt (threatIndex);
	}

	private void removeWaypoints () {
		GameObject[] gameObjects =  GameObject.FindGameObjectsWithTag ("waypoint");
		
		foreach (GameObject child in gameObjects)
			Destroy(child);
	}
	
	public void addNewTarget(string targetTag) {
		gos = GameObject.FindGameObjectsWithTag (targetTag);
		foreach (GameObject go in gos) {
			if (!list.Contains(go)) {
				list.Add(go);
			}
		}
	}
	
	void setCurrentTarget() {
		float minDistance = 100.0f;
		float currentDistance = 0.0f;
		int minDistanceIndex = 0;

		for (int i = 0; i < list.Count; i++){
			currentDistance = Vector3.Distance (list[i].transform.position, this.transform.position);
			if (currentDistance < minDistance) {
				minDistance = currentDistance;
				minDistanceIndex = i;
			}
		}

		currentTarget = list[minDistanceIndex];
		threatDistance = minDistance;
		threatIndex = minDistanceIndex;

	}
}