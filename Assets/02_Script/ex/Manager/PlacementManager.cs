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

    //여기에 아무 변수 추가
    public static PlacementManager Instance { get; private set; }

    public void Awake()
    {
        Instance = this;
    }
    
    public void Open_Placement()//배치 환경으로 만들어주는 매서드
    {
        Destroy(GameObject.Find("UnitBuy_popup(Clone)"));
        Battle.SetActive(true);
        Main.SetActive(false);
        btns_BG.SetActive(true);
        Hero_info.SetActive(false);
        Skill1.SetActive(false);
        Skill2.SetActive(false);
        Skill3.SetActive(false);
        Monstermanager.SetActive(false);
    }

    public void Close_Placement()//배치 닫고 다시 paper선택으로 돌아가게 하는 매서드
    {
        Monstermanager.SetActive(true);
        btns_BG.SetActive(false);
        Battle.SetActive(false);
        Main.SetActive(true);
        Hero_info.SetActive(true);
    }

 
}
