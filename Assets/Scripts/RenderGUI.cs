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

    if (GUI.Button (new Rect (Screen.width - 120, Screen.height - 120, 100, 100), "X", cameraStyle)) {
      Application.LoadLevel(0);
    }

		if (GUI.Button (new Rect (20, 20, 280, 120), "Move Soldiers", cameraStyle)) {
			GameObject footsoldiers = GameObject.FindGameObjectWithTag("footsoldiers");
			footsoldiers.GetComponent<SoldierMovement> ().setMoveSoldiers ();
		}

		if (GUI.Button (new Rect (20, 150, 280, 120), "Waypoint Mode", cameraStyle)) {
			// waypoint toggle bool
			SetWaypoint.toggleWaypointMode = !SetWaypoint.toggleWaypointMode;
		}

		if (hasSpawnedObject){
			if (GUI.Button (new Rect (20, 280, 280, 120), "Drop Object", cameraStyle)) {
				SetSpawnedObject.toggleSetSpawnedObject = !SetSpawnedObject.toggleSetSpawnedObject;
			}
		}
	}
}
