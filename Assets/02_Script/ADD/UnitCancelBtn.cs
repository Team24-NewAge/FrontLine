using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitCancelBtn : MonoBehaviour
{
    
    private GameObject summonmanager; 
    private GameObject inven; // 인벤토리
    private GameObject TargetLocation; //인벤토리 유닛 위치
    private Tile 
        tile_9, tile_8, tile_7, tile_6, tile_5,
        tile_4, tile_3, tile_2, tile_1, tile_0; //각 타일 타입 변수
    
    public GameObject [] btns = new GameObject [100];
    
    public static bool CancleCheack = false;

    void Awake()
    {
        summonmanager = GameObject.Find("SummonUnit");
        inven = GameObject.Find("tile_inventory");
        TargetLocation = inven.transform.GetChild(0).gameObject;
    }

    void Start() {  //각 타일 찾아서 연결
        
        tile_9 = GameObject.Find("tile_9").GetComponent<Tile>();
        tile_8 = GameObject.Find("tile_8").GetComponent<Tile>();
        tile_7 = GameObject.Find("tile_7").GetComponent<Tile>();
        tile_6 = GameObject.Find("tile_6").GetComponent<Tile>();
        tile_5 = GameObject.Find("tile_5").GetComponent<Tile>();
        tile_4 = GameObject.Find("tile_4").GetComponent<Tile>();
        tile_3 = GameObject.Find("tile_3").GetComponent<Tile>();
        tile_2 = GameObject.Find("tile_2").GetComponent<Tile>();
        tile_1 = GameObject.Find("tile_1").GetComponent<Tile>();
        tile_0 = GameObject.Find("tile_0").GetComponent<Tile>();
      
    }
    

    public void OnClick()
    {
       
        for (int i = 0; i < UnitSummon.tot_btn; i++)
        {
            summonmanager.GetComponent<UnitSummon>().unit_[i].transform.position = inven.transform.position;//유닛 위치 인벤토리로
            summonmanager.GetComponent<UnitSummon>().unit_[i].GetComponent<Unit>().Current_Tile = inven.GetComponent<Tile>();//유닛 타일 초기화
            summonmanager.GetComponent<UnitSummon>().unit_[i].GetComponent<Unit>().Current_Location = TargetLocation;// 유닛 타일 위치 초기화
            summonmanager.GetComponent<UnitSummon>().unit_[i].GetComponent<Unit>().Current_Location_number = "0";//위치 번호 초기화
            summonmanager.GetComponent<UnitSummon>().unit_[i].transform.SetParent(GameManager.Instance.inventory.transform);//부모를 인벤토리로 변경
        }

        for (int i = 0; i < 3; i++)
        {
            tile_9.Unit[i] = null;
            tile_8.Unit[i] = null;
            tile_7.Unit[i] = null;
            tile_6.Unit[i] = null;
            tile_5.Unit[i] = null;
            tile_4.Unit[i] = null;
            tile_3.Unit[i] = null;
            tile_2.Unit[i] = null;
            tile_1.Unit[i] = null;
            tile_0.Unit[i] = null;
        }//타일 초기화
        
        for (int i = 0; i < UnitSummon.tot_btn;i++)
        {
            btns[i].GetComponent<UnitSpawnBtn>().btnanycheck = false;//해당 버튼 체크 비활성화
            btns[i].GetComponent<UnitSpawnBtn>().btnanyclick = false;//해당 버튼 클릭 비활성화
            btns[i].SetActive(true);//버튼 활성화
        }
        
        CancleCheack = true;
        
    }
    
    
}
