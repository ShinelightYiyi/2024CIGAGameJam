using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager
{
    private AudioManager instance;
    public AudioManager Instance { get => instance ?? (instance = new AudioManager()); }



    /// <summary>
    /// �������� ��Ҫ��������tagΪMusic ����AudioSource������
    /// </summary>
    /// <param name="��Ƶ�ļ�·��"></param>
    public void PlayMusic(string musicPath)
    {
        GameObject go = GameObject.FindGameObjectWithTag("Music");
        AudioSource aud = go.GetComponent<AudioSource>();
        AudioClip clip = Resources.Load<AudioClip>(musicPath);
        aud.clip = clip;
    }


    /// <summary>
    /// ������Ч ��Ҫ��������tagΪSound ����AudioSource������
    /// </summary>
    /// <param name="��Ƶ�ļ�·��"></param>
    public void PlaySound(string soundPath)
    {
        GameObject go = GameObject.FindGameObjectWithTag("Sound");
        AudioSource aud = go.GetComponent<AudioSource>();
        AudioClip clip = Resources.Load<AudioClip>(soundPath);
        aud.PlayOneShot(clip);
    }


}


