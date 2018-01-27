using UnityEngine;
using System.Collections;

public abstract class BrainAbstract
{
    protected BrainAbstract() {}
    abstract public void TriggerEnterDelegate(Collider2D col, CharacterAI ai, Rigidbody2D rb, Animator anim);
    abstract public void TriggerEndDelegate(Collider2D col, CharacterAI ai, Rigidbody2D rb, Animator anim);
    abstract public void CollisionEnterDelegate(Collision2D col, CharacterAI ai, Rigidbody2D rb, Animator anim);
    abstract public void CollisionEndDelegate(Collision2D col, CharacterAI ai, Rigidbody2D rb, Animator anim);
    abstract public void Plug(Collider2D col, CharacterAI ai, Rigidbody2D rb, Animator anim);
    abstract public void Unplug(Collider2D col, CharacterAI ai, Rigidbody2D rb, Animator anim);
    abstract public void UpdateDelegate(Collider2D col, CharacterAI ai, Rigidbody2D rb, Animator anim);
}
