using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour
{
    Text valueText;
    private Slider _volumeSlider;

    [SerializeField]
    private bool isSfx = true;

    void Start()
    {
        valueText = GetComponent<Text>();
        _volumeSlider = GetComponentInParent<Slider>();

        if (isSfx)
            SoundManager.instance.SetSfxVolume(_volumeSlider.value);
        else
            SoundManager.instance.SetBgmVolume(_volumeSlider.value);
    }
    public void valueUpdate(float value)
    {
        valueText.text = Mathf.RoundToInt(value * 100) + "%";
    }
}
