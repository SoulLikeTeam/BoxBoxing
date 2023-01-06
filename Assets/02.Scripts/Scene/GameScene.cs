using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using Unity.VisualScripting;
using FD.Dev;
using TMPro;

public class GameScene : BaseScene
{
    [SerializeField]
    private GameObject _stopPanel;
    [SerializeField] private TextAnime textAnime;
    [SerializeField] private bool isNTR;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip[] clips;

    [SerializeField]
    private Sprite[] _numberList;
    [SerializeField]
    private Image _playerWin;
    [SerializeField]
    private Image _enemyWin;

    private Poolable _enemy;
    private Poolable _player;

    public AllStageInfo _stageInfo;

    private int _clearCount = 1;
    private int _playerWinCount = 0;
    private int _enemyWinCount = 0;
    private bool _battleStart = false;
    private float _stageTimer = 0f;
    private bool _settingWin = false;

    protected override void Init()
    {

        SoundManager_V2.instance.Stop();

        SceneType = Define.Scene.Game;

        if (!isNTR)
        {

            _stageInfo = Managers.Save.LoadJsonFile<AllStageInfo>();

        }

        _battleStart = false;
        _stageTimer = 0f;

        GetNextEnemy();

        _player.GetComponent<PlayerInput>().SetIgnoreInput(true);
        _enemy.GetComponent<Enemy>().IsBattle = false;

        _playerWin.sprite = _numberList[_playerWinCount];
        _enemyWin.sprite = _numberList[_enemyWinCount];

        textAnime.Round(1);

    }

    public void GameStart()
    {

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
            source.clip = clips[_stageInfo.stageIdx];
            _enemy = Managers.Resource.Instantiate(enemyPath).GetComponent<Poolable>();
            _enemy.GetComponent<PlayerInput>().SetIgnoreInput(true);
            source.Play();

            _enemy.transform.position = Vector3.zero + Vector3.right * 5;

        }
        else
        {

            string enemyPath = "Enemy/Enemy";
            _enemy = Managers.Resource.Instantiate(enemyPath).GetComponent<Poolable>();
            _enemy.GetComponent<PlayerInput>().SetIgnoreInput(true);

            source.Play();

            _enemy.transform.position = Vector3.zero + Vector3.right * 5;

        }

        
    }

    private void SpawnPlayer()
    {

        _player = Managers.Resource.Instantiate("Player/Player").GetComponent<Poolable>();
        _player.transform.position = Vector3.zero + Vector3.left * 5;

        _player.GetComponent<Movement>().SetTarget(_enemy.gameObject);
        _player.GetComponent<Movement>().State.SetIdle();

        _enemy.GetComponent<Movement>().SetTarget(_player.gameObject);
        _enemy.GetComponentInChildren<PABrain>().SetTarget(_player.gameObject);
        _player.GetComponent<PlayerInput>().SetIgnoreInput(true);

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

        if (_settingWin) return;

        _settingWin = true;

        FAED.InvokeDelayReal(() =>
        {

            if (isNTR)
            {

                Managers.Scene.LoadScene(Define.Scene.Menu);

            }

        }, 2f);

        bool eWin = false, pwin = false;

        if (win)
        {

            _playerWinCount++;
            _playerWin.sprite = _numberList[_playerWinCount];
            _enemy.transform.Find("PlayerBasePos").Find("VisualSprite").GetComponent<SpriteRenderer>().enabled = false;
            _enemy.transform.Find("PlayerBasePos").Find("BoxParticle").gameObject.SetActive(false);
            _enemy.transform.Find("PlayerBasePos").Find("PlayerParticle").gameObject.SetActive(false);

            if (_playerWinCount == 2)
            {

                pwin = true;

            }

        }
        else
        {

            _enemyWinCount++;
            _enemyWin.sprite = _numberList[_enemyWinCount];


            if (_enemyWinCount == 2)
            {

                eWin = true;

            }

        }

        if(_enemy != null && _enemy.GetComponent<Enemy>() != null)
        {

            _enemy.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            _enemy.GetComponent<Enemy>().IsBattle = false;
            _enemy.GetComponent<PlayerInput>().SetIgnoreInput(false);

            Destroy(_enemy.transform.Find("AI").gameObject);


        }
        if (_player != null && _enemy.GetComponent<PlayerInput>() != null)
        {

            _player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            _player.GetComponent<PlayerInput>().SetIgnoreInput(true);

        }

        if(!pwin && !eWin)
        {

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
            Managers.Save.DeleteFile();

        }


    }
    
    public void StageClear()
    {
        int idx = _stageInfo.stageIdx;
        _stageInfo.stageInfo[idx].clearTime = _stageTimer;
        _stageInfo.stageInfo[idx].isClear = true;

        if(_stageInfo.stageIdx == 4)
        {
            
            Managers.Save.DeleteFile();

        }
        else
        {
            _stageInfo.stageIdx++;
            Managers.Save.SaveJson(_stageInfo);
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

        textAnime.Round(_clearCount);

        _settingWin = false;

    }

}
