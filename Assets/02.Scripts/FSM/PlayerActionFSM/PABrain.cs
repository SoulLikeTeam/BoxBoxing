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

    private PAState _nextState;

    [SerializeField]
    private List<PAConditionPair> _globlTransitionList;

    public void SetTarget(GameObject target)
    {
        _target = target;
    }

    public PAState GetCurrentState()
    {
        return _currentState;
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

        SetNextState();
    }

    #region Next State Get Set
    public void SetNextState(PAState state)
    {
        _nextState = state;
    }

    public void SetNextState()
    {
        int rndIdx = Random.Range(0, _currentState._transitionList.Count);
        PAState nextState = _currentState._transitionList[rndIdx].nextState;
        _nextState = nextState;
    }

    public PAState GetNextState()
    {
        return _nextState;
    }
    #endregion

    public void Awake()
    {
        _enemy = transform.parent.gameObject;

        _beforeState = null;
        _nextState = null;
    }

    private void Start()
    {
        _currentState.OnStateEnter();
    }

    private void Update()
    {
        if (_target != null)
        {
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
        foreach (PAConditionPair pair in _globlTransitionList)
        {
            if (pair.condition.Count == 0) continue;

            bool isTransition = false;
            for (int i = 0; i < pair.condition.Count; i++)
            {
                if (pair.condition[i].condition.IfCondition(_currentState, pair.nextState) == (pair.condition[i].not == true ? false : true))
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
        else
        {
            foreach (PAConditionPair pair in _currentState._transitionList)
            {
                if (pair.condition.Count == 0) continue;

                bool isTransition = false;
                for (int i = 0; i < pair.condition.Count; i++)
                {
                    if (pair.condition[i].condition.IfCondition(_currentState, pair.nextState) == (pair.condition[i].not == true ? false : true))
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
}
