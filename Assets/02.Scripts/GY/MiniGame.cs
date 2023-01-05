using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MiniGame : MonoBehaviour
{
    [SerializeField]
    private int _count = 100;
    private int _currentCnt = 0;

    [SerializeField]
    private float _delay = 10f;

    private Coroutine _timerCoroutine;

    private void OnEnable()
    {
        _currentCnt = 0;

        _timerCoroutine = StartCoroutine(TimerCoroutine());
    }

    private void Update()
    {
        Game();
    }
    public void Game()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _currentCnt++;

                if (_currentCnt >= _count)
                {
                    StopCoroutine(_timerCoroutine);
                    // TODO : Game WIn
                    Debug.Log("Game Win");
                }
            }
        }
    }

    private IEnumerator TimerCoroutine()
    {
        yield return new WaitForSeconds(_delay);

        if (_currentCnt < _count)
        {
            // TODO : Game Over
            Debug.Log("Game Over");
        }
        else
        {
            // TODO : Game WIn
            Debug.Log("Game Win");
        }
    }
}