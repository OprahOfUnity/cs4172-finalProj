using UnityEngine;
using System.Collections;

public class SetWaypoint : MonoBehaviour {

	public Rigidbody waypoint;
	public static bool toggleWaypointMode = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
	
		if(toggleWaypointMode) {
			RaycastHit hit = new RaycastHit();
			for (int i = 0; i < Input.touchCount; ++i) {
				if (Input.GetTouch(i).phase.Equals(TouchPhase.Began)) {
					// Construct a ray from the current touch coordinates
					Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
					if (Physics.Raycast(ray, out hit)) {
						hit.transform.gameObject.SendMessage("OnMouseDown");
						// place waypoint
						Rigidbody waypointInstance;
						Debug.Log("instantiating waypoint");
						waypointInstance = Instantiate(waypoint, hit.point, transform.rotation) as Rigidbody;
//					cannonballInstance.AddForce(cannonEnd.forward * 5000);
						
						// fix size of cylinder
						// reparent to cylinder targer
						
						// reparent
						Debug.Log("reparenting...");
						waypointInstance.transform.parent = GameObject.Find("CylinderTarget").transform;
//						Debug.Log (this.transform.parent);
						
						// scale
						Debug.Log("scaling");
//						Debug.Log(this.transform.localScale);
						waypointInstance.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
//						Debug.Log(this.transform.localScale);
						
						// move up 0.25f unitx
						waypointInstance.transform.position = new Vector3(waypointInstance.transform.position.x, 1.0f, waypointInstance.transform.position.z);
						
						// adjust rotation, make it vertical
						waypointInstance.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
					}
				}
			}
		}
	}
}
