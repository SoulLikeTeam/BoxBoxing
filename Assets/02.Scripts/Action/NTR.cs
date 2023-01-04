using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NTR : MonoBehaviour
{

    [SerializeField] private Sprite[] sprites;
    [SerializeField] private Image image;

    private int spriteCount = 0;

    public void Click()
    {

        spriteCount++;

        if(spriteCount < sprites.Length)
        {

            image.sprite = sprites[spriteCount];

        }
        else
        {

            Managers.Scene.LoadScene(Define.Scene.Tplay);

        }

    }

}
