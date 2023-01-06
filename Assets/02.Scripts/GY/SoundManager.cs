using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum BgmType
{
    Mene,
    Game
}

public enum SfxType
{
    Walk,
    HIt,
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] bglist;
    public AudioClip[] sfxlist;

    public static SoundManager instance;

    private float _bgmVolume = 1.0f;
    public float BgmVolume { get => _bgmVolume; private set { if (_bgmVolume != value) { _bgmVolume = value; SetBgmVolumeList(_bgmVolume); } } }
    private float _sfxVolume = 1.0f;
    public float SfxVolume { get => _sfxVolume; private set { if (_sfxVolume != value) { _sfxVolume = value; } } }

    private List<AudioSource> _audioSourceList = new List<AudioSource>();

    private void Awake() // BGM
    {



        _sfxVolume = PlayerPrefs.GetFloat("SFX");
        audioSource = GetComponent<AudioSource>();
            instance = this;

        return;

        if (instance == null)
        {
            DontDestroyOnLoad(instance);
            UnityEngine.SceneManagement.SceneManager.sceneLoaded -= Clear;
            UnityEngine.SceneManagement.SceneManager.sceneLoaded += Clear;
            UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
            UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }


        //_audioSourceList = FindObjectsOfType<AudioSource>().ToList();

    }
    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        for(int i =0; i<bglist.Length; i++)
        {
            if (arg0.name == bglist[i].name)
            {
                BackGoundMusicPlay(bglist[i]);
            }
        }
    }

    private void Clear(Scene arg0, LoadSceneMode arg1)
    {
        StopAllCoroutines();
    }

    public void SetBgmVolumeList(float value)
    {
        if (_audioSourceList.Count <= 0) return;

        foreach(AudioSource s in _audioSourceList)
        {
            s.volume = value;
        }
    }

    public void SetSfxVolume(float value)
    {
        _sfxVolume = value;
    }

    public void SetBgmVolume(float value)
    {
        BgmVolume = value;
       audioSource.volume = _bgmVolume;
    }


    public void SFXPlay(int num) // SFXs
    {
        Poolable go = Managers.Resource.Instantiate("Sound/Audio").GetComponent<Poolable>();
        if(go.GetComponent<AudioSource>() == null)
            go.AddComponent<AudioSource>();

        AudioSource audioSource = go.GetComponent<AudioSource>();
        audioSource.clip = sfxlist[num];
        audioSource.volume = _sfxVolume;
        audioSource.Play();
        StartCoroutine(SoundDelay(audioSource.clip.length,go));
    }

    public void SFXPlay(SfxType type)
    {
        Poolable go = Managers.Resource.Instantiate("Sound/Audio").GetComponent<Poolable>();
        if (go.GetComponent<AudioSource>() == null)
            go.AddComponent<AudioSource>();

        AudioSource audioSource = go.GetComponent<AudioSource>();
        audioSource.clip = sfxlist[(int)type];
        audioSource.volume = _sfxVolume;
        audioSource.Play();
        StartCoroutine(SoundDelay(audioSource.clip.length, go));
    }


    IEnumerator SoundDelay(float SoundLength, Poolable SoundObject)
    {
        yield return new WaitForSeconds(SoundLength);
        Managers.Pool.Push(SoundObject);
    }

    public void BackGoundMusicPlay(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.volume = _bgmVolume;
        audioSource.Play();
    }

    public void BackGoundMusicPlay(BgmType type)
    {
        audioSource.clip = bglist[(int)type];
        audioSource.loop = true;
        audioSource.volume = _bgmVolume;
        audioSource.Play();
    }
}