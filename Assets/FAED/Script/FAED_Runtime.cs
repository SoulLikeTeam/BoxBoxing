using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using FD.Program.SO;
using System.IO;

namespace FD.Program.Runtime
{

#if UNITY_EDITOR

    [InitializeOnLoad]
    internal class FAED_Set
    {

        static FAED_Set()
        {            

            if(Directory.Exists(string.Format("{0}/{1}", Application.dataPath,@"\Resources\FAED")) == false)
            {

                Directory.CreateDirectory(string.Format("{0}/{1}", Application.dataPath, @"\Resources\FAED"));

            }
            
            if(Resources.Load<FAED_Setting>(@"FAED\SettingData") == null)
            {
                
                AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<FAED_Setting>(), "Assets/Resources/FAED/SettingData.Asset");
                
            }

        }

    }

#endif

}
