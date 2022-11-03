using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Dash : PlayerAction
{

    [SerializeField] private float dashPower;
    [SerializeField] private Transform dashPos;

    private Vector2 endPos;
    private bool isDashCoolDown;

    private void Update()
    {
        
        if(state.currentState == Define.PlayerStates.Dash)
        {

            transform.position = Vector2.MoveTowards(transform.position, endPos, Time.deltaTime * dashPower);

            particle.Play();

            if(transform.position == (Vector3)endPos)
            {

                state.SetIdle();
                particle.Stop();
                StartCoroutine(DelayTimeCo());

            }

        }

    }

    public override void Action()
    {

        if(state.currentState != Define.PlayerStates.Walk ||           
           isDashCoolDown == true) return;

        state.SetState(Define.PlayerStates.Dash);
        
        endPos = dashPos.position;

    }

    public override void Action(float value)
    {
    }

    IEnumerator DelayTimeCo()
    {


        isDashCoolDown = true;

        yield return new WaitForSeconds(0.5f);

        isDashCoolDown = false;

    }

}
