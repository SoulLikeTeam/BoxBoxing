using FD.Program.Core;
using System.Security.Cryptography;
using UnityEngine;
using System;
using UnityEngine.Experimental.GlobalIllumination;
using System.Collections.Generic;

namespace FD.Dev 
{

    public static class FAED
    {
        
        public static void Save(string path, string fileName, object obj)
        {

            FAED_Core.SaveData.Save(path, fileName, obj);

        }
        public static void Save(this object obj, string path, string fileName)
        {

            FAED_Core.SaveData.Save(path, fileName, obj);

        }
        public static T Load<T>(string path, string fileName) where T : new()
        {

            return FAED_Core.SaveData.Load<T>(path, fileName);

        }
        public static void Push(GameObject obj)
        {

            FAED_Core.Pooling.Push(obj);

        }
        public static GameObject Pop(string key, Vector3 pos, Quaternion rot)
        {

            return FAED_Core.Pooling.Pop(key, pos, rot);

        }
        public static void CreatePool(GameObject obj, string poolName, int poolSize)
        {

            FAED_Core.Pooling.CreatePool(obj, poolName, poolSize);

        }
        public static void InvokeDelay(Action action, float delayTime)
        {

            FAED_Core.Feature.SetDelay(action, delayTime);

        }
        public static void InvokeDelayReal(Action action, float delayTime)
        {

            FAED_Core.Feature.SetDelayReal(action, delayTime);

        }
        public static void InvokeDelayFunc(Action action, Func<bool> func)
        {

            FAED_Core.Feature.SetDelayFunc(action, func);

        }
        public static T Random<T>(T[] arr)
        {

            return FAED_Core.Random.RandomValue(arr);

        }
        public static T Random<T>(List<T> arr)
        {

            return FAED_Core.Random.RandomValue(arr);

        }
        public static T RandomEnum<T>() where T : Enum 
        {

            return FAED_Core.Random.RandomValueEnum<T>();

        } 

    }

}


