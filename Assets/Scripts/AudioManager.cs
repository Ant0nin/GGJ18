using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    ZoneMarker[] zoneMarkers;
    AudioSource[] audioSources;
    Camera cam;

    AudioSource Ambient1;
    AudioSource Ambient1B;
    AudioSource Ambient2;
    AudioSource Ambient2B;
    AudioSource Ambient3;
    AudioSource Ambient3B;


    void Start () {
        cam = Camera.allCameras[0];
        zoneMarkers = GameObject.Find("ZoneMarkers").GetComponentsInChildren<ZoneMarker>();
        audioSources = GetComponentsInChildren<AudioSource>();

        Ambient1 = audioSources[0];
        Ambient1B = audioSources[1];
        Ambient2 = audioSources[2];
        Ambient2B = audioSources[3];
        Ambient3 = audioSources[4];
        Ambient3B = audioSources[5];
    }

    void Update ()
    {
        Vector3 camPos = cam.transform.position;

        // detect closer zone:
        ZoneMarker closerZm = null;
        float dist;
        float minDist = float.PositiveInfinity;
        for(uint i = 0; i<zoneMarkers.Length; i++)
        {
            ZoneMarker zm = zoneMarkers[i];
            Vector3 zmPos = zm.transform.position;
            dist = Vector3.Magnitude(zmPos - camPos);

            if (dist < minDist) {
                minDist = dist;
                closerZm = zm;
            }
        }

        switch(closerZm.levelNumber)
        {
            case 1: TransiteToLevel1(); break;
            case 2: TransiteToLevel2(); break;
            case 3: TransiteToLevel3(); break;
            default: throw new System.NotImplementedException();
        }

    }

    void TransiteToLevel1()
    {
        Ambient2.mute = false;
        Ambient1B.mute = false;

        Ambient2B.mute = true;
        Ambient1.mute = true;
        Ambient3.mute = true;
        Ambient3B.mute = true;
    }

    void TransiteToLevel2()
    {
        Ambient1.mute = false;
        Ambient2B.mute = false;
        Ambient3B.mute = false;

        Ambient1B.mute = true;
        Ambient2.mute = true;
        Ambient3.mute = true;
    }

    void TransiteToLevel3()
    {
        Ambient3.mute = false;
        Ambient1B.mute = false;

        Ambient3B.mute = true;
        Ambient1.mute = true;
        Ambient2.mute = true;
        Ambient2B.mute = true;
    }
}
