using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MiniGame : MonoBehaviour
{
    [SerializeField]
    private int _count = 100;
    private int _currentCnt = 0;

    SpriteRenderer _spriteRenderer;

    [SerializeField]
    private float _delay = 10f;

    private Coroutine _timerCoroutine;

    public Sprite[] sprites = new Sprite[0];
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
        _spriteRenderer = GetComponent<SpriteRenderer>(); 
        if (EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _currentCnt++;
                
                if (_currentCnt == _count/5)
                {
                    _spriteRenderer.sprite = sprites[0];
                }

                if(_currentCnt == _count/10*4)
                {
                    _spriteRenderer.sprite = sprites[1];
                }

                if(_currentCnt == _count/10*6)
                {
                    _spriteRenderer.sprite = sprites[2];
                }

                if (_currentCnt == _count/10*8)
                {
                    _spriteRenderer.sprite = sprites[3];
                }
            }
            if (_currentCnt >= _count)
                {
                    StopCoroutine(_timerCoroutine);

                _spriteRenderer.sprite = sprites[4];

                    // TODO : Game WIn
                    Debug.Log("Game Win");
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
            // TODO : Revive
            Debug.Log("Revive");
        }
    }
}