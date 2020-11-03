using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_Select_Ban_Popup : PopupBase
{
    void Update()
    {
        //if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))

            {
                var popup = PopupManager.Instance.ShowSelelctPickPopup();
                HidePopup();
            }

        }

    }



    public void Onprevious()
    {
        var popup = PopupManager.Instance.ShowSelelctPickPopup();
        HidePopup();
    }

    public void OnNext()
    {
        var popup = PopupManager.Instance.ShowSelectInheritPopup();
        HidePopup();
    }


    public override void HidePopup()
    {
        base.HidePopup();

    }
}
