using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ModeSelectPopup : PopupBase
{

    public GameObject panel;
    public GameObject HeroSelectpanel;
    bool CanExit;



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




    public void OnNext()
    {
        var popup = PopupManager.Instance.ShowSelectHeroPopup();
        HidePopup();
    }

    public override void HidePopup()
    {
        base.HidePopup();

    }

}
