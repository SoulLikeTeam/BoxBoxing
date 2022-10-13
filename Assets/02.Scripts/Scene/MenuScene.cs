using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Menu;
    }

    public void MoveGameScene()
    {
        Managers.Scene.LoadScene(Define.Scene.Game);
    }

    public override void Clear()
    {
        
    }
}
