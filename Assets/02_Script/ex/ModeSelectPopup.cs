using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ModeSelectPopup : PopupBase
{

 


    public void Awake()
    {

    }

    void Update()
    {

        //if (Application.platform == RuntimePlatform.Android)

        {

            if (Input.GetKeyDown(KeyCode.Escape))

            {
                HidePopup();
            }



        }

    }




    public void OnNomal()
    {
        var popup = PopupManager.Instance.ShowSelectHeroPopup();
        HidePopup();
        PlayerPrefs.SetString("Mode", "nomal");
    }
    public void OnTutoraial()
    {
        var popup = PopupManager.Instance.ShowSelectHeroPopup();
        HidePopup();
        PlayerPrefs.SetString("Mode", "Tutorial");
    }
    public void OnCampain()
    {
        var popup = PopupManager.Instance.ShowSelectHeroPopup();
        HidePopup();
        PlayerPrefs.SetString("Mode", "Campain");
    }

    public override void HidePopup()
    {
        base.HidePopup();

    }

}
