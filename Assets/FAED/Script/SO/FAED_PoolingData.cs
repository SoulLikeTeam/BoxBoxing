using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FD.Program.Class;

namespace FD.Program.SO
{

    [CreateAssetMenu(menuName = "FAED/PoolingData")]
    public class FAED_PoolingData : ScriptableObject
    {

        public List<FAED_PoolingList> poolingList;

    }

}
