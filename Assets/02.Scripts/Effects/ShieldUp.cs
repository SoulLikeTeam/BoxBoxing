using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUp : MonoBehaviour
{

    [SerializeField] private Sprite sprite;
    [SerializeField] private SpriteRenderer spriteRenderer;

    public void Shield()
    {

        spriteRenderer.sprite = sprite;

    }

}
