using UnityEngine;
using System.Collections;

public class RenderGUI : MonoBehaviour {

	private GUIStyle cameraStyle;
	private GameObject toolbar;
	private VirtualButtonEventHandler handler;
	private bool hasSpawnedObject = false;

	// Use this for initialization
	void Start () {
		toolbar = GameObject.Find ("Toolbar");
		handler = toolbar.GetComponent <VirtualButtonEventHandler>();
	}
	
	// Update is called once per frame
	void Update () {
		hasSpawnedObject = handler.hasSpawnedObject;
	}

	public void OnGUI () {

		GUI.skin.label.fontSize = 30;
		cameraStyle = new GUIStyle(GUI.skin.button);
		cameraStyle.fontSize = 30;

		if (GUI.Button (new Rect (10, 20, 280, 120), "Toggle moveSoldiers", cameraStyle)) {
			GameObject footsoldiers = GameObject.FindGameObjectWithTag("footsoldiers");
			footsoldiers.GetComponent<SoldierMovement> ().setMoveSoldiers ();
		}

		if (GUI.Button (new Rect (10, 150, 280, 120), "Toggle Waypoint Mode", cameraStyle)) {
			// waypoint toggle bool
			SetWaypoint.toggleWaypointMode = !SetWaypoint.toggleWaypointMode;
		}
		if (hasSpawnedObject){
			if (GUI.Button (new Rect (10, 280, 280, 120), "Reparent Toolbar Obj", cameraStyle)) {
				SetSpawnedObject.toggleSetSpawnedObject = !SetSpawnedObject.toggleSetSpawnedObject;
			}
		}
	}
}
