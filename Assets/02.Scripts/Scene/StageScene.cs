using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StageScene : BaseScene
{
    [SerializeField]
    private StageListController stageUIController;

    protected override void Init()
    {
        SceneType = Define.Scene.Stage;

        stageUIController.Init();

        stageUIController.CreateUI();

        StartCoroutine(stageUIController.StageUIMove(stageUIController.StageUIEffect));
    }

    public void MenuScene()
    {
        Managers.Scene.LoadScene(Define.Scene.Menu);
    }

    public override void Clear()
    {
        stageUIController.Clear();
    }
}
