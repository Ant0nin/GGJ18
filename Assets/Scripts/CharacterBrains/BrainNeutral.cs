using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainNeutral : BrainAbstract
{
    protected bool goLeft = true;
    protected float speed = CharacterAI.speedWalk;

    public override void TriggerEnterDelegate(Collider2D col, CharacterAI ai, Rigidbody2D rb, Animator anim)
    {
        if (col.tag == "Edge" || col.tag == "Wall") // Warning (bug): occurs sometimes when a light ray hits the character
        {
            changeWalkDir(ai);
        }
    }

    public override void UpdateDelegate(Collider2D col, CharacterAI ai, Rigidbody2D rb, Animator anim)
    {
        if (goLeft) // go left
        {
            rb.velocity = Vector2.left * speed + Physics2D.gravity;
        }
        else // go right
        {
            rb.velocity = Vector2.right * speed + Physics2D.gravity;
        }
    }
    
    protected void changeWalkDir(CharacterAI ai)
    {
        goLeft = !goLeft;
        ai.transform.localScale = new Vector3(
            ai.transform.localScale.x * -1.0f,
            ai.transform.localScale.y
        );
    }

    public override void CollisionEndDelegate(Collision2D col, CharacterAI ai, Rigidbody2D rb, Animator anim)
    {
    }

    public override void CollisionEnterDelegate(Collision2D col, CharacterAI ai, Rigidbody2D rb, Animator anim)
    {

    }
    
    public override void TriggerEndDelegate(Collider2D col, CharacterAI ai, Rigidbody2D rb, Animator anim)
    {
    }

    public override void Unplug(Collider2D col, CharacterAI ai, Rigidbody2D rb, Animator anim)
    {
        
    }

    public override void Plug(Collider2D col, CharacterAI ai, Rigidbody2D rb, Animator anim)
    {
        
    }
}