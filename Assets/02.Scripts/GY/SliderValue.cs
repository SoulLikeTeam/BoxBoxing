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

    private void Awake()
    {

        if(PlayerPrefs.GetInt("Start") != 1)
        {

                PlayerPrefs.SetFloat("SFX", 1);
                PlayerPrefs.SetFloat("BG", 1);
            PlayerPrefs.SetInt("Start", 1);

        }

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
