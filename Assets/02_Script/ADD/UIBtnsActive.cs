using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIBtnsActive : MonoBehaviour
{
    public static bool clickBattle = true;//배치확인 체크 
    private GameObject Monstermanager;//몬스터 매니저
    private GameObject btns_BG;//배치 UI
    private GameObject Battle;//배틀카메라
    private GameObject Main;//메인카메라
    private GameObject Hero_info; //영웅 체력바
    private GameObject Skill1, Skill2, Skill3;
    public static GameObject Comand;//커맨드 선택 창
    public static bool Nostore = true;//상점창이 열리지 않았을 경우
    
    private void Awake()
    {
        Monstermanager =  GameObject.Find("Manager").transform.Find("MonsterManager").gameObject;
        btns_BG = GameObject.Find("UI_Canvas_Btns").transform.Find("SummonImageBG").gameObject;
        Battle = GameObject.Find("Cameras").transform.Find("Battle Camera").gameObject;  
        Main = GameObject.Find("Cameras").transform.Find("Main Camera").gameObject;
        Hero_info = GameObject.Find("MainCanvas").transform.Find("Hero_info").gameObject;
        Skill1 = GameObject.Find("MainCanvas").transform.Find("Skill1").gameObject;
        Skill2 = GameObject.Find("MainCanvas").transform.Find("Skill2").gameObject;
        Skill3 = GameObject.Find("MainCanvas").transform.Find("Skill3").gameObject;
        Comand = GameObject.Find("Comand_Canvas");
       
    }
    
    public void Update()
    {

        if (Battle.GetComponent<Camera>().isActiveAndEnabled && !clickBattle)//배틀 카메라가 켜져 있고 배치확인이 false일 경우
        {
            btns_BG.SetActive(true);
            Hero_info.SetActive(false);
            Skill1.SetActive(false);
            Skill2.SetActive(false);
            Skill3.SetActive(false);
        }

        //if(UnitBuy_Popup.BuyClick)//구매 버튼을 눌렀을 경우
        {
            clickBattle = false;
            Monstermanager.SetActive(false);
            Nostore = false;
            Battle.SetActive(true);
            Main.SetActive(false);
            Comand.SetActive(false);
            Destroy(GameObject.Find("UnitBuy_popup(Clone)"));
            //UnitBuy_Popup.BuyClick = false;
        }
        

    }
}
