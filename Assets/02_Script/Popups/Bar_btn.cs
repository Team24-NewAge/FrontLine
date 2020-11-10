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

    }

    public void Show_InVentory()
    {
        InventoryManager.Instance.Open_Inventory();
            }

    public void Placement_Check() {

        if (!place&&!BattleManager.Instance.isBattle)
        {
            CameraManager.Instance.BattleCam_on();
            PaperManager.Instance.Paper_Locked();
            placement.image.color = Color.red;
            place = true;
        }
        else if(place &&!BattleManager.Instance.isBattle)
        {

             CameraManager.Instance.MainCam_on();
            PaperManager.Instance.Paper_Locked_off();
            placement.image.color = Color.white;
            place = false;
        }

    }

    public void Check_paper()
    {

        PopupManager.Instance.ShowCheckpaper_Popup();

    }


}
