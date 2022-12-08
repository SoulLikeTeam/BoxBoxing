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

    public void ChangeStageScene()
    {
        Managers.Scene.LoadScene(Define.Scene.Stage);
    }

    public override void Clear()
    {
        
    }
}
