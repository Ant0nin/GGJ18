using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainFear : BrainNeutral
{    
    public override void Plug(Collider2D col, CharacterAI ai, Rigidbody2D rb, Animator anim)
    {
        this.speed = CharacterAI.speedRun;
    }

    public override void Unplug(Collider2D col, CharacterAI ai, Rigidbody2D rb, Animator anim)
    {
        this.speed = CharacterAI.speedWalk;
    }

    public override void UpdateDelegate(Collider2D col, CharacterAI ai, Rigidbody2D rb, Animator anim)
    {
        base.UpdateDelegate(col, ai, rb, anim);

        float randomNumber = Random.Range(0, 100f);
        if (randomNumber > 80f) {
            ai.transform.localScale = new Vector3(
                ai.transform.localScale.x * -1.0f,
                ai.transform.localScale.y
            );
        }
    }
}
