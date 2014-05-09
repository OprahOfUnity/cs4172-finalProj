using UnityEngine;
using System.Collections;

public class VirtualButtonEventHandler : MonoBehaviour, IVirtualButtonEventHandler {
	private GameObject toolbar;

  public GameObject cannon;
  public GameObject soldier;

	public bool hasSpawnedObject;

	void Start () {
		toolbar = this.gameObject;
		hasSpawnedObject = false;

		VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();

		foreach (VirtualButtonBehaviour item in vbs) {
			item.RegisterEventHandler(this);
		}
	}

	void Update () {

	}

	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb) {
		Debug.Log("Pressed: " + vb.name);
		if (!hasSpawnedObject) {
			GameObject clone;
			hasSpawnedObject = true;

			switch (vb.name) {
  			case "btnSpawnTrebuchet":
  				clone = (GameObject)Instantiate(cannon);
		        clone.tag = "trebuchet";
  				AttachObjectToToolbar(clone, "Trebuchet");
  				break;
  			case "btnSpawnSoldier":
  				clone = (GameObject)Instantiate(soldier);
          		clone.tag = "footsoldiers";
  				AttachObjectToToolbar(clone, "Soldier");
  				break;
  			default:
  				Debug.Log ("Invalid Button");
  				break;
			}
		}
	}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb) {
		Debug.Log("Released: " + vb.name);
	}

	private void RemoveObjectsFromToolbar() {
		for (int i = 0; i < toolbar.transform.GetChildCount(); i++)
		{
			Transform child = toolbar.transform.GetChild(i);
			child.gameObject.active = false;
		}
	}

	void AttachObjectToToolbar(GameObject obj, string type) {
		obj.transform.parent = toolbar.transform;
	    obj.transform.localPosition = new Vector3 (0.0f, 0.0f, 0.18f);
		obj.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

		switch (type) {
  		case "Trebuchet":
        obj.transform.localRotation = Quaternion.Euler(270, 180, 0);
  			obj.AddComponent<BoxCollider>();
  			break;
  		case "Soldier":
        obj.transform.localRotation = Quaternion.Euler(0, 0, 0);
  			obj.AddComponent<BoxCollider>();
  			break;
  		default:
  			Debug.Log ("Undefined Collider Type");
  			break;
		}
		obj.SetActive(true);
	}

	public void OnGUI() {
		if (hasSpawnedObject) {

		}
	}

}
