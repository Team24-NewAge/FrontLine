using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSpawnBtn : MonoBehaviour
{
    public bool btnanycheck = false;
    public bool btnanyclick = false;
    public Image unit_face;
    public GameObject summonmanager;

    private String objname;//현재 클릭한 버튼 이름

    public static int warrior_img;//전사 이미지

    public void Start()
    {
        for (int i = 0; i < warrior_img; i++)
        {
            unit_face.sprite =  GetUnitSOInfo.Instance.unitface[0]; 
        }//버튼에 이미지 보여줌
    }

    public void OnClick()
    {
        summonmanager.GetComponent<UnitSummon>().anypush = this.gameObject;//눌린 버튼의 오브젝트 할당
        btnanycheck = true;//버튼 눌림 확인
        objname = gameObject.name;//현재 클릭한 버튼

        for (int i = 0; i < UnitSummon.tot_btn; i++) // 버튼 총 개수 대로 for문 
        {
            string num = i.ToString();

            if (i == 0)
            {
                if (objname == "Summonclick")
                    UnitSummon.sel_btn = 0;
            }
            else if (objname == "Summonclick (" + num + ")")
                UnitSummon.sel_btn = i;
        }
        
        Debug.Log(UnitSummon.sel_btn);
        
    }

    void Update()
    {

        if (btnanyclick)
        {
            this.gameObject.SetActive(false);//버튼 비활성화
        }
        
    }
}
