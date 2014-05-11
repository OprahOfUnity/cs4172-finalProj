using UnityEngine;
using System.Collections;

public class RenderGUI : MonoBehaviour {

	private GUIStyle cameraStyle;
	private GameObject toolbar;
	public GameObject world;
	private GameObject wand;

	private VirtualButtonEventHandler virtualButtonHandler;
	private SelectionHandler wandHandler;
	private bool hasSpawnedObject = false;
	private bool hasAttachedObjectToWand = false;
	private bool hasSoldiers = false;

	private bool hasShoot = false;

	// win GUI
	public static bool renderWin = false;
	// lose GUI
	public static bool renderLose = false;

	// Use this for initialization
	void Start () {
		toolbar = GameObject.Find ("Toolbar");
		wand = GameObject.Find ("Wand");
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
				Debug.Log ("Move Soldier Pushed..");
				footsoldiers.GetComponent<SoldierMovement> ().setMoveSoldiers (true);
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
				if (wandHandler.selectedObject.transform.tag == "footsoldiers") {
					wandHandler.selectedObject.gameObject.AddComponent<Rigidbody>();
					wandHandler.gameObject.AddComponent("SoldierMovement");
				}
				wandHandler.hasAttachedObject = !wandHandler.hasAttachedObject;
			}
		}

		if (wandHandler.selectedObject) {
			if (wandHandler.selectedObject.tag == "footsoldiers" && !hasAttachedObjectToWand) {
				if (GUI.Button (new Rect (20, 20, 280, 120), "Attach To Wand", cameraStyle)) {
					wandHandler.selectedObject.transform.parent = wand.transform;
					wandHandler.selectedObject.transform.localPosition = Vector3.zero;
					wandHandler.hasAttachedObject = !wandHandler.hasAttachedObject;
					Destroy(wandHandler.selectedObject.GetComponent<Rigidbody>());
					Destroy(wandHandler.selectedObject.GetComponent("SoldierMovement"));
				}
				if (GUI.Button (new Rect (20, 150, 280, 120), "Delete", cameraStyle)) {

				}
			}
			if (wandHandler.selectedObject.tag == "trebuchet" && !hasAttachedObjectToWand) {
				if (GUI.Button (new Rect (20, 20, 280, 120), "Attach To Wand", cameraStyle)) {
					wandHandler.selectedObject.transform.parent = wand.transform;
					wandHandler.selectedObject.transform.localPosition = new Vector3 (0.0f, 0.3f, 0.0f);
					wandHandler.hasAttachedObject = !wandHandler.hasAttachedObject;
				}

				if (GUI.Button (new Rect (20, 150, 280, 120), "Shoot", cameraStyle)) {
					hasShoot = true;
				}

				if (GUI.Button (new Rect (20, 280, 280, 120), "Delete", cameraStyle)) {
					
				}
			}
		}

		// Win
		if (renderWin) {
			Debug.Log("rendering win GUI...");
			
			GUI.Label(new Rect(Screen.width - 900, Screen.height - 800, 400, 400), "<color=white><size=100>You Win!</size></color>");
			
			if(GUI.Button(new Rect (Screen.width - 1100, Screen.height - 500, 280, 120), "<color=white><size=30>Play Again?</size></color>")) {
				
				Application.LoadLevel(1);
			}
			
			if(GUI.Button(new Rect (Screen.width - 800, Screen.height - 500, 280, 120), "<color=white><size=30>Quit</size></color>")) {
				
				Application.Quit();
			}
		}
		
		// Game Over
		if (renderLose) {
			Debug.Log("rendering win GUI...");
			
			GUI.Label(new Rect(Screen.width - 950, Screen.height - 800, 400, 400), "<color=white><size=100>Game Over!</size></color>");
			
			if(GUI.Button(new Rect (Screen.width - 1100, Screen.height - 500, 280, 120), "<color=white><size=30>Play Again?</size></color>")) {
				
				Application.LoadLevel(1);
			}
			//			
			if(GUI.Button(new Rect (Screen.width - 800, Screen.height - 500, 280, 120), "<color=white><size=30>Quit</size></color>")) {
				
				Application.Quit();
			}
		}
	}
}
