using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashWallDe : MonoBehaviour
{

    [SerializeField] private LayerMask mask;
    [SerializeField] private Dash dashPos;
    [SerializeField] private Transform basePos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(mask == Mathf.Pow(2, collision.gameObject.layer))
        {

            dashPos.endPos = basePos.transform.position;

        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (mask == Mathf.Pow(2, collision.gameObject.layer))
        {

            dashPos.endPos = basePos.transform.position;

        }

    }

}
