using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainZombie : BrainNeutral
{
    public override void Plug(Collider2D col, CharacterAI ai, Rigidbody2D rb, Animator anim)
    {
        BoxCollider2D collider = (BoxCollider2D)col;
        collider.size = CharacterAI.bcSizeCrouch;
        collider.offset = CharacterAI.bcOffsetCrouch;
    }

    public override void Unplug(Collider2D col, CharacterAI ai, Rigidbody2D rb, Animator anim)
    {
        BoxCollider2D collider = (BoxCollider2D)col;
        collider.size = CharacterAI.bcSizeStand;
        collider.offset = CharacterAI.bcOffsetStand;
    }
}
