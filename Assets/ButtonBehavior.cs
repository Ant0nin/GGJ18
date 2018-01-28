using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour {

    public DoorBehavior targetDoor;
    public float timeBeforeCloseAction = 2f;

    GameObject buttonOff;
    GameObject buttonOn;
    float timeCounterOn = 0f;
    bool state;

	void Start () {
        if (targetDoor == null)
            targetDoor = GameObject.Find("Door").GetComponent<DoorBehavior>();

        buttonOff = transform.GetChild(0).gameObject;
        buttonOn = transform.GetChild(1).gameObject;
	}

    private void Update()
    {
        if(state == true) // on
            timeCounterOn += Time.deltaTime;

        if (timeCounterOn > timeBeforeCloseAction) {
            targetDoor.CloseDoor();
            SwitchOff();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // TODO: trigger sound
        SwitchOn();
        targetDoor.OpenDoor();
    }

    void SwitchOn()
    {
        state = true; // on
        timeCounterOn = 0f;
        buttonOn.SetActive(true);
        buttonOff.SetActive(false);
    }

    void SwitchOff()
    {
        state = false; // off
        buttonOff.SetActive(true);
        buttonOn.SetActive(false);
    }
}
