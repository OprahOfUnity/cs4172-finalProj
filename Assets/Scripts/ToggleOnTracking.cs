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
			transform.Find("Parent").gameObject.SetActive(false);
		} else {
			transform.Find("Parent").gameObject.SetActive(true);
		}
	
	}
}
