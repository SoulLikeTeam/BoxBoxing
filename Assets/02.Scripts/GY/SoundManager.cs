using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum BgmType
{
    Mene,
    Game
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] bglist;

    public static SoundManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
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


    public void SFXPlay(string sfxName, AudioClip clip)
    {
        Poolable go = Managers.Resource.Instantiate("Sound/Audio").GetComponent<Poolable>();
        if(go.GetComponent<AudioSource>() == null)
            go.AddComponent<AudioSource>();

        AudioSource audioSource = go.GetComponent<AudioSource>();
        audioSource.clip = clip;
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
        audioSource.volume = 1f;
        audioSource.Play();
    }

    public void BackGoundMusicPlay(BgmType type)
    {
        audioSource.clip = bglist[(int)type];
        audioSource.loop = true;
        audioSource.volume = 1f;
        audioSource.Play();
    }
}