using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainNeutral : BrainAbstract
{
    public override void CollisionEndDelegate(Collision2D col, CharacterAI ai, Rigidbody2D rb, Animator anim)
    {
    }

    public override void CollisionEnterDelegate(Collision2D col, CharacterAI ai, Rigidbody2D rb, Animator anim)
    {

    }

    public override void Plug(CharacterAI ai, Rigidbody2D rb, Animator anim)
    {
        
    }

    public override void TriggerEndDelegate(Collider2D col, CharacterAI ai, Rigidbody2D rb, Animator anim)
    {
    }

    public override void TriggerEnterDelegate(Collider2D col, CharacterAI ai, Rigidbody2D rb, Animator anim)
    {
    }

    public override void Unplug(CharacterAI ai, Rigidbody2D rb, Animator anim)
    {
        
    }

    public override void UpdateDelegate(CharacterAI ai, Rigidbody2D rb, Animator anim)
    {
        
    }
}