using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageScene : BaseScene
{
    private AllStageInfo _stageInfo;

    [SerializeField]
    private Transform _context;

    protected override void Init()
    {
        Managers.Pool.CreatePool(Managers.Resource.Load<GameObject>("UI/Stage"));

        SceneType = Define.Scene.Stage;

        _stageInfo = Managers.Save.LoadJsonFile<AllStageInfo>();

        // UI 생성
        for(int i = 0; i < 3; i++)
        {
            Poolable stage = Managers.Pool.Pop("UI/Stage", _context);
            StageUI stageUI = stage.GetComponent<StageUI>();
            stageUI.SetStageNum(i);
        }
        // UI 연결
    }



    public override void Clear()
    {
        
    }
}
