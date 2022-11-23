using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    private const float minXPos = -10; // 후에 수정
    private const float maxXPos = 10;

    public float MinXPos => minXPos;
    public float MaxXPos => maxXPos;

    private Poolable _enemy;
    private Poolable _player;

    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;

        GetNextEnemy();
    }

    public void GetNextEnemy()
    {
        // 풀매니저 이용하서 다음 적 생성
        // 하고 기초 세팅
        // 이 시간동안은 입력 막기
        // Debug.Log("적 생성");
        _enemy = Managers.Pool.Pop("Enemy");
        //_enemy = Managers.Resource.Load();
        _enemy.transform.position = Vector3.zero + Vector3.right * 5;

        StartCoroutine(PlayerSpawnCoroutine(1f));
    }

    private IEnumerator PlayerSpawnCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);

        _player = new GameObject { name = "Player" }.AddComponent<Poolable>();
        _player.transform.position = Vector3.zero + Vector3.left * 5;

        _enemy.GetComponent<Enemy>().IsBattle = true;
        _enemy.GetComponentInChildren<PABrain>().SetTarget(_player.gameObject);
    }

    private void Update()
    {
        // 디버그용 코드 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("적 사망");
            //GetNextEnemy();

            Managers.Pool.Push(_enemy);
            _enemy = null;
        }
    }

    public override void Clear()
    {
        if(_enemy != null)
        {
            Managers.Pool.Push(_enemy);
            _enemy = null;
        }

        if(_player != null)
        {
            Managers.Pool.Push(_player);
            _player = null;
        }
    }
}
