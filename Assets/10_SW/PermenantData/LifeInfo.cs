using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeInfo: BasedInfo
{
    [SerializeField]
    private int maxHp;
    public int MaxHp { get { return maxHp; } }

    [SerializeField]
    private int basedAtk;
    public int BasedAtk { get { return basedAtk; } }

    [SerializeField]
    private int basedDef;
    public int BasedDef { get { return basedDef; } }

    [SerializeField]
    private int basedAtkSp;
    public int BasedAtkSp { get { return basedAtkSp; } }

    [SerializeField]
    private int mvSp;
    public int MvSp { get { return mvSp; } }

    [SerializeField]
    private int[] lifeSkill;
    public int[] LifeSkill { get { return lifeSkill; } }
}