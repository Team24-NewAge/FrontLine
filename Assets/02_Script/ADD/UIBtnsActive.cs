using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBtnsActive : MonoBehaviour
{
    public static bool Monsterwave = true;//배치확인 체크 
    public GameObject Monstermanager;//몬스터 매니저
    public GameObject btns_BG;//배치 UI
    public Camera Battle;//배틀카메라
    public void Update()
    {

        if (Battle.isActiveAndEnabled && !Monsterwave)//배틀 카메라가 켜져 있고 배치확인이 false일 경우
        {
            btns_BG.SetActive(true);
        }

        if(GameObject.Find("UnitShop_popup(Clone)"))//상점창이 나온경우
        {
            Monsterwave = false;
            Monstermanager.SetActive(false);
        }
        
    }
}
