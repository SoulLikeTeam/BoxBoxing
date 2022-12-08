using System.Collections;
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
    public AudioSource audioSource;
    public AudioClip[] bglist;
    public AudioClip[] sfxlist;

    public static SoundManager instance;

    private void Awake() // BGM
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
        }

        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();

        GameObject go = Resources.Load<GameObject>("Sound/Audio");

        Managers.Pool.CreatePool(go, 10);

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


    public void SFXPlay(string sfxName, AudioClip clip) // SFXs
    {
        Poolable go = Managers.Resource.Instantiate("Sound/Audio").GetComponent<Poolable>();
        if(go.GetComponent<AudioSource>() == null)
            go.AddComponent<AudioSource>();

        AudioSource audioSource = go.GetComponent<AudioSource>();
        audioSource.clip = clip;
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