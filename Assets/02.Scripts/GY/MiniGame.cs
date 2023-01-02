using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class MiniGame : MonoBehaviour
{
    int i;

    private int _count = 100;
    private int _currentCnt = 0;

    [SerializeField]
    private Vector2 inputArea;

    private Camera _mainCam;

    private void Start()
    {
        _mainCam = Camera.main;
    }

    private void OnEnable()
    {
        _currentCnt = 0;
    }

    private void Update()
    {
        Game();
    }
    public void Game()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 mouserPos = Input.mousePosition;

            mouserPos = _mainCam.ScreenToWorldPoint(mouserPos);

            if (mouserPos.x >= inputArea.x - inputArea.x / 2 && mouserPos.x <= inputArea.x + inputArea.x / 2
                && mouserPos.y >= inputArea.y - inputArea.y / 2 && mouserPos.y <= inputArea.y + inputArea.y / 2)
            {
                _currentCnt++;
            }


            if (_currentCnt >= _count)
            {
                // TODO : Game WIn
            }
        }
        //yield return new WaitForSeconds(0.1f);
    }

    private IEnumerator TimerCoroutine()
    {
        yield return new WaitForSeconds(10f);

        if (_currentCnt < _count)
        {
            // TODO : Game Over
        }
        else
        {
            // TODO : Game WIn
        }
    }
#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, inputArea);
        Gizmos.color = Color.white;
    }
#endif
}