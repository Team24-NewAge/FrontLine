using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawnBtn : MonoBehaviour
{
    public bool btnanycheck = false;
    public bool btnanyclick = false;

    public GameObject summonmanager;
    
    public void OnClick()
    {
        summonmanager.GetComponent<UnitSummon>().anypush = this.gameObject;//눌린 버튼의 오브젝트 할당
        btnanycheck = true;//버튼 눌림 확인
    }

    void Update()
    {
        if (btnanyclick)
        {
            this.gameObject.SetActive(false);//버튼 비활성화
        }
    }
}
