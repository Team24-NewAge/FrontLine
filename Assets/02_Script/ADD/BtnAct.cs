using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnAct : MonoBehaviour
{
    public GameObject[] btns = new GameObject[100];
    public static bool unitbatch = true;// 취소버튼과 연동되어 배치취소를 눌러야만 처음 미리 배치된 유닛들도 배치가 가능
    private GameObject unit;
    private int unitnum;

    public void Start()
    {
        unit = GameObject.Find("Unit");
        unitnum = unit.transform.childCount - 1;
    }

    public void OnClick()
    {
        if (unitbatch)
        {
            for (int i = 0; i < unitnum ; i++)
            {
                btns[i].GetComponent<UnitSpawnBtn>().btnanycheck = true;
                btns[i].GetComponent<UnitSpawnBtn>().btnanyclick = true;
            }//취소버튼이 아직 눌리지 않았다면 유닛에 있는 자식 오브젝트(영웅제외) 관련 버튼 전부 비활성화
        }
        
        for (int i = 0; i < UnitSummon.tot_btn ; i++)
        {
            btns[i].SetActive(true);//버튼 활성화'
        }
            
    }
}
