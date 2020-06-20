using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeInfo: BasedInfo
{
    [SerializeField]
    private int lifeHp;
    public int LifeHp { get { return lifeHp; } }

    [SerializeField]
    private int lifeAtk;
    public int LifeAtk { get { return lifeAtk; } }

    [SerializeField]
    private int lifeDef;
    public int LifeDef { get { return lifeDef; } }

    [SerializeField]
    private int lifeAtkSp;
    public int LifeAtkSp { get { return lifeAtkSp; } }

    [SerializeField]
    private int mvSp;
    public int MvSp { get { return mvSp; } }

    [SerializeField]
    private int[] lifeSkill;
    public int[] LifeSkill { get { return lifeSkill; } }

}