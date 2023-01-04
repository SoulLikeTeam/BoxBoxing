using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static Define;
//
#region 클레스들
[System.Serializable]
public class PlayerMouseInputSetting
{

    public MouseKey mouseKey;
    public PlayerButtonEvnet buttonEvent;
    public UnityEvent events;

}

[System.Serializable]
public class PlayerKeyInputSetting
{

    public KeyCode keyCode;
    public KeyEventSetting inputEvent;
    public UnityEvent events;

}

[System.Serializable]
public class PlayerInputManagerInputSetting
{

    public InputManagerType inputType;
    public UnityEvent<float> events;

}
#endregion
//

public class PlayerInput : MonoBehaviour
{

    [SerializeField] private List<PlayerMouseInputSetting> playerMouseInputs;
    [Header("---------------------------------------")]
    [SerializeField] private List<PlayerKeyInputSetting> playerKeyInputs;
    [Header("---------------------------------------")]
    [SerializeField] private List<PlayerInputManagerInputSetting> playerInputManagerInputSettings;

    private bool isIgnoreInput = false;

    private void Update()
    {

        if (isIgnoreInput == true) return;

        InputManagerAction();
        MouseAction();
        KeyAction();

    }

    public void SetIgnoreInput(bool value)
    {
        isIgnoreInput = value;
    }

    private void MouseAction()
    {

        foreach(var events in playerMouseInputs)
        {

            int mouseButton = events.mouseKey switch
            {

                MouseKey.Right => 1,
                MouseKey.Left => 0,
                _ => 0,
            };

            if(events.buttonEvent == PlayerButtonEvnet.Up)
            {

                if (Input.GetMouseButtonUp(mouseButton)) events.events?.Invoke();

            }
            else if(events.buttonEvent == PlayerButtonEvnet.Down)
            {

                if (Input.GetMouseButtonDown(mouseButton)) 
                { 
                
                    events.events?.Invoke();

                } 

            }

        }

    }

    public void KeyAction()
    {

        foreach(var events in playerKeyInputs)
        {

            if(events.inputEvent == KeyEventSetting.KeyDown)
            {

                if (Input.GetKeyDown(events.keyCode))
                {

                    events.events?.Invoke();

                }

            }
            else if (events.inputEvent == KeyEventSetting.KeyUp)
            {

                if (Input.GetKeyUp(events.keyCode))
                {

                    events.events?.Invoke();

                }

            }
            else if(events.inputEvent == KeyEventSetting.Key)
            {

                if (Input.GetKey(events.keyCode))
                {

                    events.events?.Invoke();

                }

            }

        }

    }

    public void InputManagerAction()
    {

        foreach(var events in playerInputManagerInputSettings)
        {

            float value = events.inputType switch
            {

                InputManagerType.Vertical => Input.GetAxisRaw("Vertical"),
                InputManagerType.Horizontal => Input.GetAxisRaw("Horizontal"),
                _ => 0

            };



            events.events?.Invoke(value);


        }

    }

}
