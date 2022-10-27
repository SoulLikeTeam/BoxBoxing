using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;

[System.Serializable]
public class RateOfReaction
{
    public float rate;
    public int count;
}

public enum AILevel
{
    Easy,
    Normal,
    Hard,
    Custom
}

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private AILevel aiLevel;

    [SerializeField, Foldout("Custom Level")]
    private List<RateOfReaction> rateOfReactions = new List<RateOfReaction>();

    [SerializeField, Foldout("Not Custom Level")] private List<RateOfReaction> easyRate = new List<RateOfReaction>();
    [SerializeField, Foldout("Not Custom Level")] private List<RateOfReaction> normalRate = new List<RateOfReaction>();
    [SerializeField, Foldout("Not Custom Level")] private List<RateOfReaction> hardRate = new List<RateOfReaction>();

    private List<float> rateList = new List<float>();
    private float rate;

    private void Start()
    {
        rateList.Clear();

        switch (aiLevel)
        {
            case AILevel.Easy:
                for (int i = 0; i < easyRate.Count; i++)
                {
                    for (int j = 0; j < easyRate[i].count; j++)
                    {
                        rateList.Add(easyRate[i].rate);
                    }
                }
                break;
            case AILevel.Normal:
                for (int i = 0; i < normalRate.Count; i++)
                {
                    for (int j = 0; j < normalRate[i].count; j++)
                    {
                        rateList.Add(normalRate[i].rate);
                    }
                }
                break;
            case AILevel.Hard:
                for (int i = 0; i < hardRate.Count; i++)
                {
                    for (int j = 0; j < hardRate[i].count; j++)
                    {
                        rateList.Add(hardRate[i].rate);
                    }
                }
                break;
            case AILevel.Custom:
                for (int i = 0; i < rateOfReactions.Count; i++)
                {
                    for (int j = 0; j < rateOfReactions[i].count; j++)
                    {
                        rateList.Add(rateOfReactions[i].rate);
                    }
                }
                break;
        }

        

        rate = GetNextRate();
    }

    public IEnumerator Guard()
    {
        yield return new WaitForSeconds(rate);
        //OnGuardEvent?.Invoke();
    }

    private float GetNextRate()
    {
        return rateList[Random.Range(0, rateList.Count)];
    }
}