using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    
    public GameObject Monstermanager;//몬스터 매니저
    public GameObject btns_BG;//배치 UI
    public GameObject Battle;//배틀카메라
    public GameObject Main;//메인카메라
    public GameObject Hero_info; //영웅 체력바
    public GameObject Skill1, Skill2, Skill3;// 영웅 스킬들



    public BtnAct Refresh;


    public static bool batchstart = false;
    public enum Root { _none ,_reward, _shop, _event,}
    public Root root;
    //여기에 아무 변수 추가
    public static PlacementManager Instance { get; private set; }

    public void Awake()
    {
        Instance = this;
        root = Root._none;
    }
    
    public void Open_Placement()//배치 환경으로 만들어주는 매서드
    {
        
        Battle.SetActive(true);
        Main.SetActive(false);
        btns_BG.SetActive(true);
        Hero_info.SetActive(false);
        Skill1.SetActive(false);
        Skill2.SetActive(false);
        Skill3.SetActive(false);
        Monstermanager.SetActive(false);
        batchstart = true;

        PaperManager.Instance.Paper_Locked();
    }

    public void Close_Placement()//배치 닫고 다시 paper선택으로 돌아가게 하는 매서드
    {
        Monstermanager.SetActive(true);
        btns_BG.SetActive(false);
        Battle.SetActive(false);
        Main.SetActive(true);
        Hero_info.SetActive(true);
        PaperManager.Instance.Paper_Locked_off();

        switch (root) {
            case Root._shop : PopupManager.Instance.ShowUnitShop_Popup();
                root = Root._none;
                break;
            case Root._reward:
                GameManager.Instance.SavePopup.SetActive(true);
                GameManager.Instance.SavePopup = null;
               root = Root._none;
                break;
        }
    }

 
}
