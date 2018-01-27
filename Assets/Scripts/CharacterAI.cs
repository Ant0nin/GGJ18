using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAI : MonoBehaviour {

    [SerializeField]
    CharacterState state;

    Rigidbody2D rb;
    Animator anim;

    public CharacterState State
    {
        get { return state; }
        set {
            // TODO: switch character brain
            state = value;
        }
    }

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	void Update () {
        anim.SetFloat("speed", Vector3.Magnitude(rb.velocity));
    }
}
