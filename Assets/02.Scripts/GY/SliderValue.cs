using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour
{
    Text valueText;

    void Start()
    {
        valueText = GetComponent<Text>();
    }
    public void valueUpdate(float value)
    {
        valueText.text = Mathf.RoundToInt(value * 100) + "%";
    }
}
