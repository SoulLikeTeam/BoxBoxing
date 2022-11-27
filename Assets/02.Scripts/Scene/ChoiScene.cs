using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiScene : BaseScene
{

    [SerializeField] private GameObject effectPrefab;

    protected override void Init()
    {

        base.Init();
        Managers.Pool.CreatePool(effectPrefab, 10);

    }

    public override void Clear()
    {
    }
}
