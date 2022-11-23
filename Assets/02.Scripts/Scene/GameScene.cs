using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    private const float minXPos = -10; // 후에 수정
    private const float maxXPos = 10;

    public float MinXPos => minXPos;
    public float MaxXPos => maxXPos;

    [SerializeField]
    private GameObject _enemyPrefab;
    private Poolable _enemy;
    private Poolable _player; // 플레이어도 풀링

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
        _enemy = Managers.Pool.Pop(_enemyPrefab);
        //_enemy = Managers.Resource.Load();
        _enemy.transform.position = Vector3.zero;

        Debug.Log("플레이어 생성");
        Debug.Log("1초 후...");

        _enemy.GetComponent<Enemy>().IsBattle = true;
    }

    private void Update()
    {
        // 디버그용 코드 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("적 사망");
            GetNextEnemy();
        }
    }

    public override void Clear()
    {
        
    }
}
