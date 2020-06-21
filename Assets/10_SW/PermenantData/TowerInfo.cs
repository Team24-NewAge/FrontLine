using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tower Info", menuName = "Scriptable Object/Tower Info", order = 2)]

public class TowerInfo : BasedInfo
{
    [SerializeField]
    private int unlifeAtk;
    public int UnlifeAtk { get { return unlifeAtk; } }

    [SerializeField]
    private int unlifeAtkSp;
    public int UnlifeAtkSp { get { return unlifeAtkSp; } }

    [SerializeField]
    private int[] unlifeSkill;
    public int[] UnlifeSkill { get { return unlifeSkill; } }

    [SerializeField]
    private int[] synergy;
    public int[] Synergy { get { return synergy; } }

    [SerializeField]
    private int price;
    public int Price { get { return price; } }

    [SerializeField]
    private int unlockLv;
    public int UnlockLv { get { return unlockLv; } }
}