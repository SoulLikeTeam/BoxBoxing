using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PABrain : MonoBehaviour
{
    [SerializeField]
    private GameObject _target;

    public GameObject Target => _target;

    private GameObject _enemy;
    public GameObject Enemy => _enemy;

    private PAState _beforeState;
    [SerializeField]
    private PAState _currentState;

    private float stateDuractionTime = 0f;
    public float StateDuractionTime => stateDuractionTime;

    //[SerializeField]
    //private List<PAConditionPair> _globlTransitionList;

    [SerializeField]
    private PAState _anyState;

    public void SetTarget(GameObject target)
    {
        _target = target;
    }

    public PAState GetCurrentState()
    {
        return _currentState;
    }

    public PAState GetBeforeState()
    {
        return _beforeState;
    }

    public void ChangeState(PAState state)
    {
        if (_currentState == state)
            return;

        stateDuractionTime = 0f;
        _beforeState = _currentState;
        _beforeState.OnStateLeave();
        _currentState = state;
        _currentState.OnStateEnter();
    }

    public void Awake()
    {
        _enemy = transform.parent.gameObject;

        _beforeState = null;
    }

    private void Start()
    {
        _currentState.OnStateEnter();
    }

    private void Update()
    {
        if (_target != null)
        {
            _anyState.PlayerAction();
            _currentState.PlayerAction();
            stateDuractionTime += Time.deltaTime;
        }
        else
        {
            return;
        }
    }

    private void LateUpdate()
    {
        PAConditionPair nextCondition = null;
        if (_anyState != null)
        {
            foreach (PAConditionPair pair in _anyState._transitionList)
            {
                if (pair.condition.Count == 0) continue;

                bool isTransition = false;
                for (int i = 0; i < pair.condition.Count; i++)
                {
                    if (pair.condition[i].condition == null)
                    {
                        Debug.Log($"{pair.condition[i]} 의 Condition이 Null입니다.");
                        continue;
                    }

                    if (pair.condition[i].condition.IfCondition(_currentState, pair.nextState) ^ pair.condition[i].not == true)
                    {
                        isTransition = true;
                    }
                    else
                    {
                        isTransition = false;
                        break;
                    }
                }

                if (isTransition == true)
                {
                    if (nextCondition == null)
                    {
                        nextCondition = pair;
                    }
                    else
                    {
                        if (nextCondition.nextState == GetBeforeState()) continue;
                        if (pair.priority > nextCondition.priority)
                        {
                            nextCondition = pair;
                        }
                    }
                }
            }

            if (nextCondition != null)
            {
                ChangeState(nextCondition.nextState);
                return;
            }
        }

        foreach (PAConditionPair pair in _currentState._transitionList)
        {
            if (pair.condition.Count == 0) continue;

            bool isTransition = false;
            for (int i = 0; i < pair.condition.Count; i++)
            {
                if (pair.condition[i].condition == null)
                {
                    Debug.Log($"Condition List에 Null인 Condition이 있습니다.");
                    continue;
                }

                if (pair.condition[i].condition.IfCondition(_currentState, pair.nextState) ^ pair.condition[i].not == true)
                {
                    isTransition = true;
                }
                else
                {
                    isTransition = false;
                    break;
                }
            }

            if (isTransition == true)
            {
                if (nextCondition == null)
                {
                    nextCondition = pair;
                }
                else
                {
                    if (nextCondition.nextState == GetBeforeState()) continue;
                    if (pair.priority > nextCondition.priority)
                    {
                        nextCondition = pair;
                    }
                }
            }
        }

        if (nextCondition != null)
        {
            ChangeState(nextCondition.nextState);
        }
    }
}
