using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
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

    /*private void Update()
    {
        SoundManager.instance.SFXPlay("Punch", clip);
    }*/
    
    public void SFXPlay(string sfxName, AudioClip clip)
    {
        //GameObject go = new(sfxName + "Sound");
        Poolable go = Managers.Pool.Pop(Managers.Resource.Load<GameObject>("Sound/Audio"));
        //AudioSource audiosource = go.AddComponent<AudioSource>();
        //AudioSource audiosource 
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
        //Destroy(SoundObject);
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
        //AudioSource.clip = clip;
        audioSource.clip = bglist[(int)type];
        audioSource.loop = true;
        audioSource.volume = 1f;
        audioSource.Play();
    }
}