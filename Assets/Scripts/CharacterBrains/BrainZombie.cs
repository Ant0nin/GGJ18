using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainZombie : BrainNeutral
{
    BoxCollider2D bcStand;
    BoxCollider2D bcCrouch;

    public override void Plug(Collider2D col, CharacterAI ai, Rigidbody2D rb, Animator anim)
    {
        
    }

    public override void Unplug(Collider2D col, CharacterAI ai, Rigidbody2D rb, Animator anim)
    {

    }
}
