using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManagement : MonoBehaviour
{

    [SerializeField] private PlayerState playerState;
    [SerializeField] private PlayerInput input;
    [SerializeField] private UnityEvent dieEvent;
    public static PlayerManagement Instance { get; private set; }

    public Vector2 size;
    public Vector2 pos;
    public LayerMask mask;

    private void Awake()
    {

        Instance = this;
        
        if(playerState == null)
        {

            Debug.Log($"{name} PlayerState is null!");

        }
        if(input == null)
        {

            Debug.LogError($"{name} PlayerInput is null!");

        }
    }

    public void Die()
    {

        dieEvent?.Invoke();
        playerState.SetState(Define.PlayerStates.Die);

    }

    public void Attack()
    {
        
        Debug.Log("¾å °ø°Ý!!");
        Collider2D col = Physics2D.OverlapBox(transform.position + (Vector3)pos, size, 0, mask);
        //Physics2D.OverlapBoxAll()

        if(col != null)
        {
            PlayerManagement mamange = col.GetComponent<PlayerManagement>();
            mamange.Hit();
        }

    }

    public void Hit()
    {

        if(playerState.currentState != Define.PlayerStates.Guard)
        {

            Die();

        }
        else
        {

            Debug.Log("¸·¾Æ³Â´Ù!!!");

        }
    }


#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position + (Vector3)pos, size);
        Gizmos.color = Color.white;
    }
#endif
}
