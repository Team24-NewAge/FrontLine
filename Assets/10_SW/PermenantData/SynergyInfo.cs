using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Synergy Info", menuName = "Scriptable Object/Synergy Info", order = 6)]

public class SynergyInfo : ScriptableObject
{
    [SerializeField]
    private string synergyName;
    public string SynergyName { get { return synergyName; } }

    [SerializeField]
    private int synergyValue;
    public int SynergyValue { get { return synergyValue; } }

    [SerializeField]
    private string synergyDescript;
    public string SynergyDescript { get { return synergyDescript; } }
}
