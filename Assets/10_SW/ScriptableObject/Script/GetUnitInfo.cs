﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetUnitInfo : MonoBehaviour
{
    public static GetUnitInfo Instance { get; private set; }    //싱글톤?

    public GameObject Target;   //inspector창에 InventoryMN이 들어간 오브젝트를 넣기
    InventoryMN.UnitDataClassification[] otherUDC;  //유닛 데이터를 담은 구조체UnitDataClassification으로 선언


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        otherUDC = Target.GetComponent<InventoryMN>().out_UDC;  //InventoryMN의 데이터 받음
    }


    //유닛 인벤토리 n번에 있는 코드 받기


    //유닛 코드
    public int getUnitCode(int n)   
    {
        return otherUDC[n].basedCode;
    }

    //유닛 이름
    public string getUnitName(int n)
    {
        return otherUDC[n].basedName;
    }
    //유닛 등급
    public int getUnitGrade(int n)
    {
        return otherUDC[n].basedGrade;
    }

    //유닛 설명
    public string getUnitDescript(int n)
    {
        return otherUDC[n].basedDescript;
    }

    //유닛 체력
    public int getUnitHp(int n)
    {
        return otherUDC[n].lifeHp;
    }

    //유닛 공격력
    public int getUnitAtk(int n)
    {
        return otherUDC[n].lifeAtk;
    }

    //유닛 방어력
    public int getUnitDef(int n)
    {
        return otherUDC[n].lifeDef;
    }

    //유닛 공격속도
    public int getUnitAtkSp(int n)
    {
        return otherUDC[n].lifeAtkSp;
    }

    //유닛 이동속도
    public int getUnitMvSp(int n)
    {
        return otherUDC[n].mvSp;
    }

    //유닛 가격
    public int getUnitpPrice(int n)
    {
        return otherUDC[n].price;
    }

    //유닛 해금레벨
    public int getUnitUnlockLv(int n)
    {
        return otherUDC[n].unlockLv;
    }
}
