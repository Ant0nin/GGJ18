using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastManager : MonoBehaviour {

    public uint raycastMaxIter = 5;
    public float raycastMaxDist = Mathf.Infinity;

    LayerMask raycastLayerMask;
    SpotController[] allLightSpots;
    Dictionary<CharacterAI, CharacterState> tempBase;

	void Start () {
        GameObject go = GameObject.Find("Spotlights");
        allLightSpots = go.GetComponentsInChildren<SpotController>();
        raycastLayerMask = LayerMask.GetMask("Characters", "Mirrors", "Obstruders", "Filters");
        tempBase = new Dictionary<CharacterAI, CharacterState>();
    }

    void Update ()
    {
		foreach(SpotController s in allLightSpots)
        {
            RaycastHit2D hit = Physics2D.Raycast(s.transform.position, s.SpotDir, raycastMaxDist, raycastLayerMask);
            Debug.DrawRay(s.transform.position, s.SpotDir);
            if (hit.collider != null && hit.collider.gameObject.tag == "Player")
            {
                GameObject go = hit.collider.gameObject;
                CharacterAI ai = go.GetComponent<CharacterAI>();
                //CharacterState refreshedState = ai.State | ((CharacterState)s.effect); //!\ TODO: light combinaisons
                CharacterState refreshedState = ((CharacterState)s.effect);
                tempBase[ai] = refreshedState;
            }
        }

        foreach(KeyValuePair<CharacterAI, CharacterState> entry in tempBase)
        {
            CharacterAI ai = entry.Key;
            CharacterState newState = entry.Value;
            ai.State = newState;
        }

        tempBase.Clear();
	}
}
