using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Unit Info", menuName = "Scriptable Object/Unit Info", order = 1)]

public class UnitInfo : LifeInfo
{
    [SerializeField]
    private int price;
    public int Price { get { return price; } }

    [SerializeField]
    private int tile;
    public int Tile { get { return tile; } }

    [SerializeField]
    private int location;
    public int Location { get { return location; } }

    [SerializeField]
    private int[] synergy;
    public int[] Synergy { get { return synergy; } }

    [SerializeField]
    private int unlockLv;
    public int UnlockLv { get { return unlockLv; } }

}