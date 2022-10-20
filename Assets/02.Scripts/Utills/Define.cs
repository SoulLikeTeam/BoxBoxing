using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define : MonoBehaviour
{
    public enum Scene
    {
        Unknown,
        Menu,
        Game,
        Stage
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

    public enum PlayerButtonEvnet
    {

        Down,
        Up

    }

    public enum MouseKey
    {

        Left,
        Right

    }

    public enum PlayerStates
    {

        Punch,
        Guard,
        Idle,
        Die

    }

}
