using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainCourage : BrainNeutral
{
    private uint frameCount;

    public override void Plug(Collider2D col, CharacterAI ai, Rigidbody2D rb, Animator anim)
    {
        frameCount = 100;
    }

    public override void TriggerEnterDelegate(Collider2D col, CharacterAI ai, Rigidbody2D rb, Animator anim)
    {
        if (col.tag == "Wall")
        {
            changeWalkDir(ai);
        }
    }

    public override void UpdateDelegate(Collider2D col, CharacterAI ai, Rigidbody2D rb, Animator anim)
    {
        frameCount++;
        if(frameCount >= 100)
        {
            if (goLeft)
                rb.AddForce(new Vector2(-300f, 250f));
            else
                rb.AddForce(new Vector2(300f, 250f));
            frameCount = 0;
        }           
    }
}
