using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource bgm;
    public AudioClip[] bglist;
    public float DestroySound;


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
        GameObject go = new(sfxName + "Sound");
        AudioSource audiosource = go.AddComponent<AudioSource>();
        audiosource.clip = clip;
        audiosource.Play();
        StartCoroutine(SoundDelay(audiosource.clip.length,go));
    }
    
    IEnumerator SoundDelay(float SoundLength,GameObject SoundObject)
    {
        yield return new WaitForSeconds(SoundLength);
        Destroy(SoundObject);
    }
    public void BackGoundMusicPlay(AudioClip clip)
    {
        bgm.clip = clip;
        bgm.loop = true;
        bgm.volume = 1f;
        bgm.Play();
    }
}