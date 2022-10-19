using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class PlayerState : MonoBehaviour
{
    public PlayerStates currentState { get; private set; } = PlayerStates.Idle;

    public void SetIdle()
    {

        currentState = PlayerStates.Idle;

    }

    public void SetState(PlayerStates state)
    {

        currentState = state;

    }

}
