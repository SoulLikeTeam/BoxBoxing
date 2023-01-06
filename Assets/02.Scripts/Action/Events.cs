using FD.Dev;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Events : MonoBehaviour
{

    public AudioSource[] audios;
    public bool isSave = true;

    private void Awake()
    {

        SetBG();
        if (!isSave) return;
        Save();

    }

    private void Update()
    {

        SetBG();

    }

    private void SetBG()
    {
        
        foreach(var item in audios)
        {

            item.volume = PlayerPrefs.GetFloat("BG");

        }

    }

    public void Save()
    {

        StartCoroutine(SaveCo());

    }

    public void Exit()
    {

        Application.Quit();

    }

    IEnumerator SaveCo()
    {

        yield return null;

        bool i = false;

        if(Managers.Save.LoadJsonFile<AllStageInfo>() != null)
        {

            i = true;

        }

        yield return new WaitForSeconds(0.01f);

        if (!i)
        {

            Managers.Save.SaveJson(new AllStageInfo());

        }

    }

}
