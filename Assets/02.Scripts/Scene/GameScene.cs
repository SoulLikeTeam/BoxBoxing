using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using Unity.VisualScripting;
using FD.Dev;

public class GameScene : BaseScene
{
    [SerializeField]
    private Image _countdownImage;
    [SerializeField]
    private GameObject _stopPanel;
    [SerializeField] private TextAnime textAnime;
    [SerializeField] private bool isNTR; 

    [SerializeField]
    private Sprite[] _countdownTextList;
    [SerializeField]
    private Sprite[] _gameResultTextList;

    private Poolable _enemy;
    private Poolable _player;

    private AllStageInfo _stageInfo;

    private int _clearCount = 1;
    private int _playerWinCount = 0;
    private int _enemyWinCount = 0;
    private bool _battleStart = false;
    private float _stageTimer = 0f;

    protected override void Init()
    {


        SceneType = Define.Scene.Game;

        if (!isNTR)
        {

            _stageInfo = Managers.Save.LoadJsonFile<AllStageInfo>();

        }

        _battleStart = false;
        _stageTimer = 0f;

        GetNextEnemy();

        _enemy.GetComponent<Enemy>().IsBattle = false;
        _player.GetComponent<PlayerInput>().SetIgnoreInput(true);

        textAnime.R1();

    }

    public void GameStart()
    {
        _countdownImage.GameObject().SetActive(false);
        _player.GetComponent<PlayerInput>().SetIgnoreInput(false);
        _enemy.GetComponent<PlayerInput>().SetIgnoreInput(false);
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
        if (!isNTR)
        {

            string enemyPath = "Enemy/Enemy";
            enemyPath += _stageInfo.stageIdx;
            _enemy = Managers.Resource.Instantiate(enemyPath).GetComponent<Poolable>();
            _enemy.GetComponent<PlayerInput>().SetIgnoreInput(true);

            _enemy.transform.position = Vector3.zero + Vector3.right * 5;

        }
        else
        {

            string enemyPath = "Enemy/Enemy";
            _enemy = Managers.Resource.Instantiate(enemyPath).GetComponent<Poolable>();
            _enemy.GetComponent<PlayerInput>().SetIgnoreInput(true);

            _enemy.transform.position = Vector3.zero + Vector3.right * 5;

        }

        
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

    public void SetGameResult(bool win)
    {

        if (isNTR)
        {

            Managers.Scene.LoadScene(Define.Scene.Menu);

        }

        bool eWin = false, pwin = false;

        if (win)
        {

            _playerWinCount++;

            if(_playerWinCount == 2)
            {

                pwin = true;

            }

        }
        else
        {

            _enemyWinCount++;

            if (_enemyWinCount == 2)
            {

                eWin = true;

            }

        }

        if(!pwin && !eWin)
        {

            _enemy.GetComponent<Enemy>().IsBattle = false;
            _player.GetComponent<PlayerInput>().SetIgnoreInput(true);

            textAnime.KO(win);

        }



        if(pwin == true)
        {

            textAnime.KO(true, true);
            StageClear();

        }
        else if(eWin == true)
        {

            textAnime.KO(false, true);
            StageClear();
        }

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

    public void ResetScene()
    {

        _clearCount++;
        Destroy(_player.gameObject);
        Destroy(_enemy.gameObject);

        _player = null;
        _enemy = null;

        GetNextEnemy();

        Action action = _clearCount switch
        {

            2 => textAnime.R2,
            3 => textAnime.R3,
            _ => null

        };

        action?.Invoke();

    }

}
