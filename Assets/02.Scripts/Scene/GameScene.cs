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

    public void GameOver() // 이걸 여기에 만드는게 맞나..?
    {
        Managers.Scene.LoadScene(Define.Scene.Over);
    }

    public void GetNextEnemy()
    {
        // 풀매니저 이용하서 다음 적 생성
        // 하고 기초 세팅
        // 이 시간동안은 입력 막기
        Debug.Log("적 생성");
    }

    private void Update()
    {
        // 디버그용 코드 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("적 사망");
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
