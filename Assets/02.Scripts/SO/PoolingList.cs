using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolPair
{
    public GameObject poolObject;
    public int count = 5;
}

[CreateAssetMenu(menuName = "SO/System/Pool")]
public class PoolingList : ScriptableObject
{
    public List<PoolPair> List;
}
