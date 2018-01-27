using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAI : MonoBehaviour {

    [SerializeField]
    CharacterState state = CharacterState.NEUTRAL;

    Rigidbody2D rb;
    Animator anim;
    BrainAbstract brain;
    BrainMapping store;

    public CharacterState State
    {
        get { return state; }
        set {
            if (value == state) return;

            brain.Unplug(this, rb, anim);
            state = value;
            brain = store.GetBrain(value);
            brain.Plug(this, rb, anim);
        }
    }

    void Start()
    {
        store = BrainMapping.GetInstance();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        state = (state == 0 ? CharacterState.NEUTRAL : state);
        brain = store.GetBrain(state);
        brain.Plug(this, rb, anim);
    }
    
	void Update () {
        brain.UpdateDelegate(this, rb, anim);
        anim.SetFloat("speed", Vector3.Magnitude(rb.velocity));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
