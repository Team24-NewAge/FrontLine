using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class GetUnitSOInfo : MonoBehaviour
{
    public UnitInfo[] unitInfo;
    public GameObject[] unit;
    public Sprite[] unitface;

    public static GetUnitSOInfo Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public int getUnitCode(int n)
    {
        return unitInfo[n].BasedCode;
    }

    public string getUnitName(int n)
    {
        return unitInfo[n].BasedName;
    }

    public int getUnitGrade(int n)
    {
        return unitInfo[n].BasedGrade;
    }

    public string getUnitDescript(int n)
    {
        return unitInfo[n].BasedDescript;
    }

    public int getUnitHp(int n)
    {
        return unitInfo[n].LifeHp;
    }

    public int getUnitAtk(int n)
    {
        return unitInfo[n].LifeAtk;
    }

    public int getUnitDef(int n)
    {
        return unitInfo[n].LifeDef;
    }

    public int getUnitAtkSp(int n)
    {
        return unitInfo[n].LifeAtkSp;
    }

    public int getUnitMvSp(int n)
    {
        return unitInfo[n].MvSp;
    }

    public int getUnitSkill(int n, int skillSlot)
    {
        return unitInfo[n].LifeSkill[skillSlot];
    }

    public int getUnitSkillLength(int n)
    {
        return unitInfo[n].LifeSkill.Length;
    }

    public int getUnitPrice(int n)
    {
        return unitInfo[n].Price;
    }
}
