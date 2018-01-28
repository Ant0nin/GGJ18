using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotController : MonoBehaviour
{
    public SpotEffect effect;

    Camera cam;
    Vector2 spotDir;

    public Vector2 SpotDir {
        get { return spotDir; }
    }

    void Start () {
        cam = Camera.allCameras[0];
        spotDir = Vector2.down;

        Color color = GeneralMapping.GetInstance().GetColor((CharacterState)effect);
        SpriteRenderer sprRenderSpot = transform.GetChild(0).GetComponent<SpriteRenderer>();
        SpriteRenderer sprRenderBeam = transform.GetChild(2).GetComponent<SpriteRenderer>();
        sprRenderSpot.color = color;
        sprRenderBeam.color = color;
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
}
