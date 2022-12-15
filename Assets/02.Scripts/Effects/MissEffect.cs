using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using FD.Dev;

public class MissEffect : MonoBehaviour
{
    private void OnEnable()
    {

        transform.DOJump(transform.position + new Vector3(Random.Range(-1f, 1f), 1), 1, 1, 0.3f).OnComplete(() =>
        {

            FAED.InvokeDelay(() =>
            {

                FAED.Push(gameObject);

            }, 1f);

        });



    } 

}
