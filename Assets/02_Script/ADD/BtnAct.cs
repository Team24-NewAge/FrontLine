using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnAct : MonoBehaviour
{
    public GameObject[] btns = new GameObject[100];
    public static bool unitbatch = true;// 취소버튼과 연동되어 배치취소를 눌러야만 처음 미리 배치된 유닛들도 배치가 가능
    private GameObject unit;
    private GameObject inven;
    public  int unitnum;
    private int invennum;
    public GameObject us;
    public void OnEnable()
    {
       Invoke("OnClick",0.01f);
    }

    public void Awake()
    {
        unit = GameObject.Find("Unit");
        inven = GameObject.Find("Inventory");
        us = GameObject.Find("SummonUnit");
    }

    public void OnClick()
    {
        
        unitnum = unit.transform.childCount - 1;
        invennum = inven.transform.childCount;
            
        for (int i = 0; i < 100 ; i++)
        {
            btns[i].SetActive(false);//버튼 비활성화
            btns[i].GetComponent<UnitSpawnBtn>().btnanycheck = true;
            btns[i].GetComponent<UnitSpawnBtn>().btnanyclick = true;
        }
        
        for (int i = 0; i < UnitSummon.tot_btn ; i++)
        {
            btns[i].SetActive(true);//버튼 활성화
            btns[i].GetComponent<UnitSpawnBtn>().btnanycheck = false;
            btns[i].GetComponent<UnitSpawnBtn>().btnanyclick = false;
        }
        
        if (unitbatch && !UnitSummon.CheckFusion)
        {
            for (int i = 0; i < unitnum ; i++)
            {
                btns[i].SetActive(false);
                btns[i].GetComponent<UnitSpawnBtn>().btnanycheck = true;
                btns[i].GetComponent<UnitSpawnBtn>().btnanyclick = true;
            }//취소버튼이 아직 눌리지 않았다면 유닛에 있는 자식 오브젝트(영웅제외) 관련 버튼 전부 비활성화
        }
        
        if (UnitSummon.CheckFusion)
            Invoke("CheckFusion",0.3f);
        
        if(UnitSummon.CheckBuy)
            for (int i = 0; i < unit.transform.childCount - 1 ; i++)
            {
                btns[i].SetActive(false);//버튼 비활성화
                btns[i].GetComponent<UnitSpawnBtn>().btnanycheck = true;
                btns[i].GetComponent<UnitSpawnBtn>().btnanyclick = true;
                
            }//구매버튼이 아직 눌렸다면 유닛에 있는 자식 오브젝트(영웅제외) 관련 버튼 전부 비활성화
        else
            for (int i = 0; i < UnitSummon.tot_btn ; i++)
            {
                btns[i].SetActive(true);//버튼 활성화
                btns[i].GetComponent<UnitSpawnBtn>().btnanycheck = false;
                btns[i].GetComponent<UnitSpawnBtn>().btnanyclick = false;
            }
            
    }

    public void CheckFusion()
    {

        unitnum = unit.transform.childCount - 1;
        
        for (int i = 0; i < 100 ; i++)
        {
            btns[i].SetActive(false);//버튼 비활성화
            btns[i].GetComponent<UnitSpawnBtn>().btnanycheck = true;
            btns[i].GetComponent<UnitSpawnBtn>().btnanyclick = true;
        }
        
        for (int i = 0; i < UnitSummon.tot_btn ; i++)
        {
            btns[i].SetActive(true);//버튼 활성화
            btns[i].GetComponent<UnitSpawnBtn>().btnanycheck = false;
            btns[i].GetComponent<UnitSpawnBtn>().btnanyclick = false;
        }
        
        for (int i = 0; i < unit.transform.childCount - 1 ; i++)
        {
            btns[i].SetActive(false);//버튼 비활성화
            btns[i].GetComponent<UnitSpawnBtn>().btnanycheck = true;
            btns[i].GetComponent<UnitSpawnBtn>().btnanyclick = true;
        }
        
        
        UnitSummon.CheckBuy = false;
        UnitSummon.CheckFusion = false;
        
    }
    
}
