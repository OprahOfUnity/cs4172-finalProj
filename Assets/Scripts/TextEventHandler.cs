using UnityEngine;
using System.Collections;

public class TextEventHandler : MonoBehaviour {
  public bool isQuitButton = false;
  private bool hasTouched = false;

  void Update () {
    OnTouchDown();
  }

  void OnTouchDown () {
    foreach (Touch touch in Input.touches) {
      if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved) {
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        RaycastHit hit ;
        if (Physics.Raycast (ray, out hit)) {
          hit.transform.gameObject.SendMessage("OnMouseDown");
          if (hit.transform.gameObject == this.gameObject && !isQuitButton){
            this.renderer.material.color = Color.green;
            hasTouched = !hasTouched;
            Application.LoadLevel(1);
          } else if (hit.transform.gameObject == this.gameObject && isQuitButton){
            this.renderer.material.color = Color.red;
            hasTouched = !hasTouched;
            Application.Quit();
          }
        }
      }
    }
  }
}
