using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    private const float minXPos = -10; // �Ŀ� ����
    private const float maxXPos = 10;

    public float MinXPos => minXPos;
    public float MaxXPos => maxXPos;

    private Poolable _enemy;
    private Poolable _player;

    private AllStageInfo _stageInfo;

    private bool _battleStart = false;
    private float _stageTimer = 0f;

    protected override void Init()
    {
        SceneType = Define.Scene.Game;

        _stageInfo = Managers.Save.LoadJsonFile<AllStageInfo>();

        _battleStart = false;
        _stageTimer = 0f;

        GetNextEnemy();
    }

    public void GetNextEnemy()
    {
        // �� ����

        // �÷��̾� ����

        // Ÿ�� ����

        // 3�� ī��Ʈ �� ����!

        // �� �ð������� �Է� ����

        SpawnEnemy();
        SpawnPlayer();
    }

    private void SpawnEnemy()
    {
        string enemyPath = "Enemy/Enemy";
        enemyPath += _stageInfo.stageIdx;
        Debug.Log(enemyPath);
        _enemy = Managers.Resource.Instantiate("Enemy/Enemy").GetComponent<Poolable>();

        _enemy.transform.position = Vector3.zero + Vector3.right * 5;
    }

    private void SpawnPlayer()
    {
        _player = Managers.Resource.Instantiate("Player/Player").GetComponent<Poolable>();
        _player.transform.position = Vector3.zero + Vector3.left * 5;

        _player.GetComponent<Movement>().SetTarget(_enemy.gameObject);

        _enemy.GetComponent<Movement>().SetTarget(_player.gameObject);
        _enemy.GetComponentInChildren<PABrain>().SetTarget(_player.gameObject);
        _enemy.GetComponent<Enemy>().IsBattle = true;
        _battleStart = true;
    }

    private void Update()
    {
        // ����׿� �ڵ� 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("�� ���");
            //GetNextEnemy();

            Managers.Pool.Push(_enemy);
            _enemy = null;
        }

        if(_battleStart == true)
        {
            _stageTimer += Time.deltaTime;
        }
    }

    public void EnemyDeath()
    {
        _battleStart = false;

        // �¸� ����Ʈ 
    }

    public void StageClear()
    {
        int idx = _stageInfo.stageIdx;
        _stageInfo.stageInfo[idx].clearTime = _stageTimer;
        _stageInfo.stageInfo[idx].isClear = true;

        // �̾ ���� or �������� ���� ������
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
