using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rebuild_Popup : PopupBase
{
    public GameObject exit_popup;
    public GameObject fadeimage;

    public void Exitpopup_on()
    {
        exit_popup.SetActive(true);
        fadeimage.SetActive(true);
    }
    public void Exitpopup_off()
    {
        exit_popup.SetActive(false);
        fadeimage.SetActive(false);
    }

    public override void HidePopup()
    {
        PaperManager.Instance.Paper_Locked_off();
        base.HidePopup();
    }


    public void LobbyBGM_On() {
        SoundManager.Instance.Lobby_On();
    }

    public void Hero_Rest() //영웅 휴식
    {
        int heal = Mathf.RoundToInt(BarManager.Instance.Hero.GetComponent<Unit>().Max_hp * 0.4f);
        BarManager.Instance.Hero.GetComponent<Unit>().Heal_Unit(heal);

        SoundManager.Instance.Heal_buff_Play();
        CameraManager.Instance.ResultCam_on();

        Rebuild_result_Popup result =  PopupManager.Instance.ShowRebuild_Result_Popup();
        result.SetText("영웅 휴식", "영웅이 충분한 휴식을 취했습니다.\n" + heal + "만큼의 체력을 회복합니다.");
        GameObject heal_effect = Instantiate(EffectManager.Instance.Healeffect, BarManager.Instance.Hero.transform.position, BarManager.Instance.Hero.transform.rotation);


        Destroy(gameObject);
        Destroy(heal_effect,2f);
    }

    public void Hero_traning()//영웅 훈련
    {
        float training = Random.Range(0f, 1f);
        Rebuild_result_Popup result = PopupManager.Instance.ShowRebuild_Result_Popup();
        int tr_atk, tr_def,tr_hp=0;
        GameObject training_effect;
        if (training < GameManager.Instance.Hero_traning_add[0])// 훈련실패
        {
            tr_atk = Random.Range(-3,1);
            tr_def = Random.Range(-10, 1);
            tr_hp = Random.Range(-10, 1);
            result.SetText("훈련 실패", "훈련을 하다 부상을 입었습니다.\n"+"최대 체력 " + tr_hp + "\n" + "공격력 "+ tr_atk+ "\n" + "방어력 " + tr_def  );

            BarManager.Instance.Hero.GetComponent<Unit>().atk += tr_atk;
            BarManager.Instance.Hero.GetComponent<Unit>().def += tr_def;
            BarManager.Instance.Hero.GetComponent<Unit>().Max_hp += tr_hp;

            SoundManager.Instance.traning(0);
            training_effect = Instantiate(EffectManager.Instance.traning_debuff, BarManager.Instance.Hero.transform.position, BarManager.Instance.Hero.transform.rotation);

        }
        else if (GameManager.Instance.Hero_traning_add[0] <= training && training < GameManager.Instance.Hero_traning_add[1]) //훈련성공
        {
            tr_atk = Random.Range(1, 4);
            tr_def = Random.Range(1, 11);
            tr_hp = Random.Range(1, 11);
            result.SetText("훈련 성공", "훈련으로 영웅의 기량이 올랐습니다.\n" + "최대 체력 +" + tr_hp + "\n" + "공격력 +" + tr_atk + "\n" + "방어력 +" + tr_def);

            BarManager.Instance.Hero.GetComponent<Unit>().atk += tr_atk;
            BarManager.Instance.Hero.GetComponent<Unit>().def += tr_def;
            BarManager.Instance.Hero.GetComponent<Unit>().Max_hp += tr_hp;

            SoundManager.Instance.traning(1);
            training_effect = Instantiate(EffectManager.Instance.traning_buff, BarManager.Instance.Hero.transform.position, BarManager.Instance.Hero.transform.rotation);

        }
        else //if (GameManager.Instance.Hero_traning_add[1] <= training && training <= GameManager.Instance.Hero_traning_add[2]) 훈련 대성공
        {
            tr_atk = Random.Range(3, 6);
            tr_def = Random.Range(10, 15);
            tr_hp = Random.Range(10, 15);
            result.SetText("훈련 대성공", "훈련으로 깨달음을 얻은 듯 합니다!\n" + "최대 체력 +" + tr_hp + "\n" + "공격력 +" + tr_atk + "\n" + "방어력 +" + tr_def);

            BarManager.Instance.Hero.GetComponent<Unit>().atk += tr_atk;
            BarManager.Instance.Hero.GetComponent<Unit>().def += tr_def;
            BarManager.Instance.Hero.GetComponent<Unit>().Max_hp += tr_hp;

            SoundManager.Instance.traning(2);
            training_effect = Instantiate(EffectManager.Instance.traning_perfect, BarManager.Instance.Hero.transform.position, BarManager.Instance.Hero.transform.rotation);

        }

        BarManager.Instance.Hero.GetComponent<Unit>().Heal_Unit(tr_hp);

     
        CameraManager.Instance.ResultCam_on();

       

        Destroy(gameObject);
        Destroy(training_effect, 5f);
    }


}
