using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainCourage : BrainNeutral
{
    public override void TriggerEnterDelegate(Collider2D col, CharacterAI ai, Rigidbody2D rb, Animator anim)
    {
        if (col.tag == "Wall")
        {
            changeWalkDir(ai);
        }
    }
}
