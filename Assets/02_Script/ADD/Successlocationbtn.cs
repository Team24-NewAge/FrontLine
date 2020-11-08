using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Successlocationbtn : MonoBehaviour
{
    public GameObject Summon;
    public GameObject Hero_info;
    public GameObject Monstermanager;
    
    public void OnButtonClick()
    {
        Summon.SetActive(false);
        Hero_info.SetActive(true);
        Monstermanager.SetActive(true); 
        Monstermanager.GetComponent<MonsterManager>().Regen();//MonsterManager 스크립트의 Regen문 실행
        UIBtnsActive.Monsterwave = true;
    }
    
}
