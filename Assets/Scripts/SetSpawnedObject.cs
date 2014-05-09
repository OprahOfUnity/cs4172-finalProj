﻿using UnityEngine;
using System.Collections;

public class SetSpawnedObject : MonoBehaviour {

	private Transform world;
	private Transform toolbar;
	private Transform spawnedObject;

	public static bool toggleSetSpawnedObject = false;

	void Start () {
		world = GameObject.Find("CylinderTarget").transform;
		toolbar = GameObject.Find ("Toolbar").transform;
	}

	void LateUpdate(){
		if (toggleSetSpawnedObject) {
			this.setObjectToWorld();
			toggleSetSpawnedObject = false;
		}
	}

	void setObjectToWorld () {
		foreach (Transform child in toolbar) {
			spawnedObject = child.transform;
		}

		Debug.Log ("OBJECT BEFORE REPARENTING:\n" +
						"parent: " + spawnedObject.parent +
						"localPosition: " + spawnedObject.localPosition +
						"position: " + spawnedObject.position +
						"localScale: " + spawnedObject.localScale +
						"rotation: " + spawnedObject.localPosition);
		spawnedObject.parent = world;
		spawnedObject.localScale = new Vector3(0.25f, 0.25f, 0.25f);
		spawnedObject.position = new Vector3 (spawnedObject.position.x, world.position.y + 0.25f, spawnedObject.position.z);
		spawnedObject.rotation = Quaternion.identity;

		Debug.Log ("OBJECT AFTER REPARENTING:\n" +
		           "parent: " + spawnedObject.parent +
		           "localPosition: " + spawnedObject.localPosition +
		           "position: " + spawnedObject.position +
		           "localScale: " + spawnedObject.localScale +
		           "rotation: " + spawnedObject.localPosition);

	}
	

}