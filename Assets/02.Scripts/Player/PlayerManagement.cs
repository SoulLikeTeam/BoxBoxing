using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManagement : MonoBehaviour
{

    [SerializeField] private PlayerState playerState;
    [SerializeField] private PlayerInput input;
    [SerializeField] private UnityEvent dieEvent;
    public static PlayerManagement Instance { get; private set; }

    private void Awake()
    {

        Instance = this;
        
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

        Debug.Log("�� ����!!");

    }

    public void Hit()
    {

        if(playerState.currentState != Define.PlayerStates.Guard)
        {

            Die();

        }
        else
        {

            Debug.Log("���Ƴ´�!!!");

        }
    }

}
