using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor.Build.Content;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip clip;


    public static SoundManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        SoundManager.instance.SFXPlay("Punch", clip);
    }

    public void SFXPlay(string sfxName, AudioClip clip)
    {
        GameObject go = new(sfxName + "Sound");
        AudioSource audiosource = go.AddComponent<AudioSource>();
        audiosource.clip = clip;
        audiosource.Play();

        Destroy(go, clip.length);
    }
}