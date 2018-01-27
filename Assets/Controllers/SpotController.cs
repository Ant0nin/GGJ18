using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotController : MonoBehaviour
{
    public uint raycastMaxIter = 5;
    public float raycastMaxDist = Mathf.Infinity;

    Camera cam;
    Vector2 spotDir;
    LayerMask raycastLayerMask;

	void Start () {
        cam = Camera.allCameras[0];
        spotDir = Vector2.down;
        raycastLayerMask = LayerMask.GetMask("Mirrors", "Characters", "Obstruders");
    }
	
    private void OnMouseDrag()
    {
        Vector2 viewportMousePos = cam.ScreenToViewportPoint(Input.mousePosition);
        Vector2 cursorPos = viewportMousePos;                           // [0;1]
        Vector2 spotPos = cam.WorldToViewportPoint(transform.position); // [0;1]
        spotDir = Vector3.Normalize(cursorPos - spotPos);
        Quaternion orient = Quaternion.FromToRotation(Vector2.down, spotDir);
        transform.rotation = orient;
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, spotDir, raycastMaxDist, raycastLayerMask);
        Debug.Log(spotDir);
        if(hit.collider != null && hit.collider.gameObject.tag == "Player")
        {
            Debug.Log("ray hits character");
        }
        return;
    }
}
