using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SoundCollection : MonoBehaviour
{
    public static SoundCollection instance;

    public AudioClip[] Clip;

    public AudioSource SourceSfx;

    public AudioSource SourceBgm;

    public AudioClip[] Bgms;
    
    private void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if(scene.name == "MainMenu")
        {
            SoundCollection.instance.ChangeAndPlayBgm(0);
        }
        else if (scene.name == "Game2_0")
        {
            SoundCollection.instance.ChangeAndPlayBgm(1);
        }
        else if(scene.name == "Game3_0")
        {
            SoundCollection.instance.ChangeAndPlayBgm(2);
        }

    }

    public void CallSfx(int id)
    {
        SourceSfx.PlayOneShot(Clip[id]);
    }

    public void ChangeAndPlayBgm(int id)
    {
        SourceBgm.clip = Bgms[id];
        SourceBgm.Play();
    }
}
