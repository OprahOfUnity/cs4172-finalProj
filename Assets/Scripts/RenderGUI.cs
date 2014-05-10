using UnityEngine;
using System.Collections;

public class RenderGUI : MonoBehaviour {

	private GUIStyle cameraStyle;
	private GameObject toolbar;
	private GameObject world;

	private VirtualButtonEventHandler virtualButtonHandler;
	private SelectionHandler wandHandler;
	private bool hasSpawnedObject = false;
    private bool hasAttachedObjectToWand = false;
	private bool hasSoldiers = false;

	private bool hasShoot = false;

	// Use this for initialization
	void Start () {
		world = GameObject.Find ("CylinderTarget");
		toolbar = GameObject.Find ("Toolbar");
		virtualButtonHandler = toolbar.GetComponent <VirtualButtonEventHandler>();
		wandHandler = this.GetComponent <SelectionHandler> ();
	}

	// Update is called once per frame
	void Update () {
		hasSpawnedObject = virtualButtonHandler.hasSpawnedObject;
    	hasAttachedObjectToWand = wandHandler.hasAttachedObject;
		hasSoldiers = this.countWorldSoldiers ();


	}

	void LateUpdate () {
		if (hasShoot) {
			StartCoroutine(ShootOneCannonball());
			hasShoot = false;
		}
	}

	private bool countWorldSoldiers () {
		bool soldiers = false;
		foreach (Transform child in world.transform) {
			if (child.gameObject.tag == "footsoldiers") {
				soldiers = true;
				break;
			}
		}
		return soldiers;
	}

	private IEnumerator ShootOneCannonball() {
		Debug.Log ("Shooting..");
		CannonShootHandler.toggleShooting = true;
		Debug.Log ("Waiting..");
		yield return new WaitForSeconds(0.01f); 
		Debug.Log ("Stop..");
		CannonShootHandler.toggleShooting = false;
	}

	public void OnGUI () {

		GUI.skin.label.fontSize = 30;
		cameraStyle = new GUIStyle(GUI.skin.button);
		cameraStyle.fontSize = 30;

	    if (GUI.Button (new Rect (Screen.width - 120, Screen.height - 120, 100, 100), "X", cameraStyle)) {
	      Application.LoadLevel(0);
	    }

		if (hasSoldiers && !wandHandler.selectedObject) {
			if (GUI.Button (new Rect (20, 20, 280, 120), "Move Soldiers", cameraStyle)) {
				GameObject footsoldiers = GameObject.FindGameObjectWithTag("footsoldiers");
				footsoldiers.GetComponent<SoldierMovement> ().setMoveSoldiers ();
			}
			
			if (GUI.Button (new Rect (20, 150, 280, 120), "Waypoint Mode", cameraStyle)) {
				// waypoint toggle bool
				SetWaypoint.toggleWaypointMode = !SetWaypoint.toggleWaypointMode;
			}
		}

		if (hasSpawnedObject){
			if (GUI.Button (new Rect (20, 280, 280, 120), "Drop Object", cameraStyle)) {
				SetSpawnedObject.toggleSetSpawnedObject = !SetSpawnedObject.toggleSetSpawnedObject;
		        virtualButtonHandler.hasSpawnedObject = !virtualButtonHandler.hasSpawnedObject;
			}
		}

		if (hasAttachedObjectToWand) {
			if (GUI.Button (new Rect (20, 280, 280, 120), "Drop Object", cameraStyle)) {
				SetSpawnedObject.toggleSetSpawnedObject = !SetSpawnedObject.toggleSetSpawnedObject;
				wandHandler.hasAttachedObject = !wandHandler.hasAttachedObject;
			}
		}

		if (wandHandler.selectedObject) {
			if (wandHandler.selectedObject.tag == "footsoldiers") {
				if (GUI.Button (new Rect (20, 20, 280, 120), "Attach To Wand", cameraStyle)) {

				}
			}
			if (wandHandler.selectedObject.tag == "trebuchet") {
				if (GUI.Button (new Rect (20, 20, 280, 120), "Attach To Wand", cameraStyle)) {
					
				}
				
				if (GUI.Button (new Rect (20, 150, 280, 120), "Shoot", cameraStyle)) {
					hasShoot = true;
				}
			}
		}
	}
}
