using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    public int Code;
    public string Name;
    public Sprite sprite;
    public int grade;
    public string description;
    public int hp;
    public int atk;
    public int def;
    public int a_spd;
    public int m_spd;

    void Start()
    {

        Code = GetEnemyInfo.Instance.getEnemyCode(0);
        Name = GetEnemyInfo.Instance.getEnemyName(0);
        //sprite = GetEnemyInfo.Instance.ge
        grade = GetEnemyInfo.Instance.getenEmyGrade(0);
        description = GetEnemyInfo.Instance.getEnemyDescript(0);
        hp = GetEnemyInfo.Instance.getEnemyHp(0);
        atk = GetEnemyInfo.Instance.getEnemyAtk(0);
        def= GetEnemyInfo.Instance.getEnemyDef(0);
        a_spd = GetEnemyInfo.Instance.getEnemyAtkSp(0);
        m_spd = GetEnemyInfo.Instance.getEnemyMvSp(0);


}

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(-0.1f, 0, 0);
    }
}
