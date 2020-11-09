
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rebuild_result_Popup : PopupBase
{
    public Text Result_name;
    public Text Result_ex;

    void Update()
    {

    }

    public void SetText(string name, string ex)
    {
        Result_name.text = name;
        Result_ex.text = ex;
    }

    public override void HidePopup()
    {
        CameraManager.Instance.MainCam_on();
        SoundManager.Instance.Lobby_On();
        base.HidePopup();
    }

}
