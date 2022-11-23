using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManagement : MonoBehaviour
{

    [SerializeField] private PlayerState playerState;
    [SerializeField] private PlayerInput input;
    [SerializeField] private UnityEvent dieEvent;

    private void Awake()
    {
                
        if(playerState == null)
        {

            Debug.Log($"{name} PlayerState is null!");

        }
        if(input == null)
        {

            Debug.LogError($"{name} PlayerInput is null!");

        }

    }

    public void Die()
    {

        dieEvent?.Invoke();
        playerState.SetState(Define.PlayerStates.Die);

    }

    public void Attack()
    {

        Debug.Log("¾å °ø°Ý!!");

    }

    public void Hit()
    {

        if(playerState.currentState != Define.PlayerStates.Guard)
        {

            Die();

        }
        else
        {

            Debug.Log("¸·¾Æ³Â´Ù!!!");

        }
    }

}
