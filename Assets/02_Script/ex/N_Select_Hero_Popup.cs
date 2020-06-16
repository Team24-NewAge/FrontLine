using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_Select_Hero_Popup : PopupBase
{






    public void Onprevious()
    {
        var popup = PopupManager.Instance.ShowGameModeSelectPopup();
        HidePopup();
    }

    public override void HidePopup()
    {
        base.HidePopup();

    }
}
