using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScene : BaseScene
{
    private AllStageInfo _stageInfo;

    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Menu;

        _stageInfo = Managers.Save.LoadJsonFile<AllStageInfo>();
    }

    public void ChangeStageScene()
    {
        if (_stageInfo.stageIdx >= 5)
        {
            Managers.Save.DeleteFile();
        }

        Managers.Scene.LoadScene(Define.Scene.Stage);
    }

    public override void Clear()
    {
        
    }
}
