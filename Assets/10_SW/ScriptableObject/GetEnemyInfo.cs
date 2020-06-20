using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEnemyInfo : MonoBehaviour
{
    public EnemyInfo enemyInfo;

    int getEnemyCode()
    {
        return enemyInfo.BasedCode;
    }

    string getEnemyName()
    {
        return enemyInfo.BasedName;
    }

    int getenEmyGrade()
    {
        return enemyInfo.BasedGrade;
    }

    string getEnemyDescript()
    {
        return enemyInfo.BasedDescript;
    }

    int getEnemyHp()
    {
        return enemyInfo.LifeHp;
    }

    int getEnemyAtk()
    {
        return enemyInfo.LifeAtk;
    }

    int getEnemyDef()
    {
        return enemyInfo.LifeDef;
    }

    int getEnemyAtkSp()
    {
        return enemyInfo.LifeAtkSp;
    }

    int getEnemyMvSp()
    {
        return enemyInfo.MvSp;
    }
}
