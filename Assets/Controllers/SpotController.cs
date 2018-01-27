using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotController : MonoBehaviour {

    Camera cam;

	void Start () {
        cam = Camera.allCameras[0];
	}
	
    private void OnMouseDrag()
    {
        Vector2 viewportMousePos = cam.ScreenToViewportPoint(Input.mousePosition);
        Vector2 cursorPos = viewportMousePos;                           // [0;1]
        Vector2 spotPos = cam.WorldToViewportPoint(transform.position); // [0;1]
        Vector2 dir = Vector3.Normalize(cursorPos - spotPos);
        Quaternion orient = Quaternion.FromToRotation(Vector2.down, dir);
        transform.rotation = orient;
    }
}
