using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAI : MonoBehaviour {

    [SerializeField]
    CharacterState state = CharacterState.NEUTRAL;

    public readonly static Vector2 bcSizeStand = new Vector2(3.714237f, 9.732243f);
    public readonly static Vector2 bcOffsetStand = new Vector2(-0.1036626f, 0.3471451f);

    public readonly static Vector2 bcSizeCrouch = new Vector2(9.732243f, 3.714237f);
    public readonly static Vector2 bcOffsetCrouch = new Vector2(-0.1036626f, -0.50000f);

    SpriteRenderer sprRender;
    Rigidbody2D rb;
    Animator anim;
    BrainAbstract brain;
    GeneralMapping store;
    AudioSource audioSrc;
    Collider2D coll;

    public CharacterState State
    {
        get { return state; }
        set {
            if (value == state) return;

            brain.Unplug(coll, this, rb, anim);
            state = value;
            brain = store.GetBrain(value);
            brain.Plug(coll, this, rb, anim);

            AudioClip sound = store.GetSound(state);
            audioSrc.clip = sound;
            audioSrc.Play();
        }
    }

    void Start()
    {
        store = GeneralMapping.GetInstance();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprRender = GetComponent<SpriteRenderer>();
        audioSrc = GetComponent<AudioSource>();
        coll = GetComponent<Collider2D>();

        state = (state == 0 ? CharacterState.NEUTRAL : state);
        brain = store.GetBrain(state);
        brain.Plug(coll, this, rb, anim);
    }
    
	void Update () {
        brain.UpdateDelegate(coll, this, rb, anim);
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
