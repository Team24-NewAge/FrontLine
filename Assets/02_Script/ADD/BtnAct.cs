using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnAct : MonoBehaviour
{
    public GameObject[] btns = new GameObject[30];

    public void OnClick()
    {
       
            for (int i = 0; i < UnitSummon.tot_btn; i++)
            {
                Debug.Log(UnitSummon.tot_btn +"씨발");
                btns[i].SetActive(true);
            }
            
    }
}
