using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHeroInfo : MonoBehaviour
{
    public HeroInfo heroInfo;

    int getHeroCode()
    {
        return heroInfo.BasedCode;
    }

    string getHeroName()
    {
        return heroInfo.BasedName;
    }

    int getHeroGrade()
    {
        return heroInfo.BasedGrade;
    }

    string getHeroDescript()
    {
        return heroInfo.BasedDescript;
    }

    int getHeroHp()
    {
        return heroInfo.LifeHp;
    }

    int getHeroMp()
    {
        return heroInfo.HeroMp;
    }


    int getHeroAtk()
    {
        return heroInfo.LifeAtk;
    }

    int getHeroDef()
    {
        return heroInfo.LifeDef;
    }

    int getHeroAtkSp()
    {
        return heroInfo.LifeAtkSp;
    }

    int getHeroMvSp()
    {
        return heroInfo.MvSp;
    }
}
