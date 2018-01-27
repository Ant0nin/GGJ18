using UnityEngine;
using System.Collections;

public abstract class BrainAbstract
{
    protected BrainAbstract() {}
    abstract public void Plug(CharacterAI ai, Rigidbody2D rb, Animator anim);
    abstract public void Unplug(CharacterAI ai, Rigidbody2D rb, Animator anim);
    abstract public void UpdateDelegate(CharacterAI ai, Rigidbody2D rb, Animator anim);
}
