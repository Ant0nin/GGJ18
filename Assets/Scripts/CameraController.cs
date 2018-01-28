using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float distanceThreshold = 10f;
    public float damping = 0.5f;
    public float zCam = -10.0f;
    public Vector2 targetOffset = new Vector2(0, 5.0f);

    Camera cam;
    ZoneMarker[] allZoneMarkers;
    
    void Start()
    {
        cam = Camera.allCameras[0];
        GameObject go = GameObject.Find("ZoneMarkers");
        allZoneMarkers = go.GetComponentsInChildren<ZoneMarker>();
        if (target == null) target = GameObject.Find("Character_Bear").transform;
    }

    void Update()
    {
        Vector2 newCamPos2d = new Vector2(0,0);
        uint numSelectedZones = 0;
        foreach(ZoneMarker zm in allZoneMarkers)
        {
            float dist = Vector3.Magnitude(target.position - zm.transform.position);
            if (dist > distanceThreshold)
                continue;
            else
            {
                newCamPos2d.x += zm.weight * zm.transform.position.x;
                newCamPos2d.y += zm.weight * zm.transform.position.y;
                numSelectedZones++;
            }
        }

        if (numSelectedZones > 0)
        {
            newCamPos2d /= (float)numSelectedZones; // average

            Vector3 newCamPos3d = new Vector3(
                newCamPos2d.x,
                newCamPos2d.y,
                zCam
            );

            cam.transform.position = Vector3.Lerp(cam.transform.position, newCamPos3d, damping * Time.deltaTime);
        }
        else
        {
            Vector3 newCamPos3d = new Vector3(
                target.position.x + targetOffset.x,
                target.position.y + targetOffset.y,
                zCam);

            cam.transform.position = Vector3.Lerp(cam.transform.position, newCamPos3d, damping * Time.deltaTime);
        }
            

    }
}
