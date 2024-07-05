using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager
{
    private AudioManager instance;
    public AudioManager Instance { get => instance ?? (instance = new AudioManager()); }



    /// <summary>
    /// 播放音乐 需要场景中有tag为Music 包含AudioSource的物体
    /// </summary>
    /// <param name="音频文件路径"></param>
    public void PlayMusic(string musicPath)
    {
        GameObject go = GameObject.FindGameObjectWithTag("Music");
        AudioSource aud = go.GetComponent<AudioSource>();
        AudioClip clip = Resources.Load<AudioClip>(musicPath);
        aud.clip = clip;
    }


    /// <summary>
    /// 播放音效 需要场景中有tag为Sound 包含AudioSource的物体
    /// </summary>
    /// <param name="音频文件路径"></param>
    public void PlaySound(string soundPath)
    {
        GameObject go = GameObject.FindGameObjectWithTag("Sound");
        AudioSource aud = go.GetComponent<AudioSource>();
        AudioClip clip = Resources.Load<AudioClip>(soundPath);
        aud.PlayOneShot(clip);
    }


}


