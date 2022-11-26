using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers s_instance = null;
    private static Managers Instance { get { Init(); return s_instance; } }

    #region CORE
    private PoolManager _pool = new PoolManager();
    private SaveManager _save = new SaveManager();
    private SceneManagerEX _scene = new SceneManagerEX();
    private ResourceManager _resource = new ResourceManager();

    public static PoolManager Pool { get { return Instance._pool; } }
    public static SaveManager Save { get { return Instance._save; } }
    public static SceneManagerEX Scene { get { return Instance._scene; } }
    public static ResourceManager Resource { get { return Instance._resource; } }
    #endregion

    private void Awake()
    {
        Init();
    }

    static void Init()
    {
        if(s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if(go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();

            s_instance._pool.Init();
            s_instance._save.Init();
        }
    }

    public static void Clear()
    {
        Scene.Clear();

        Pool.Clear();
    }

}
