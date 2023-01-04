using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Define : MonoBehaviour
{

    public static Camera MainCam = Camera.main;

    public enum Scene
    {

        Unknown,
        Menu,
        Game,
        Stage,
        Tplay
        
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
        Die,
        Dash,
        Sit,
        Walk

    }

    public enum KeyEventSetting
    {

        KeyDown,
        KeyUp,
        Key

    }

    public enum InputManagerType
    {

        Horizontal,
        Vertical,

    }

}
