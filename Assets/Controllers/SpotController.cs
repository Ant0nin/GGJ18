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
        Vector2 cursorPos = 0.5f * viewportMousePos + new Vector2(0.5f, 0.5f); // [-1;1]
        Vector2 spotPos = cam.WorldToViewportPoint(transform.position);
        Vector2 dir = Vector3.Normalize(cursorPos - spotPos);
        Quaternion orient = Quaternion.LookRotation(dir);
        transform.rotation = orient;
    }
}
