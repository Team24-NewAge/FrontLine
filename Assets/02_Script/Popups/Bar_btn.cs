using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar_btn : MonoBehaviour
{
    bool place= false;
    public Button placement;
    public void Setting() {

        PopupManager.Instance.ShowOptionPopup_ingame();
        SoundManager.Instance.menu_ok_Play();
    }

    public void Show_InVentory()
    {
        InventoryManager.Instance.Open_Inventory();
        SoundManager.Instance.menu_ok_Play();
    }

    public void Placement_Check() {

        if (!place&&!BattleManager.Instance.isBattle)
        {
            SoundManager.Instance.menu_ok_Play();
            CameraManager.Instance.BattleCam_on();
            PaperManager.Instance.Paper_Locked();
            placement.image.color = Color.red;
            place = true;
        }
        else if(place &&!BattleManager.Instance.isBattle)
        {
            SoundManager.Instance.cancle_menu();
            CameraManager.Instance.MainCam_on();
            PaperManager.Instance.Paper_Locked_off();
            placement.image.color = Color.white;
            place = false;
        }

    }

    public void Check_paper()
    {
        SoundManager.Instance.menu_ok_Play();
        PopupManager.Instance.ShowCheckpaper_Popup();

    }


}
