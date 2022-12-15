using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FD.Feature
{

    public class FAED_Random
    {
        
        public T RandomValue<T>(T[] arr)
        {

            int max = arr.Length;
            int num = Random.Range(0, max);
            return arr[num];

        }

        public T RandomValue<T>(List<T> arr)
        {

            int max = arr.Count;
            int num = Random.Range(0, max);
            return arr[num];

        }

        public T RandomValueEnum<T>() where T : System.Enum
        {

            List<T> arr = new List<T>();

            foreach (T t in System.Enum.GetValues(typeof(T)))
            {

                arr.Add(t);

            }
            
            return RandomValue(arr);

        }

    }

}

