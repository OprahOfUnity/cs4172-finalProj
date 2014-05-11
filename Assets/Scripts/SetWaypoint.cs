using UnityEngine;
using System.Collections;

public class SetWaypoint : MonoBehaviour {

	public GameObject waypoint;
	public GameObject world;

	public static bool toggleWaypointMode = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void LateUpdate () {
	
		if(toggleWaypointMode) {
			OnTouchDown();
		}
	}

	void OnTouchDown () {
		foreach (Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved) {
				Ray ray = Camera.main.ScreenPointToRay(touch.position);
				RaycastHit hit ;
				if (Physics.Raycast (ray, out hit)) {
					if (Physics.Raycast (ray, out hit) && GUIUtility.hotControl == 0) {
						if (hit.transform.name == "Plane") {
							GameObject waypointInstance;
							waypointInstance = Instantiate(waypoint, hit.point, transform.rotation) as GameObject;
							waypoint.transform.parent = world.transform;
							waypointInstance.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
							waypointInstance.transform.position = new Vector3(waypointInstance.transform.position.x, 1.0f, waypointInstance.transform.position.z);
							waypointInstance.transform.rotation = Quaternion.identity;
						}
					}
				}
			}
		}
	}
}
