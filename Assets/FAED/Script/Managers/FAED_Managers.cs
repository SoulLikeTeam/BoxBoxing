using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using FD.Program.Pool;

namespace FD.Program.Managers
{

    public class FAED_SaveManager
    {
    
        public void Save(string path, string fileName, object obj)
        {

            FileStream fs = new FileStream(string.Format("{0}/{1}.json", path, fileName), FileMode.Create);
            byte[] data = Encoding.UTF8.GetBytes(JsonUtility.ToJson(obj));
            fs.Write(data, 0, data.Length);

        }

        public T Load<T>(string path, string fileName) where T : new()
        {

            if (Directory.Exists(path) == false)
            {

                Directory.CreateDirectory(path);

            }

            if(File.Exists(string.Format("{0}/{1}.json", path, fileName)) == false)
            {

                Save(path, fileName, new T());

            }

            FileStream fs = new FileStream(string.Format("{0}/{1}.json", path, fileName), FileMode.Open);
            byte[] data = new byte[fs.Length];

            fs.Read(data, 0, data.Length);
            fs.Close();

            string value = Encoding.UTF8.GetString(data);

            return JsonUtility.FromJson<T>(value);

        }

    }

    public class FAED_PoolManager
    {

        private Dictionary<string, FAED_Pool> pools = new Dictionary<string, FAED_Pool>();
        private Transform parent;

        public FAED_PoolManager(Transform parent)
        {

            this.parent = parent;

        }

        public void CreatePool(GameObject obj, string key, int poolCount = 10)
        {

            if (pools.ContainsKey(key) == false)
            {

                FAED_Pool pool = new FAED_Pool(obj, poolCount, key, parent);
                pools[key] = pool;

            }
            else
            {

                Debug.LogWarning($"FAED PoolManager : {key} pools is already exists");

            }

        }

        public void Push(GameObject obj)
        {

            if (pools.ContainsKey(obj.name))
            {

                pools[obj.name].Push(obj);

            }
            else
            {

                CreatePool(obj, obj.name, 1);
                pools[obj.name].Push(obj);

            }

        }

        public GameObject Pop(string key, Vector3 pos, Quaternion rot)
        {

            if (pools.ContainsKey(key))
            {

                return pools[key].Pop(pos, rot);

            }
            else
            {

                Debug.LogWarning($"FAED PoolManager : {key} pool is does not exist");

                return null;

            }

        }

    }

    public class FAED_AudioManager
    {



    }

}


