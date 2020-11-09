using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Successlocationbtn : MonoBehaviour
{
    private GameObject Summon;
    private GameObject Hero_info;
    private GameObject Monstermanager;

    void Awake()
    {
        Summon = GameObject.Find("SummonImageBG");
        Hero_info = GameObject.Find("MainCanvas").transform.Find("Hero_info").gameObject;
        Monstermanager = GameObject.Find("Manager").transform.Find("MonsterManager").gameObject;
    }

    public void OnButtonClick()
    {
        Summon.SetActive(false);
        Hero_info.SetActive(true);
        Monstermanager.SetActive(true);
        Monstermanager.GetComponent<MonsterManager>().Regen();//MonsterManager 스크립트의 Regen문 실행
        UIBtnsActive.Monsterwave = true;
        UIBtnsActive.Nostorewave = true;
    }
    
}
