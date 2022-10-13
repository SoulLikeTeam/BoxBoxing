using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
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
        Debug.Log("�� ����");
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
