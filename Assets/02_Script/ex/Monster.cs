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

    public GameObject Currentlocation;
    public Tile CurrentTile;

    public GameObject Targetlocation;
    public Tile Targettile;

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

        MonsterManager.Instance.Move(this.gameObject);
}

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, GetComponent<Monster>().Targerlocation.GetComponent<Transform>().position, 10 * Time.deltaTime);
    }

    public IEnumerator GotoTarget()
    {
        while (Vector3.Distance(transform.position, Targetlocation.GetComponent<Transform>().position)>=0.01f)//(Targetlocation.GetComponent<Transform>().position.Equals(transform.position)==false)
        {
            print("작동확인");
            //transform.LookAt(Targetlocation.transform);
            Vector3 dir = Targetlocation.transform.position - this.transform.position;
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 3);

            transform.position = Vector3.MoveTowards(transform.position,Targetlocation.GetComponent<Transform>().position, 1.5f * Time.deltaTime);

          
            yield return null;


        }

        Currentlocation = Targetlocation;
        CurrentTile = Targettile;
        MonsterManager.Instance.InTile(this.gameObject);
       // MonsterManager.Instance.Move(this.gameObject);

    }


}
