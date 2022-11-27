using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Reflection;
using FD.Interfaces;
using FD.Program.Core;

namespace FD.Program.Pool
{

    public class FAED_Pool
    {

        private Stack<GameObject> pool;
        private GameObject poolObj;
        private Transform parent;
        private string poolName;

        public FAED_Pool(GameObject obj, int poolCount, string poolName, Transform parent)
        {
            
            pool = new Stack<GameObject>();
            poolObj = obj;
            this.poolName = poolName;
            this.parent = parent;

            for(int i = 0; i < poolCount; i++)
            {
                
                GameObject thisObj = Object.Instantiate(obj);
                thisObj.gameObject.name = poolName;
                thisObj.transform.parent = parent;
                thisObj.gameObject.SetActive(false);
                pool.Push(thisObj);

            }

        }

        public void Push(GameObject obj)
        {

            if(obj.GetComponent<IPoolInit>() != null)
            {

                obj.GetComponent<IPoolInit>().Init();

            }
            
            obj.transform.parent = parent;
            obj.SetActive(false);
            pool.Push(obj);

        }

        public GameObject Pop(Vector3 pos, Quaternion rot)
        {

            if(pool.Count <= 0)
            {

                GameObject obj = Object.Instantiate(poolObj, pos, rot);
                obj.name = poolName;
                
                return obj;

            }
            else
            {

                GameObject obj = pool.Pop();

                obj.transform.parent = FAED_Core.scene.transform;
                obj.transform.SetParent(null);

                obj.transform.SetPositionAndRotation(pos, rot);
                obj.SetActive(true);

                return obj;

            }

        }

    }

}


