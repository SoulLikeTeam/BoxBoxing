using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    private const float minXPos = -10; // �Ŀ� ����
    private const float maxXPos = 10;

    public float MinXPos => minXPos;
    public float MaxXPos => maxXPos;

    [SerializeField]
    private GameObject _enemyPrefab;
    private Poolable _enemy;
    private Poolable _player; // �÷��̾ Ǯ��

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
        _enemy = Managers.Pool.Pop(_enemyPrefab);
        //_enemy = Managers.Resource.Load();
        _enemy.transform.position = Vector3.zero;

        Debug.Log("�÷��̾� ����");
        Debug.Log("1�� ��...");

        _enemy.GetComponent<Enemy>().IsBattle = true;
    }

    private void Update()
    {
        // ����׿� �ڵ� 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("�� ���");
            GetNextEnemy();
        }
    }

    public override void Clear()
    {
        
    }
}
