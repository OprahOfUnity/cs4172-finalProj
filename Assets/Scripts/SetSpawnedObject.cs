using UnityEngine;
using System.Collections;

public class SetSpawnedObject : MonoBehaviour {

	private Transform world;
	private Transform wand;
	private Transform spawnedObject;

	public static bool toggleSetSpawnedObject = false;

	void Start () {
		world = GameObject.Find("CylinderTarget").transform;
		wand = GameObject.Find ("Wand").transform;
	}

	void LateUpdate(){
		if (toggleSetSpawnedObject) {
			this.setObjectToWorld();
//			this.printWorldObjects();
			toggleSetSpawnedObject = false;
		}
	}

	void printWorldObjects () {
		int soldiers = 0;
		int cannons = 0;
		foreach (Transform child in world.transform) {
			if (child.gameObject.tag == "trebuchet" ) {
				cannons++;
			}
			if (child.gameObject.tag == "footsoldiers") {
				soldiers++;
			}
		}

		Debug.Log ("Soldiers: " + soldiers + "\nCannons: " + cannons);
	}

	void setObjectToWorld () {
		foreach (Transform child in wand) {
			spawnedObject = child.transform;
		}
		spawnedObject.parent = world;
		spawnedObject.localScale = new Vector3(0.4f, 0.4f, 0.4f);
		spawnedObject.position = new Vector3 (spawnedObject.position.x, world.position.y, spawnedObject.position.z);
	}

}
