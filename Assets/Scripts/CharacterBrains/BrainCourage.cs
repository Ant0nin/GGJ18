﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainCourage : BrainAbstract
{
    public override void Plug(CharacterAI ai, Rigidbody2D rb, Animator anim)
    {
        
    }

    public override void Unplug(CharacterAI ai, Rigidbody2D rb, Animator anim)
    {
        
    }

    public override void UpdateDelegate(CharacterAI ai, Rigidbody2D rb, Animator anim)
    {
        rb.AddForce(new Vector2(100.0f, 0.0f));
    }


}