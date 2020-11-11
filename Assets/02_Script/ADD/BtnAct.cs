using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnAct : MonoBehaviour
{
    public GameObject[] btns = new GameObject[100];
    public void OnClick()
    {
        for (int i = 0; i < UnitSummon.tot_btn ; i++)
            {
                btns[i].SetActive(true);//버튼 활성화
            }
            
    }
}
