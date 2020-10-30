using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GetEnemyInfo : MonoBehaviour
{
    public EnemyInfo[] enemyInfo;
    public GameObject[] enemy;

    public static GetEnemyInfo Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public int getEnemyCode(int n)
    {
        return enemyInfo[n].BasedCode;
    }

    public string getEnemyName(int n)
    {
        return enemyInfo[n].BasedName;
    }

    public int getEnemyGrade(int n)
    {
        return enemyInfo[n].BasedGrade;
    }

    public  string getEnemyDescript(int n)
    {
        return enemyInfo[n].BasedDescript;
    }

    public int getEnemyHp(int n)
    {
        return enemyInfo[n].MaxHp;
    }

    public int getEnemyAtk(int n)
    {
        return enemyInfo[n].BasedAtk;
    }

    public int getEnemyDef(int n)
    {
        return enemyInfo[n].BasedDef;
    }

    public int getEnemyAtkSp(int n)
    {
        return enemyInfo[n].BasedAtkSp;
    }

    public int getEnemyMvSp(int n)
    {
        return enemyInfo[n].MvSp;
    }
}
