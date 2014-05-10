using UnityEngine;
using System.Collections;

public class VirtualButtonEventHandler : MonoBehaviour, IVirtualButtonEventHandler {
	private GameObject toolbar;
	private GameObject wand;

	public GameObject cannon;
	public GameObject soldier;

	public bool hasSpawnedObject;

	void Start () {
		toolbar = this.gameObject;
    	wand = GameObject.Find("Wand");
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
		        clone.gameObject.tag = "trebuchet";
  				AttachObjectToWand(clone, "Trebuchet");
  				break;
  			case "btnSpawnSoldier":
  				clone = (GameObject)Instantiate(soldier);
	      		clone.gameObject.tag = "footsoldiers";
  				AttachObjectToWand(clone, "Soldier");
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

	private void RemoveObjectsFromWand() {
	    for (int i = 0; i < wand.transform.GetChildCount(); i++)
	    {
	      Transform child = wand.transform.GetChild(i);
	      child.gameObject.active = false;
	    }
	}


	void AttachObjectToWand(GameObject obj, string type) {
		obj.transform.parent = wand.transform;
    	obj.transform.localPosition = new Vector3 (0.0f, 0.0f, 0.0f);
		obj.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);

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

}
