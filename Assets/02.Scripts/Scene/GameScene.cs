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

    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;

        GetNextEnemy();
    }

    public void GetNextEnemy()
    {
        // Ǯ�Ŵ��� �̿��ϼ� ���� �� ����
        // �ϰ� ���� ����
        // �� �ð������� �Է� ����
        // Debug.Log("�� ����");
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
        // ����׿� �ڵ� 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("�� ���");
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
