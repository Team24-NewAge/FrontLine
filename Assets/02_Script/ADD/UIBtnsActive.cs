using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBtnsActive : MonoBehaviour
{
    public static bool Monsterwave = true;//배치확인 체크 
    private GameObject Monstermanager;//몬스터 매니저
    private GameObject btns_BG;//배치 UI
    private GameObject Battle;//배틀카메라
    private GameObject Hero_info; //영웅 체력바
    public static bool Nostorewave = true ;

    private void Awake()
    {
        Monstermanager =  GameObject.Find("Manager").transform.Find("MonsterManager").gameObject;
        btns_BG = GameObject.Find("UI_Canvas_Btns").transform.Find("SummonImageBG").gameObject;
        Battle = GameObject.Find("Cameras").transform.Find("Battle Camera").gameObject;  
        Hero_info = GameObject.Find("MainCanvas").transform.Find("Hero_info").gameObject;
    }

    public void Start()
    {
        Hero_info.SetActive(false);
    }

    public void Update()
    {
        if (Battle.GetComponent<Camera>().isActiveAndEnabled && Nostorewave)
        {
            Hero_info.SetActive(true);
            
        }
        else
        {
            Hero_info.SetActive(false);
            
        }

        if (Battle.GetComponent<Camera>().isActiveAndEnabled && !Monsterwave)//배틀 카메라가 켜져 있고 배치확인이 false일 경우
        {
            btns_BG.SetActive(true);
        }

        if(GameObject.Find("UnitShop_popup(Clone)"))//상점창이 나온경우
        {
            Monsterwave = false;
            Monstermanager.SetActive(false);
            Nostorewave = false;
        }
        

    }
}
