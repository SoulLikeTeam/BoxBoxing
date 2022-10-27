using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameOverText : MonoBehaviour
{
    private void OnEnable()
    {
        GameOverTextEffect();
    }

    public void GameOverTextEffect()
    {
        TweenParams tParam = new TweenParams().SetEase(Ease.OutBounce);
        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOLocalMove(Vector3.zero, 0.7f).SetAs(tParam));
        //seq.Append(transform.DOLocalMove(new Vector3(0, 1, 0), 0.3f));
        //seq.Append(transform.DOLocalMove(Vector3.zero, 0.3f));
    }
}
