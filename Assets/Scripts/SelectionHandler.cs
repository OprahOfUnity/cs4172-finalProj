using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectionHandler : MonoBehaviour {

	public Transform selectedObject = null;
	private GUIStyle cameraStyle;
	private bool isTranslating = false;
	private bool isRotating = false;

	private GameObject world;
	private GameObject wand;

	public bool hasAttachedObject;

	void Start () {
		world = GameObject.Find("CylinderTarget");
    wand = GameObject.Find("Wand");
    hasAttachedObject = false;
	}

	void Update () {
		OnTouchDown ();
	}

	void OnTouchDown () {
		foreach (Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved) {
				Ray ray = Camera.main.ScreenPointToRay(touch.position);
				RaycastHit hit ;
				if (Physics.Raycast (ray, out hit)) {
					if (Physics.Raycast (ray, out hit) && GUIUtility.hotControl == 0 && selectedObject) {
						Deselect ();
					}
					if (hit.transform.tag == "footsoldiers" || hit.transform.tag == "trebuchet") {
						Select (hit.transform);
					}
				}
			}
		}
	}

	void Select (Transform hit) {
		selectedObject = hit.transform;
		Debug.Log("Selected Object = " + selectedObject.name);
	}

  void Deselect () {
    Debug.Log("Deselected Object = " + selectedObject.name);
    selectedObject = null;
  }

	void RemoveSelectedObjectFromWorld () {
		foreach (Transform child in world.transform) {
			if (child.gameObject.GetInstanceID() == selectedObject.gameObject.GetInstanceID()) {
			    GameObject.Destroy(child.gameObject);
			}
		}
	}

}
