using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAGeyKeyCondition : PACondition
{
    [SerializeField]
    private KeyCode key;
    
    public override bool IfCondition(PAState currState, PAState nexState)
    {
        return Input.GetKey(key);
    }
}
