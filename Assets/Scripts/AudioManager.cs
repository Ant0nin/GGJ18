using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public float frequencyCoef;
    public float distCoef;

    AudioLowPassFilter[] allApf;
    Camera cam;

    void Start () {
        allApf = GetComponentsInChildren<AudioLowPassFilter>();
        cam = Camera.allCameras[0];
    }
	
	void Update ()
    {
        foreach(AudioLowPassFilter apf in allApf)
        {
            Vector3 apfPos = apf.gameObject.transform.position;
            Vector3 camPos = cam.transform.position;
            float dist = Vector3.Magnitude(camPos - apfPos);

            if (dist == 0.0f)
                apf.cutoffFrequency = 22000f;
            else
                apf.cutoffFrequency = frequencyCoef * (1.0f/(dist*distCoef));

            // TODO: remove log
            Debug.Log(apf.name + " " + apf.cutoffFrequency);
        }
    }
}
