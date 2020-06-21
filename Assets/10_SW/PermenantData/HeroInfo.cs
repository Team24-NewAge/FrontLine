using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Hero Info", menuName = "Scriptable Object/Hero Info", order = 0)]

public class HeroInfo : LifeInfo
{
    [SerializeField]
    private int heroMp;
    public int HeroMp { get { return heroMp; } }


}