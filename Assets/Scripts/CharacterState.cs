using UnityEngine;
using System.Collections;

public enum CharacterState
{
    NEUTRAL =   0x01, // 0001
    ZOMBIE =    0x02, // 0010
    FEAR =      0x04, // 0100
    COURAGE =   0x08  // 1000
}
