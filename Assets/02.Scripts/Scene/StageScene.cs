using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StageScene : BaseScene
{
    private AllStageInfo _stageInfo;

    [SerializeField]
    private Transform _content;

    private List<Poolable> stageUIList = new List<Poolable>();

    protected override void Init()
    {
        SceneType = Define.Scene.Stage;

        _stageInfo = Managers.Save.LoadJsonFile<AllStageInfo>();

        // UI 생성
        for (int i = 0; i < /*_stageInfo.stageInfo.Count*/3; i++)
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
            stageUIList.Add(stage.GetComponent<Poolable>());
        }
    }

    public override void Clear()
    {
        // 닷트원 kill하기
        foreach (Poolable stage in stageUIList)
        {
            StageUI stageUI = stage.GetComponent<StageUI>();
            stageUI.Reset();
            Managers.Pool.Push(stage);
        }
    }
}
