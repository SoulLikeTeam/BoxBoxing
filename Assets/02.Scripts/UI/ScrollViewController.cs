using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewController : MonoBehaviour
{
    private ScrollRect scrollRect;

    private void Start()
    {
        scrollRect = GetComponent<ScrollRect>();

        scrollRect.onValueChanged.AddListener((e) => Debug.Log("On Value Changed"));
    }
}
