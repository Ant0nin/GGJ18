using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// singleton
public class GeneralMapping
{
    private static GeneralMapping instance;
    public static GeneralMapping GetInstance()
    {
        if(instance == null)
            instance = new GeneralMapping();
        return instance;
    }

    private GeneralMapping()
    {
        GenerateBrainStore();
        GenerateColorMapping();
        GenerateSoundMapping();
    }

    public BrainAbstract GetBrain(CharacterState cs)
    {
        return brainStore[cs];
    }

    public Color GetColor(CharacterState cs)
    {
        return colorMapping[cs];
    }

    public AudioClip GetSound(CharacterState cs)
    {
        return soundMapping[cs];
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

    Dictionary<CharacterState, AudioClip> soundMapping;
    void GenerateSoundMapping()
    {
        soundMapping = new Dictionary<CharacterState, AudioClip>();
        soundMapping[CharacterState.NEUTRAL] = (AudioClip)Resources.Load("Audio/Sounds/HeyM");
        soundMapping[CharacterState.ZOMBIE] = (AudioClip)Resources.Load("Audio/Sounds/zombie");
        soundMapping[CharacterState.FEAR] = (AudioClip)Resources.Load("Audio/Sounds/ScaredM");
        soundMapping[CharacterState.COURAGE] = (AudioClip)Resources.Load("Audio/Sounds/HeyM");
    }
}
