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

    public void GameOver() // �̰� ���⿡ ����°� �³�..?
    {
        Managers.Scene.LoadScene(Define.Scene.Over);
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

        if (Input.GetKeyDown(KeyCode.F))
        {
            GameOver();
        }
    }

    public override void Clear()
    {
        
    }
}
