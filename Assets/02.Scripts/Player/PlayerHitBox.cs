using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBox : MonoBehaviour
{

    [SerializeField] private Vector2 size;

    public bool ining;


    private void Update()
    {

        ining = Physics2D.BoxCast(transform.position, size, 0, Vector2.zero, 0, LayerMask.GetMask("Enemy"));
        
    }


#if UNITY_EDITOR

    private void OnDrawGizmos()
    {

        Gizmos.DrawWireCube(transform.position, size);

    }

#endif

}
