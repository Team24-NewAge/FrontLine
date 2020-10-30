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
        return heroInfo.MaxHp;
    }

    int getHeroMp()
    {
        return heroInfo.HeroMp;
    }


    int getHeroAtk()
    {
        return heroInfo.BasedAtk;
    }

    int getHeroDef()
    {
        return heroInfo.BasedDef;
    }

    int getHeroAtkSp()
    {
        return heroInfo.BasedAtkSp;
    }

    int getHeroMvSp()
    {
        return heroInfo.MvSp;
    }
}
