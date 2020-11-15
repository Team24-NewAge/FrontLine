using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnAct : MonoBehaviour
{
    public GameObject[] btns = new GameObject[100];
    public static bool unitbatch = true;// 취소버튼과 연동되어 배치취소를 눌러야만 처음 미리 배치된 유닛들도 배치가 가능
    private GameObject unit;
    private GameObject inven;
    public int unitnum;
    public static int unit_post;
    public static bool btnfusion = false;
    public static int next = 0;
    
    public void OnEnable()
    {
       Invoke("OnClick",0.01f);
    }

    public void Awake()
    {
        unit = GameObject.Find("Unit");
        inven = GameObject.Find("Inventory");
    }

    public void OnClick()
    {
        unitnum = unit.transform.childCount - 1;
        Debug.Log(unit_post);

        if (UnitSummon.fusionchk)
            Invoke("Onfusion", 0.5f);
        
        if (unitbatch)
        {
            for (int i = 0; i < unitnum; i++)
            {
                btns[i].GetComponent<UnitSpawnBtn>().btnanycheck = true;
                btns[i].GetComponent<UnitSpawnBtn>().btnanyclick = true;
            }//취소버튼이 아직 눌리지 않았다면 유닛에 있는 자식 오브젝트(영웅제외) 관련 버튼 전부 비활성화
        }
        
        if (btnfusion)
        {
            for (int i = 0; i < UnitSummon.tot_btn; i++)
            {
                btns[i].SetActive(true); //버튼 활성화
                //btns[unit_post].SetActive(false);
            }

            btnfusion = false;
        }
        else
        {
            for (int i = 0; i < UnitSummon.tot_btn ; i++)
                btns[i].SetActive(true);//버튼 활성화
        }
        
    }

    public void Onfusion()
    {
        
        for (int i = 0; i < unit_post; i++)
        {
            btns[i].GetComponent<UnitSpawnBtn>().btnanycheck = false;
            btns[i].GetComponent<UnitSpawnBtn>().btnanyclick = false;
        }//합성이 눌렸다면 버튼 전부 활성화

        for (int i = 0; i < (UnitSummon.tot_btn - inven.transform.childCount); i++)
        {
            btns[i].GetComponent<UnitSpawnBtn>().btnanycheck = true;
            btns[i].GetComponent<UnitSpawnBtn>().btnanyclick = true;
        }//합성이 눌렸다면 인벤토리에 존재하는 유닛 제외 버튼 전부 비활성화
        
        
        btnfusion = true;
    }
    
}
