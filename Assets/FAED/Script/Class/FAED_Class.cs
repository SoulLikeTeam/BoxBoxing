using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FD.Program.Class
{

    [System.Serializable]
    public class FAED_PoolingList
    {

        public string poolName; // 얘가 아래 오브젝트의 이름이랑 같다면 굳이 따로 뺄 필요없지 않나?
        public GameObject poolObj;
        public int poolSize;

    }

}
