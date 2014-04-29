#pragma strict

public static var wall2 = false;

function Start () {

}

function Update () {
	if (wall2) {
		transform.Rotate(Vector3.up);
	}
}