using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageScene : BaseScene
{
    private AllStageInfo _stageInfo;

    [SerializeField]
    private Transform _content;

    protected override void Init()
    {
        SceneType = Define.Scene.Stage;

        _stageInfo = Managers.Save.LoadJsonFile<AllStageInfo>();

        // UI »ý¼º
        for(int i = 0; i < /*_stageInfo.stageInfo.Count*/3; i++)
        {
            GameObject stage = Managers.Resource.Instantiate("UI/Stage", _content);
            StageUI stageUI = stage.GetComponent<StageUI>();
            stageUI.SetStageNum(i);
            stageUI.SetScale(i != 0);
            //stageUI.SetInfo(_stageInfo.stageInfo[i]);
            Button btn = stage.GetComponentInChildren<Button>();
            btn.onClick.AddListener(() =>
            {
                _stageInfo.stageIdx = stageUI.GetStageNum();
                Managers.Save.SaveJson<AllStageInfo>(_stageInfo);
                Debug.Log(_stageInfo.stageIdx);
                Managers.Scene.LoadScene(Define.Scene.Game);
            });
        }
    }

    public override void Clear()
    {
        
    }
}
