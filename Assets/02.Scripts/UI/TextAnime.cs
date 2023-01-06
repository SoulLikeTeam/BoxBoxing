using DG.Tweening;
using FD.Dev;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

#region Class

[Serializable]
public class Round1Class
{

    public Image baseImage;
    public Sprite round1Sprite;
    public Sprite fightSprite;
    public UnityEvent endAction;
}

[Serializable]
public class Round2Class
{

    public Image baseImage;
    public Sprite round2Sprite;
    public Sprite fightSprite;
    public UnityEvent endAction;
}

[Serializable]
public class Round3Class
{

    public Image baseImage;
    public Sprite round3Sprite;
    public Sprite fightSprite;
    public UnityEvent endAction;
}

[Serializable]
public class Down
{

    public Image baseImage;
    public Sprite downSprite;
    public UnityEvent downEvent;

}

[Serializable]
public class KO
{

    public Image baseImage;
    public Sprite koSprite;
    public Sprite winSprite;
    public Sprite loseSprite;
    public UnityEvent endEvent;

}

#endregion

public class TextAnime : MonoBehaviour
{

    [SerializeField] private Round1Class round1;
    [SerializeField] private Round2Class round2;
    [SerializeField] private Round3Class round3; 
    [SerializeField] private Down down;
    [SerializeField] private KO ko; 

    public void Round(int round)
    {

        Action action = round switch
        {

            1 => R1,
            2 => R2,
            3 => R3,
            _ => R3

        };

        action?.Invoke();

    }

    public void R1()
    {

        round1.baseImage.sprite = round1.round1Sprite;


        Sequence sequence = DOTween.Sequence();

        sequence
            .Append(round1.baseImage.transform.DOLocalMoveX(0, 0.5f))
            .AppendInterval(0.3f)
            .AppendCallback(() => SoundManager.instance.SFXPlay(12))
            .AppendInterval(1.5f)
            .AppendCallback(() =>
            {

                round1.baseImage.sprite = round1.fightSprite;

            })
            .AppendInterval(0.5f)
            .Append(round1.baseImage.transform.DOScale(0, 0.3f).OnComplete(() => { round1.endAction?.Invoke(); }));

    }

    public void R2()
    {

        round2.baseImage.sprite = round2.round2Sprite;


        Sequence sequence = DOTween.Sequence();

        sequence
            .Append(round2.baseImage.transform.DOLocalMoveX(0, 0.5f))
            .AppendInterval(0.1f)
            .AppendCallback(() => SoundManager.instance.SFXPlay(13))
            .AppendInterval(1.5f)
            .AppendCallback(() =>
            {

                round2.baseImage.sprite = round2.fightSprite;

            })
            .AppendInterval(0.5f)
            .Append(round2.baseImage.transform.DOScale(0, 0.3f).OnComplete(() => { round2.endAction?.Invoke(); }));

    }

    public void R3()
    {

        round3.baseImage.sprite = round3.round3Sprite;


        Sequence sequence = DOTween.Sequence();

        sequence
            .Append(round3.baseImage.transform.DOLocalMoveX(0, 0.5f))
            .AppendInterval(0.1f)
            .AppendCallback(() => SoundManager.instance.SFXPlay(11))
            .AppendInterval(1.5f)
            .AppendCallback(() =>
            {

                round3.baseImage.sprite = round3.fightSprite;

            })
            .AppendInterval(0.5f)
            .Append(round3.baseImage.transform.DOScale(0, 0.3f).OnComplete(() => { round3.endAction?.Invoke(); }));

    }

    public void Down()
    {

        down.baseImage.sprite = down.downSprite;
        down.baseImage.transform.localScale = Vector2.zero;
        down.baseImage.transform.DOScale(1, 0.3f);

        FAED.InvokeDelay(() =>
        {

            down.baseImage.gameObject.SetActive(false);
            down.downEvent?.Invoke();

        },1.3f);

    }

    public void KO(bool win, bool clear = false)
    {

        Sprite thisSprite = win switch
        {

            true => ko.winSprite,
            false => ko.loseSprite

        };

        ko.baseImage.sprite = ko.koSprite;

        ko.baseImage.SetNativeSize();

        Sequence sequence = DOTween.Sequence();

        sequence
            .Append(ko.baseImage.transform.DOLocalMoveX(0, 0.5f))
            .AppendInterval(1.2f)
            .AppendCallback(() => { ko.baseImage.sprite = thisSprite; ko.baseImage.SetNativeSize(); })
            .AppendInterval(2f)
            .AppendCallback(() => { ko.endEvent?.Invoke(); FAED.InvokeDelay(() => 
            {

                if (clear) return;
                ko.baseImage.transform.localPosition = new Vector2(-1500, 0); }, 0.3f); 
            });


        if (clear && !win)
        {

            FAED.InvokeDelay(() => Managers.Scene.LoadScene(Define.Scene.Menu), 3f);       

        }
        else if(clear && win)
        {

            FAED.InvokeDelay(() =>
            {

                if(FindObjectOfType<GameScene>()._stageInfo.stageIdx >= 4)
                {

                    Managers.Scene.LoadScene(Define.Scene.Estory);

                }
                else
                {

                    Managers.Scene.LoadScene(Define.Scene.Stage);

                }

            }, 3f);

        }


    }
}
