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




    public void OnNomal()//노말버튼 클릭
    {
        var popup = PopupManager.Instance.ShowSelectHeroPopup();//다음 팝업 생성요청
        HidePopup();//팝업 삭제
        PlayerPrefs.SetString("Mode", "nomal");//모드 값 저장
    }
    public void OnTutoraial()//튜토리얼 버튼 클릭
    {
        var popup = PopupManager.Instance.ShowSelectHeroPopup();//다음 팝업 생성요청
        HidePopup();//팝업 삭제
        PlayerPrefs.SetString("Mode", "Tutorial");//모드 값 저장
    }
    public void OnCampain()//캠패인 버튼 클릭
    {
        var popup = PopupManager.Instance.ShowSelectHeroPopup();//다음 팝업 생성요청
        HidePopup();//팝업 삭제
        PlayerPrefs.SetString("Mode", "Campain");//모드 값 저장
    }

    public override void HidePopup()
    {
        base.HidePopup();

    }

}
