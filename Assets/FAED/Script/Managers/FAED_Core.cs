using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FD.Program.Managers;
using FD.Program.SO;
using FD.Feature;

namespace FD.Program.Core
{

    public class FAED_Core : MonoBehaviour
    {

        private static FAED_Core instance;
        private static FAED_PoolManager poolManager;
        private static FAED_SaveManager saveManager;
        private static FAED_Feature feature;

        public static FAED_Core Instance { get { Init(); return instance; } }
        public static FAED_PoolManager Pooling { get { Init(); return poolManager; } }
        public static FAED_SaveManager SaveData { get { Init(); return saveManager; } }
        public static FAED_Feature Feature { get { Init(); return feature; } }

        public static Transform scene;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Init()
        {

            if (instance == null)
            {

                GameObject go = GameObject.Find("@FAED_Core");

                if (go == null)
                {
                     
                    go = new GameObject { name = "@FAED_Core" };
                    go.AddComponent<FAED_Core>();
                    go.AddComponent<FAED_Feature>();
                    feature = go.GetComponent<FAED_Feature>();

                }

                DontDestroyOnLoad(go);
                SetManager(go.transform);
                instance = go.GetComponent<FAED_Core>();

            }

            if(GameObject.Find("@FAED_Scene") == null)
            {

                scene = new GameObject() { name = "@FAED_Scene" }.transform;

            }

        }

        private static void SetManager(Transform parent)
        {

            GameObject poolManagerObj = GameObject.Find("@FAED_PoolManager");
            if(poolManagerObj == null)
            {

                FAED_PoolingData data = Resources.Load<FAED_Setting>("FAED/SettingData").poolData;
                poolManagerObj = new GameObject { name = "@FAED_PoolManager" };

                poolManager = new FAED_PoolManager(poolManagerObj.transform);
                DontDestroyOnLoad(poolManagerObj);

                poolManagerObj.transform.parent = parent;
                
                if(data != null)
                {

                    for(int i = 0; i < data.poolingList.Count; i++)
                    {

                        poolManager.CreatePool(data.poolingList[i].poolObj, data.poolingList[i].poolName, data.poolingList[i].poolSize);

                    }

                }



            }

            if(saveManager == null)
            {

                saveManager = new FAED_SaveManager();

            }

        }


    }

}


