using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define : MonoBehaviour
{
    public enum Scene
    {
        Unknown,
        Game
    }

    public enum MouseEvent
    {
        Press,
        Click
    }

    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount
    }
}
