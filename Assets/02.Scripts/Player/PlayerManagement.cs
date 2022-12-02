using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;

public class PlayerManagement : MonoBehaviour
{

    [SerializeField] private PlayerState playerState;
    [SerializeField] private PlayerInput input;
    [SerializeField] private UnityEvent dieEvent;

    public Vector2 size;
    public Vector2 pos;
    public LayerMask mask;
    private CinemachineBasicMultiChannelPerlin channelPerlin;
    private int HitCount = 5;

    private bool isDead = false;

    private void Awake()
    {
        
        channelPerlin = FindObjectOfType<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

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
        isDead = true;
        dieEvent?.Invoke();
        playerState.SetState(Define.PlayerStates.Die);

    }

    public void Attack()
    {
        // ³Ê¹« Á÷¹ßÀÓ.
        // °ø°ÝÀÌ ³ª°¡´Â µ¿½Ã¿¡ ÇÇ°Ý ÆÇÁ¤ÀÌ µé¾î¿È. ¾à°£ÀÇ ½Ã°£ÀÌ ÀÖ¾î¾ßÇÔ. ±×·¡¾ß ¹ÝÀÀÀ» ÇÏÁö...
        Debug.Log("ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½!!");

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

        Debug.Log(playerState.currentState);

        if(playerState.currentState != Define.PlayerStates.Guard)
        {

            Die();

        }
        else
        {

            HitCount--;
            Debug.Log("ï¿½ï¿½ï¿½Æ³Â´ï¿½!!!");
            StartCoroutine(CameraShakeCo());

        }
    }

    IEnumerator CameraShakeCo()
    {

        channelPerlin.m_AmplitudeGain = 3f;
        channelPerlin.m_FrequencyGain = 3f;
        yield return new WaitForSecondsRealtime(0.1f);
        channelPerlin.m_AmplitudeGain = 0f;
        channelPerlin.m_FrequencyGain = 0f;

    }

    private void OnDisable()
    {
        isDead = false;
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
