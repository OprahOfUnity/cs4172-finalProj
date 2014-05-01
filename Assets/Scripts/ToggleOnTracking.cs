using UnityEngine;
using System.Collections;

public class ToggleOnTracking : MonoBehaviour {

	CylinderTargetBehaviour ctb;

	// Use this for initialization
	void Start () {
		ctb = this.GetComponent<CylinderTargetBehaviour>();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (ctb.CurrentStatus == TrackableBehaviour.Status.UNKNOWN) {
			Debug.Log("lost trackable, setting gameObject to false");
			// enable is kinematic here?
			transform.Find("Parent").gameObject.SetActive(false);
		} else {
//			Debug.Log("gameObject should be active");
			transform.Find("Parent").gameObject.SetActive(true);
		}
	
	}
}
