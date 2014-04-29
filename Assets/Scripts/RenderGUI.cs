using UnityEngine;
using System.Collections;

public class RenderGUI : MonoBehaviour {

	private GUIStyle cameraStyle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnGUI () {

		GUI.skin.label.fontSize = 30;
		cameraStyle = new GUIStyle(GUI.skin.button);
		cameraStyle.fontSize = 30;

		if (GUI.Button (new Rect (10, 20, 280, 120), "Toggle moveSoldiers", cameraStyle)) {
			GameObject footsoldiers = GameObject.FindGameObjectWithTag("footsoldiers");
			footsoldiers.GetComponent<SoldierMovement> ().setMoveSoldiers ();
		}
	}
}
