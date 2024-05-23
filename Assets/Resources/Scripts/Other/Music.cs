using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioClip battleMusic;
    private AudioClip menuMusic;
    private AudioClip prepMusic;
    private AudioSource battleMusicSource;
    private AudioSource menuMusicSource;
    private AudioSource prepMusicSource;

    private void Awake()
    {
        battleMusicSource = GameObject.FindWithTag("BattleMusic").GetComponent<AudioSource>();
        menuMusicSource = GameObject.FindWithTag("MenuMusic").GetComponent<AudioSource>();
        prepMusicSource = GameObject.FindWithTag("PrepMusic").GetComponent<AudioSource>();
        battleMusic = Resources.Load<AudioClip>("Music/BattleMusic");
        menuMusic = Resources.Load<AudioClip>("Music/MenuMusic");
        prepMusic = Resources.Load<AudioClip>("Music/PrepMusic");
    }

    public void PlayBattleMusic()
    {
        StopAllMusic();
        battleMusicSource.Play();
    }
    
    
    public void PlayMenuMusic()
    {
        StopAllMusic();
        menuMusicSource.Play();
    }
    
    
    public void PlayPrepMusic()
    {
        StopAllMusic();
        prepMusicSource.Play();
    }

    public void StopAllMusic()
    {
        menuMusicSource.Stop();
        battleMusicSource.Pause();
        prepMusicSource.Pause();
    }
}
