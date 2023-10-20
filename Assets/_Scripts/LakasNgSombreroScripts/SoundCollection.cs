using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCollection : MonoBehaviour
{
    public static SoundCollection instance;

    public AudioClip[] Clip;

    public AudioSource SourceSfx;

    public AudioSource SourceBgm;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CallSfx(int id)
    {
        SourceSfx.PlayOneShot(Clip[id]);
    }

    public void ChangeBgm(AudioClip music)
    {
        SourceBgm.Stop();
        SourceBgm.clip = music;
        SourceBgm.Play();
    }
}
