using UnityEngine;
using System.Collections;

public class CannonBehaviour : MonoBehaviour {

	public void notifyArchers() {
		Debug.Log ("Notifying Archers..");
		GameObject[] archers = GameObject.FindGameObjectsWithTag ("archers");
		foreach(GameObject archer in archers) {
			if (archer) {
				archer.GetComponent<ArcherBehaviour> ().addNewTarget("trebuchet");
			}
		}
	}
}
