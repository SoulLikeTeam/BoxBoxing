using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Dash : PlayerAction
{

    [SerializeField] private float dashPower;
    [SerializeField] private Transform dashPos;

    private bool isDashCoolDown;

    [HideInInspector] public Vector2 endPos;

    private void Update()
    {

        Debug.Log(state.currentState);

        if(state.currentState == Define.PlayerStates.Dash)
        {

            transform.position = Vector2.MoveTowards(transform.position, endPos, Time.deltaTime * dashPower);

            particle.Play();
            boxParticle.Play();

            if (transform.position == (Vector3)endPos)
            {

                state.SetIdle();
                
                particle.Stop();
                boxParticle.Stop();
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

        playerManagement.godMode = true;
        FAED.InvokeDelayReal(() =>
        {

            playerManagement.godMode = false;

        }, 1f);

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
