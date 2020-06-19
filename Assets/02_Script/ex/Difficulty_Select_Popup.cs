using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty_Select_Popup : PopupBase
{
    // Start is called before the first frame update
    public void Awake()
    {

    }

    void Update()
    {

        //if (Application.platform == RuntimePlatform.Android)

        {

            if (Input.GetKeyDown(KeyCode.Escape))

            {
                var popup = PopupManager.Instance.ShowSelectInheritPopup();
                HidePopup();
            }



        }

    }

    public void OnEasy()
    {
        var popup = PopupManager.Instance.ShowSetting_Check_Popup();
        HidePopup();
        PlayerPrefs.SetString("Difficulty", "견습");
    }
    public void OnNomal()
    {
        var popup = PopupManager.Instance.ShowSetting_Check_Popup();
        HidePopup();
        PlayerPrefs.SetString("Difficulty", "정예");
    }
    public void OnHard()
    {
        var popup = PopupManager.Instance.ShowSetting_Check_Popup();
        HidePopup();
        PlayerPrefs.SetString("Difficulty", "영웅");
    }


    public void Onprevious()
    {
        var popup = PopupManager.Instance.ShowSelectInheritPopup();
        HidePopup();
    }

    public override void HidePopup()
    {

        base.HidePopup();

    }

}
