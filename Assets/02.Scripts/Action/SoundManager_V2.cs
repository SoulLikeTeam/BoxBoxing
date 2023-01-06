using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager_V2 : MonoBehaviour
{

    [SerializeField] private AudioSource source;
    private bool isPlay;
    public static SoundManager_V2 instance;


    public void Awake()
    {

        if(SoundManager_V2.instance != null) return;

        instance = this;

        DontDestroyOnLoad(gameObject);

        source = GetComponent<AudioSource>();

        Play();

    }

    public void Play()
    {

        if (isPlay) return;

        if (source != null) source = GetComponent<AudioSource>();

        source.Play();

        isPlay = true;

    }

    public void Stop()
    {

        if (!isPlay) return;

        if (source != null) source = GetComponent<AudioSource>();

        source.Stop();

        isPlay = false;

    }

}
