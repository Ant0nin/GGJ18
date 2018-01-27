using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// singleton
public class BrainMapping
{
    private static BrainMapping instance;
    public static BrainMapping GetInstance()
    {
        if(instance == null)
            instance = new BrainMapping();
        return instance;
    }

    private BrainMapping()
    {
        GenerateBrainStore();
        GenerateColorMapping();
    }

    public BrainAbstract GetBrain(CharacterState cs)
    {
        return brainStore[cs];
    }

    public Color GetColor(CharacterState cs)
    {
        return colorMapping[cs];
    }

    Dictionary<CharacterState, BrainAbstract> brainStore;
    void GenerateBrainStore()
    {
        brainStore = new Dictionary<CharacterState, BrainAbstract>();
        brainStore[CharacterState.NEUTRAL] = new BrainNeutral();
        brainStore[CharacterState.ZOMBIE] = new BrainZombie();
        brainStore[CharacterState.FEAR] = new BrainFear();
        brainStore[CharacterState.COURAGE] = new BrainCourage();
    }

    Dictionary<CharacterState, Color> colorMapping;
    void GenerateColorMapping()
    {
        colorMapping = new Dictionary<CharacterState, Color>();
        colorMapping[CharacterState.NEUTRAL] =  Color.white;
        colorMapping[CharacterState.ZOMBIE] =   Color.green;
        colorMapping[CharacterState.FEAR] =     Color.blue;
        colorMapping[CharacterState.COURAGE] =  Color.yellow;
    }
}
