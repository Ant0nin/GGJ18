using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAI : MonoBehaviour {

    [SerializeField]
    CharacterState state = CharacterState.NEUTRAL;

    Rigidbody2D rb;
    Animator anim;
    BrainAbstract brain;

    static Dictionary<CharacterState, BrainAbstract> brainStore;
    static void GenerateBrainStore()
    {
        brainStore = new Dictionary<CharacterState, BrainAbstract>();
        brainStore[CharacterState.NEUTRAL] = new BrainNeutral();
        brainStore[CharacterState.ZOMBIE] = new BrainZombie();
        brainStore[CharacterState.FEAR] = new BrainFear();
        brainStore[CharacterState.COURAGE] = new BrainCourage();
    }

    public CharacterState State
    {
        get { return state; }
        set {
            if (value == state) return;

            brain.Unplug(this, rb, anim);
            state = value;
            brain = brainStore[value];
            brain.Plug(this, rb, anim);
        }
    }

    void Start()
    {
        if (brainStore == null) CharacterAI.GenerateBrainStore();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        brain = brainStore[state == 0 ? CharacterState.NEUTRAL : state];
        brain.Plug(this, rb, anim);
    }
    
	void Update () {
        brain.UpdateDelegate(this, rb, anim);
        anim.SetFloat("speed", Vector3.Magnitude(rb.velocity));
    }
}
