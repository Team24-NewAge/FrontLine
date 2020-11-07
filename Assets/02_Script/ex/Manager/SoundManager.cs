using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource BgmAudio;

    public AudioClip Lobby_bgm;
    public AudioClip NomalBattle_bgm;
    public AudioClip EliteBattle_bgm;
    public AudioClip BossBattle_bgm;
    public AudioClip Popup_bgm;
    public AudioClip testsound;

    public AudioClip attack_buff;


    public static SoundManager Instance { get; private set; }
   


    public void Awake()
    {
        Instance = this;
        BgmAudio = GetComponent<AudioSource>();
        BgmAudio.Play();
    }


    public void Start()
    {
        BgmAudio.volume = PlayerPrefs.GetFloat("bgm", 0f);
    }



    public void Lobby_On() 
    {
        BgmAudio.clip = Lobby_bgm;
        BgmAudio.Play();
    }

    public void NomalBattle_On()
    {
        BgmAudio.clip = NomalBattle_bgm;
        BgmAudio.Play();
    }

    public void EliteBattle_On()
    {
        BgmAudio.clip = EliteBattle_bgm;
        BgmAudio.Play();
    }

    public void BossBattle_On()
    {
        BgmAudio.clip = BossBattle_bgm;
        BgmAudio.Play();
    }

    public void Popup_On()
    {
        BgmAudio.clip = Popup_bgm;
        BgmAudio.Play();
    }
    public void SE_Play(AudioClip SE, float power)
    {
        BgmAudio.PlayOneShot(SE,power);
    }


    public void attack_buff_Play()
    {
        BgmAudio.PlayOneShot(attack_buff, 5);
    }

    public void test()
    {
        BgmAudio.PlayOneShot(testsound);
    }


}
