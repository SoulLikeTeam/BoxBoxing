using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;
using FD.Dev;

public class PlayerManagement : MonoBehaviour
{

    [SerializeField] private PlayerState playerState;
    [SerializeField] private PlayerInput input;
    [SerializeField] private UnityEvent dieEvent;
    [SerializeField] private ShieldUp up;

    public Vector2 size;
    public Vector2 pos;
    public LayerMask mask;
    public bool godMode;
    private CinemachineBasicMultiChannelPerlin channelPerlin;
    private int HitCount = 4;

    private bool isDead = false;
    private bool isLow = false;
    private bool attackAble;
    [HideInInspector] public bool isFuckingDie;

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
        if (isDead == true) return;

        FAED.InvokeDelay(() =>
        {

            Debug.Log("°ø!¾å°Ý");

            Collider2D col = Physics2D.OverlapBox(transform.position + (Vector3)pos, size, 0, mask);

            if (col != null)
            {
                Debug.Log(3);
                PlayerManagement mamange = col.GetComponent<PlayerManagement>();
                mamange.Hit();
            }

        }, 0.2f);



    }

    public void SetGuard()
    {

        if (isFuckingDie) 
        {

            playerState.SetIdle();
            return;
        
        }

        up.Shield(HitCount, isLow);

    }

    public void DeGuard(bool isBreak = false)
    {

        if(isBreak == true)
        {

            isLow = true;

        }
        if (isLow)
        {


            HitCount = 2;

        }

        up.DeShield(isBreak);
    }

    public void Hit()
    {

        Debug.Log(playerState.currentState);

        if(playerState.currentState != Define.PlayerStates.Guard && !godMode)
        {

            Die();
            
        }
        else if(godMode)
        {

            if (attackAble) return;

            attackAble = true;
                FAED.Pop("MissFX", transform.position, Quaternion.identity);

            FAED.InvokeDelay(() =>
            {

                attackAble = false;

            }, 0.1f);

        }
        else
        {

            if(isFuckingDie) return;

            SoundManager.instance.SFXPlay(Random.Range(1, 6));

            HitCount--;
            if(HitCount > 0)
            {



                up.Shield(HitCount, isLow);

                if(isLow == true && HitCount == 0)
                {

                    isFuckingDie = true;

                }

            }
            else
            {

                if (isLow)
                {

                    isFuckingDie = true;

                }

                DeGuard(true);
            }
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
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position + (Vector3)pos, size);
        Gizmos.color = Color.white;
    }
#endif
}
