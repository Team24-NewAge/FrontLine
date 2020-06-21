using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Info", menuName = "Scriptable Object/Item Info", order = 5)]

public class ItemInfo : BasedInfo
{
    [SerializeField]
    private int itemValue;
    public int ItemValue { get { return itemValue; } }
}
