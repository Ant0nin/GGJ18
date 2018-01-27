using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAI : MonoBehaviour {

    private Rigidbody2D rb;
    private Animator anim;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	void Update () {
        anim.SetFloat("speed", Vector3.Magnitude(rb.velocity));
    }
}
