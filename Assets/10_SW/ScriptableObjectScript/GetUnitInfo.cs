using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetUnitInfo : MonoBehaviour
{
    public static GetUnitInfo Instance { get; private set; }    //싱글톤?

    public GameObject Target;   //inspector창에 InventoryMN이 들어간 오브젝트를 넣기
    CheckInvenManager.UnitDataClassification[] otherUDC;  //유닛 데이터를 담은 구조체UnitDataClassification으로 선언


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        otherUDC = Target.GetComponent<CheckInvenManager>().out_UDC;  //InventoryMN의 데이터 받음
    }


    //유닛 인벤토리 n번에 있는 코드 받기

    //유닛 코드
    public int getUnitCode(int n)   
    {
        return otherUDC[n].code;
    }

    //유닛 이름
    public string getUnitName(int n)
    {
        return otherUDC[n].name;
    }
    //유닛 등급
    public int getUnitGrade(int n)
    {
        return otherUDC[n].grade;
    }

    //유닛 설명
    public string getUnitDescript(int n)
    {
        return otherUDC[n].descript;
    }

    //유닛 체력
    public int getUnitHp(int n)
    {
        return otherUDC[n].hp;
    }

    //유닛 공격력
    public int getUnitAtk(int n)
    {
        return otherUDC[n].atk;
    }

    //유닛 방어력
    public int getUnitDef(int n)
    {
        return otherUDC[n].def;
    }

    //유닛 공격속도
    public int getUnitAtkSp(int n)
    {
        return otherUDC[n].atkSp;
    }

    //유닛 가격
    public int getUnitpPrice(int n)
    {
        return otherUDC[n].price;
    }

}
