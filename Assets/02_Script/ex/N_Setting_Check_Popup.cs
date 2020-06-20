using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class N_Setting_Check_Popup : PopupBase

{
    [SerializeField] private Text Mode;
    [SerializeField] private Text Hero;
    [SerializeField] private Text Difficulty;


    public void Awake()
    {
        Mode.text ="모드 : "+ PlayerPrefs.GetString("mode","error");
        Hero.text = "영웅 : " + PlayerPrefs.GetString("Hero", "전사");
        Difficulty.text = "난이도 : " + PlayerPrefs.GetString("Difficulty", "error");

    }

    void Update()
    {

        //if (Application.platform == RuntimePlatform.Android)

        {

            if (Input.GetKeyDown(KeyCode.Escape))

            {
                var popup = PopupManager.Instance.ShowDifficultySelectPopup();
                HidePopup();
            }



        }

    }

    public void Onprevious()
    {
        var popup = PopupManager.Instance.ShowDifficultySelectPopup();
        HidePopup();
    }


    public override void HidePopup()
    {

        base.HidePopup();

    }



}
