using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource BgmAudio;
    public AudioSource BgsAudio;

    public AudioClip Lobby_bgm;
    public AudioClip NomalBattle_bgm;
    public AudioClip EliteBattle_bgm;
    public AudioClip BossBattle_bgm;
    public AudioClip Popup_bgm;
    public AudioClip testsound;

    public AudioClip attack_buff;
    public AudioClip HeroSkill_2;
    public AudioClip HeroSkill_3;
    public AudioClip Heal_buff;

    public AudioClip traning_debuff;
    public AudioClip traning_buff;
    public AudioClip traning_perfect;

    public AudioClip pray;

    public AudioClip menu_click;
    public AudioClip reinforce_click;
    public AudioClip cancle_click;

    public AudioClip F_R_Result;

    public AudioClip BossEncount;
    public static SoundManager Instance { get; private set; }
   


    public void Awake()
    {
        Instance = this;

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
        BgsAudio.PlayOneShot(SE,power);
    }


    public void attack_buff_Play()
    {
        BgsAudio.PlayOneShot(attack_buff, 1);
    }
    public void Heal_buff_Play()
    {
        BgsAudio.PlayOneShot(Heal_buff, 1);
    }

    public void pray_Play()
    {
        BgsAudio.PlayOneShot(pray, 1);
    }

    public void menu_ok_Play()
    {
        BgsAudio.PlayOneShot(menu_click, 2);
    }
    public void cancle_menu()
    {
        BgsAudio.PlayOneShot(cancle_click, 2);
    }
    public void reinforce_menu()
    {
        BgsAudio.PlayOneShot(reinforce_click, 2);
    
    
    }

    public void Boss_encount()
    {
        BgsAudio.PlayOneShot(BossEncount, 2);
    }
    public void result_sound()
    {
        BgsAudio.PlayOneShot(F_R_Result, 2);
    }
    public void Hero_Warrior_Skill(int skill)
    {
        switch (skill)
        {
            case 2: BgsAudio.PlayOneShot(HeroSkill_2, 3); break;
            case 3: BgsAudio.PlayOneShot(HeroSkill_3, 3); break;

        } 
    }

    public void traning(int result)
    {
        switch (result)
        {
            case 0: BgsAudio.PlayOneShot(traning_debuff, 3); break;
            case 1: BgsAudio.PlayOneShot(traning_buff, 3); break;
            case 2: BgsAudio.PlayOneShot(traning_perfect, 3); break;

        }
    }

    public void test()
    {
        BgmAudio.PlayOneShot(testsound);
    }


}
