using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainCourage : BrainNeutral
{
    private bool jumpMode = false;
    private uint jumpFrameCount = 0;
    private uint switchFrameCount = 0;

    public override void TriggerEnterDelegate(Collider2D col, CharacterAI ai, Rigidbody2D rb, Animator anim)
    {
        if (col.tag == "Wall")
        {
            changeWalkDir(ai);
        }
    }

    public override void UpdateDelegate(Collider2D col, CharacterAI ai, Rigidbody2D rb, Animator anim)
    {
        if(jumpMode)
        {
            rb.velocity = new Vector2(3f, 6f);
            jumpFrameCount++;
            if (jumpFrameCount >= 10) {
                jumpMode = false;
                jumpFrameCount = 0;
            }
        }
        else
        {
            base.UpdateDelegate(col, ai, rb, anim);

            switchFrameCount++;
            if(switchFrameCount >= 200) {
                jumpMode = true;
                switchFrameCount = 0;
            }
        }
    }
}
