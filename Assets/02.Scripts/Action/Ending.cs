using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{

    [SerializeField] private GameObject so;
    [SerializeField] private AudioSource source;
    [SerializeField] private Image image;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(A());

        Sequence sequence = DOTween.Sequence();

        sequence
            .AppendInterval(1.3f)
            .Append(so.transform.DOMoveY(1560f, 6f).OnComplete(() =>
            {

                image.DOFade(1, 0.5f).OnComplete(() => Managers.Scene.LoadScene(Define.Scene.Menu));

            }));

    }

    IEnumerator A()
    {

        while(source.volume > 0)
        {

            source.volume -= 0.001f;
            yield return new WaitForSeconds(0.01f);

        }

    }

}
