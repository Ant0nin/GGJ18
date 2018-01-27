using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAI : MonoBehaviour {

    [SerializeField]
    CharacterState state = CharacterState.NEUTRAL;

    SpriteRenderer sprRender;
    Rigidbody2D rb;
    Animator anim;
    BrainAbstract brain;
    BrainMapping store;
    AudioSource audioSrc;

    public CharacterState State
    {
        get { return state; }
        set {
            if (value == state) return;

            brain.Unplug(this, rb, anim);
            state = value;
            brain = store.GetBrain(value);
            brain.Plug(this, rb, anim);

            audioSrc.Play();
        }
    }

    void Start()
    {
        store = BrainMapping.GetInstance();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprRender = GetComponent<SpriteRenderer>();
        audioSrc = GetComponent<AudioSource>();

        state = (state == 0 ? CharacterState.NEUTRAL : state);
        brain = store.GetBrain(state);
        brain.Plug(this, rb, anim);
    }
    
	void Update () {
        brain.UpdateDelegate(this, rb, anim);
        anim.SetFloat("speed", Vector3.Magnitude(rb.velocity));
        sprRender.color = store.GetColor(state);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        brain.CollisionEnterDelegate(col, this, rb, anim);
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        brain.CollisionEndDelegate(col, this, rb, anim);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        brain.TriggerEnterDelegate(col, this, rb, anim);
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        brain.TriggerEndDelegate(col, this, rb, anim);
    }
}
