using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Successlocationbtn : MonoBehaviour
{
    public GameObject Summon;
    public GameObject Hero_info;
    public GameObject Skill_;
    public GameObject Skill_1;
    public GameObject Skill_2;
    public GameObject Skill_3;
    public GameObject Monstermanager;
    
    public void OnButtonClick()
    {
        Summon.SetActive(false);
        Hero_info.SetActive(true);
        Monstermanager.SetActive(true); 
        Skill_.SetActive(true);
        //Skill_1.SetActive(true);
        //Skill_2.SetActive(true);
        //Skill_3.SetActive(true);
        Monstermanager.GetComponent<MonsterManager>().Regen();//MonsterManager 스크립트의 Regen문 실행
        UIBtnsActive.Monsterwave = true;
        UIBtnsActive.Nostorewave = true;
    }
    
}
