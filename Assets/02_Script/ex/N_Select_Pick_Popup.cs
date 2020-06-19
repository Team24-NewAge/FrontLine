using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_Select_Pick_Popup : PopupBase
{
    void Update()
    {

        //if (Application.platform == RuntimePlatform.Android)

        {

            if (Input.GetKeyDown(KeyCode.Escape))

            {
                var popup = PopupManager.Instance.ShowSelectHeroPopup();
                HidePopup();
            }



        }

    }



    public void Onprevious()
    {
        var popup = PopupManager.Instance.ShowSelectHeroPopup();
        HidePopup();
    }

    public void OnNext()
    {
        var popup = PopupManager.Instance.ShowSelelctBanPopup();
        HidePopup();
    }



    public override void HidePopup()
    {
        base.HidePopup();

    }
}
