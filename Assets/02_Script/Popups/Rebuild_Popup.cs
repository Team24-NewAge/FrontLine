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

    public void Hero_Rest() {
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




}
