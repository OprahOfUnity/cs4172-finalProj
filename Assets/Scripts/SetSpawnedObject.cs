using UnityEngine;
using System.Collections;

public class SetSpawnedObject : MonoBehaviour {

	public Transform world;
	private Transform wand;
	private Transform spawnedObject;

	public static bool toggleSetSpawnedObject = false;

	void Start () {
		/*world = GameObject.Find("SceneObjects").transform;*/
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

		if (spawnedObject.tag == "footsoldiers") {
			spawnedObject.localScale = new Vector3(1.5f, 1.5f, 1.5f);
			spawnedObject.gameObject.AddComponent<Rigidbody>();
//			spawnedObject.gameObject.GetComponent<Rigidbody>().useGravity = false;
			spawnedObject.gameObject.AddComponent("SoldierMovement");
			spawnedObject.position = new Vector3 (spawnedObject.position.x, world.position.y, spawnedObject.position.z);
		}

		if (spawnedObject.tag == "trebuchet") {
			spawnedObject.localScale = new Vector3(1.3f, 1.3f, 1.3f);
			spawnedObject.position = new Vector3 (spawnedObject.position.x, world.position.y + 0.7f, spawnedObject.position.z);
		}

		Quaternion temp = spawnedObject.gameObject.transform.rotation;
		temp.y = 0.0f;
		spawnedObject.gameObject.transform.rotation = temp;
	}

}
