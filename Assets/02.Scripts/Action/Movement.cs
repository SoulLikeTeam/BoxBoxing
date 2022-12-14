using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : PlayerAction
{
    [SerializeField] private float speed;
    [SerializeField] private Transform dashPos;
    [SerializeField] private Transform target;
    [SerializeField] private Animator whillAnime;
    [field: SerializeField] protected new GameObject basePos;
    private float value;
    private bool isFilp;

    public override void Action()
    {

        if (state.currentState == Define.PlayerStates.Dash && isFilp == false)
        {

            isFilp = true;
            
            particle.transform.localScale = target.transform.position switch
            {

                { x:var X} when X > transform.position.x => new Vector3(1, 1, 1),
                { x:var X} when X < transform.position.x => new Vector3(-1, 1, 1),
                _ => basePos.transform.localScale

            };

            StartCoroutine(FilpCoolCo());

        }


    }

    public override void Action(float value)
    {

        this.value = value;

        if(state.currentState != Define.PlayerStates.Idle && state.currentState != Define.PlayerStates.Walk) return;

        if(value != 0)
        {

            whillAnime.SetBool("Idle", true);

        }
        else
        {

            whillAnime.SetBool("Idle", false);

        }

        playerRigid.velocity = new Vector2(value * speed, playerRigid.velocity.y);

        if(value == 0)
        {

            state.SetIdle();

        }
        else
        {

            state.SetState(Define.PlayerStates.Walk);

        }



        dashPos.transform.localScale = value switch
        {

            1 => new Vector3(1, 1, 1),
            -1 => new Vector3(-1, 1, 1),
            _ => dashPos.transform.localScale

        };

    }

    public void Update()
    {

        basePos.transform.localScale = target.transform.position switch
        {

            { x: var X } when X > transform.position.x => new Vector3(1, 1, 1),
            { x: var X } when X < transform.position.x => new Vector3(-1, 1, 1),
            _ => basePos.transform.localScale

        };

    }

    IEnumerator FilpCoolCo()
    {

        isFilp = true;

        yield return new WaitForSeconds(0.2f);

        isFilp = false;

    }

    public void SetTarget(GameObject go)
    {
        target = go.transform;
    }
}
