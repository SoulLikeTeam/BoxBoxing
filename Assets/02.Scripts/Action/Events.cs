using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Events : MonoBehaviour
{

    private void Awake()
    {

        Save();

    }

    public void Save()
    {

        StartCoroutine(SaveCo());

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

        if (i)
        {

            Managers.Save.SaveJson(new AllStageInfo());

        }

    }

}
