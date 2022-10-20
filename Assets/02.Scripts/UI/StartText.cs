using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class StartText : MonoBehaviour
{
    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();

        TweenParams tParams = new TweenParams().SetEase(Ease.OutQuad).SetLoops(-1, LoopType.Yoyo);

        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOScale(new Vector3(0.8f, 0.8f, 1), 0.5f).SetAs(tParams));
        seq.Join(text.DOFade(0.6f, 0.5f).SetAs(tParams));
    }
}
