using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager
{
    public Action KeyAction = null;
    public Action<Define.MouseEvent> MouseAction = null;

    bool _leftPressed = false;
    bool _rightPressed = false;

    public void OnUpdate()
    {
        if (Input.anyKey && KeyAction != null)
        {
            KeyAction?.Invoke();
        }

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if(MouseAction != null)
        {
            if (Input.GetMouseButton(0))
            {
                MouseAction.Invoke(Define.MouseEvent.LeftPress);
                _leftPressed = true;
            }
            else
            {
                if (_leftPressed)
                {
                    MouseAction?.Invoke(Define.MouseEvent.LeftClick);
                }
                _leftPressed = false;
            }

            if (Input.GetMouseButton(1))
            {
                MouseAction.Invoke(Define.MouseEvent.RightPress);
                _rightPressed = true;
            }
            else
            {
                if (_rightPressed)
                {
                    MouseAction?.Invoke(Define.MouseEvent.RightClick);
                }
                _rightPressed = false;
            }
        }
    }

    public void Clear()
    {
        KeyAction = null;
        MouseAction = null;
    }
}
