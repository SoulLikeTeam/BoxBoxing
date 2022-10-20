using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static Define;

[System.Serializable]
public class PlayerInputSetting
{

    public MouseKey mouseKey;
    public PlayerButtonEvnet buttonEvent;
    public UnityEvent<Animator, PlayerState> events;

}

public class PlayerInput : MonoBehaviour
{

    [SerializeField] private List<PlayerInputSetting> playerInputs;
    [SerializeField] private PlayerState playerState;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        
        if(animator == null)
        {

            Debug.LogError($"{gameObject.name}, Animator is null!");

        }
        if(playerState == null)
        {

            Debug.LogError($"{gameObject.name}, PlayerState is null!");

        }

    }

    private void Update()
    {

        Action();

    }

    private void Action()
    {

        foreach(var events in playerInputs)
        {

            int mouseButton = events.mouseKey switch
            {

                MouseKey.Right => 1,
                MouseKey.Left => 0,
                _ => 0,
            };

            if(events.buttonEvent == PlayerButtonEvnet.Up)
            {

                if (Input.GetMouseButtonUp(mouseButton)) events.events?.Invoke(animator, playerState);

            }
            else if(events.buttonEvent == PlayerButtonEvnet.Down)
            {

                if (Input.GetMouseButtonDown(mouseButton)) 
                { 
                
                    events.events?.Invoke(animator, playerState);

                } 

            }

        }

    }

}
