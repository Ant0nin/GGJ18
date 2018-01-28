using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour {

    GameObject doorClosed;
    GameObject doorOpen;
    BoxCollider2D boxCollider;

    void Start () {
        doorClosed = transform.GetChild(0).gameObject;
        doorOpen = transform.GetChild(1).gameObject;
        boxCollider = GetComponent<BoxCollider2D>();
	}

    public void OpenDoor()
    {
        // TODO: trigger door sound
        doorOpen.SetActive(true);
        doorClosed.SetActive(false);
        boxCollider.enabled = false;
    }

    public void CloseDoor()
    {
        // TODO: trigger door sound
        doorOpen.SetActive(false);
        doorClosed.SetActive(true);
        boxCollider.enabled = true;
    }
}
