using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define : MonoBehaviour
{
    public enum Scene
    {
        Unknown,
        Menu,
        Game
    }

    public enum MouseEvent
    {
        LeftPress,
        LeftClick,
        RightPress,
        RightClick
    }

    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount
    }
}
