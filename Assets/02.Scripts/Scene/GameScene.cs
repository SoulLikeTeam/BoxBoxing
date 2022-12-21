using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class GameScene : BaseScene
{
    [SerializeField]
    private Text _countdownText;
    [SerializeField]
    private GameObject _stopPanel;

    private Poolable _enemy;
    private Poolable _player;

    private AllStageInfo _stageInfo;

    private bool _battleStart = false;
    private float _stageTimer = 0f;

    protected override void Init()
    {
        SceneType = Define.Scene.Game;

        _stageInfo = Managers.Save.LoadJsonFile<AllStageInfo>();

        _battleStart = false;
        _stageTimer = 0f;

        GetNextEnemy();

        StartCoroutine(CountDown(() => GameStart()));
    }

    private void GameStart()
    {
        _countdownText.gameObject.SetActive(false);
        _player.GetComponent<PlayerInput>().SetIgnoreInput(false);
        _enemy.GetComponent<Enemy>().IsBattle = true;
        _battleStart = true;
    }

    public void GetNextEnemy()
    {
        // 적 생성

        // 플레이어 생성

        // 타겟 세팅

        // 3초 카운트 후 시작!

        // 이 시간동안은 입력 막기
        SpawnEnemy();
        SpawnPlayer();
        //_player.GetComponent<PlayerInput>().SetIgnoreInput(true);
    }

    private void SpawnEnemy()
    {
        string enemyPath = "Enemy/Enemy";
        enemyPath += _stageInfo.stageIdx;
        _enemy = Managers.Resource.Instantiate(enemyPath).GetComponent<Poolable>();

        _enemy.transform.position = Vector3.zero + Vector3.right * 5;
        
    }

    private void SpawnPlayer()
    {
        _player = Managers.Resource.Instantiate("Player/Player").GetComponent<Poolable>();
        _player.transform.position = Vector3.zero + Vector3.left * 5;

        _player.GetComponent<Movement>().SetTarget(_enemy.gameObject);
        

        _enemy.GetComponent<Movement>().SetTarget(_player.gameObject);
        _enemy.GetComponentInChildren<PABrain>().SetTarget(_player.gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = Time.timeScale == 1 ? 0 : 1;
            _stopPanel.gameObject.SetActive(Time.timeScale == 0);
            // UI 띄우기
        }

        if (_battleStart == true)
        {
            _stageTimer += Time.deltaTime;
        }
    }

    public void ContinueButton()
    {
        Time.timeScale = Time.timeScale == 1 ? 0 : 1;
        _stopPanel.gameObject.SetActive(Time.timeScale == 0);
    }

    public void MenuButton()
    {
        Time.timeScale = Time.timeScale == 1 ? 0 : 1;
        Managers.Scene.LoadScene(Define.Scene.Menu);
    }

    public void RestartButton()
    {
        Time.timeScale = Time.timeScale == 1 ? 0 : 1;
        Managers.Scene.LoadScene(Define.Scene.Game);
    }

    private IEnumerator CountDown(Action action)
    {
        _enemy.GetComponent<Enemy>().IsBattle = false;
        _player.GetComponent<PlayerInput>().SetIgnoreInput(true);

        for (int i = 3; i > 0; i--)
        {
            _countdownText.transform.localScale = Vector3.one;
            _countdownText.text = i.ToString();
            _countdownText.transform.DOScale(Vector3.one * 0.1f, 1f);
            yield return new WaitForSeconds(1);
        }

        _countdownText.transform.localScale = Vector3.one;
        _countdownText.text = "Game Start!";
        yield return new WaitForSeconds(0.5f);
        action?.Invoke();
    }

    public bool StageClear()
    {
        int idx = _stageInfo.stageIdx;
        _stageInfo.stageInfo[idx].clearTime = _stageTimer;
        _stageInfo.stageInfo[idx].isClear = true;

        if(_stageInfo.stageIdx == 4)
        {
            Managers.Save.DeleteFile();
            return true;
        }
        else
        {
            _stageInfo.stageIdx++;
            Managers.Save.SaveJson(_stageInfo);
            return false;
        }
    }

    public override void Clear()
    {
        _battleStart = false;

        if (_enemy != null)
        {
            Managers.Pool.Push(_enemy);
            _enemy = null;
        }

        if (_player != null)
        {
            Managers.Pool.Push(_player);
            _player = null;
        }
    }
}
