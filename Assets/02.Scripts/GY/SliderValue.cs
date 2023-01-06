using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour
{
    Text valueText;
    private Slider _volumeSlider;

    [SerializeField]
    private bool isSfx = true;

    private void Awake()
    {

        _volumeSlider = GetComponentInParent<Slider>();

        if (isSfx)
            _volumeSlider.value = PlayerPrefs.GetFloat("SFX");
        else
            _volumeSlider.value = PlayerPrefs.GetFloat("BG");

    }

    void Start()
    {
        valueText = GetComponent<Text>();


    }
    //public void valueUpdate(float value)
    //{
    //    valueText.text = Mathf.RoundToInt(value * 100) + "%";
    //}

    public void UpdateValue(float value)
    {
        //if (isSfx)
        //    PlayerPrefs.SetFloat("SFX", _volumeSlider.value);
        //else
        //    PlayerPrefs.SetFloat("BG", _volumeSlider.value);

        if (isSfx)
            PlayerPrefs.SetFloat("SFX", value);
        else
            PlayerPrefs.SetFloat("BG", value);
    }
}
