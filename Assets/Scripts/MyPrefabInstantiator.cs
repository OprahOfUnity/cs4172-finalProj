using UnityEngine;
using System.Collections;

// https://developer.vuforia.com/forum/faq/unity-how-can-i-dynamically-attach-my-3d-model-image-target

public class MyPrefabInstantiator : MonoBehaviour, ITrackableEventHandler {
	
	private TrackableBehaviour mTrackableBehaviour;
	
	public Transform myModelPrefab;
	
	// Use this for initialization
	void Start ()
	{
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
	}               
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	public void OnTrackableStateChanged(
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
		    newStatus == TrackableBehaviour.Status.TRACKED)
		{
			OnTrackingFound();
		}
	}
	private void OnTrackingFound()
	{
		if (myModelPrefab != null) {

			// change this
			// need to clone an object, and keep track of the number of clones
			Transform myModelTrf = GameObject.Instantiate(myModelPrefab) as Transform;
			
			myModelTrf.parent = mTrackableBehaviour.transform;             
			myModelTrf.localPosition = new Vector3(0f, 0f, 0f);
			myModelTrf.localRotation = Quaternion.identity;
			myModelTrf.localScale = new Vector3(0.5f, 0.5f, 0.5f);
			
			// Warning CS0618: `UnityEngine.GameObject.active' is obsolete: `GameObject.active is obsolete.
			// Use GameObject.SetActive(), GameObject.activeSelf or GameObject.activeInHierarchy.' (CS0618) (Assembly-CSharp)
			myModelTrf.gameObject.active = true;
		}
	}
}