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
    public int m_spd; // 스텟들

    public GameObject TargetUnit;//공격대상

    public GameObject Currentlocation;

  

    public GameObject Targetlocation;
    public Tile Targettile;
    public Tile CurrentTile;
    public Animator animator;
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
        //스텟들 할당
        animator = this.GetComponent<Animator>();

        MonsterManager.Instance.Move(this.gameObject);//시작하면 이동
}

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, GetComponent<Monster>().Targerlocation.GetComponent<Transform>().position, 10 * Time.deltaTime);
    }

    public IEnumerator GotoTarget() //타일 위치로 이동하는 코루틴
    {
        while (Vector3.Distance(transform.position, Targetlocation.GetComponent<Transform>().position)>=0.01f)//(Targetlocation.GetComponent<Transform>().position.Equals(transform.position)==false)
        {
            //print("작동확인");
            //transform.LookAt(Targetlocation.transform);
            Vector3 dir = Targetlocation.transform.position - this.transform.position;
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 3);

            transform.position = Vector3.MoveTowards(transform.position,Targetlocation.GetComponent<Transform>().position, 3 * Time.deltaTime);

          
            yield return null;


        }

        Currentlocation = Targetlocation;
        CurrentTile = Targettile;
        MonsterManager.Instance.InTile(this.gameObject);
       // MonsterManager.Instance.Move(this.gameObject);


    }

    public IEnumerator Battle_Monster() //
    {
        while (MonsterManager.Instance.isUnit(CurrentTile))
        {

            yield return new WaitForSeconds(a_spd / 100);
            StartCoroutine(Attack());


        yield return new WaitForSeconds(a_spd /100);
        }
        this.GetComponent<Animator>().SetBool("isIdle", false);
        this.GetComponent<Animator>().SetBool("isAttack", false);
        MonsterManager.Instance.Move(this.gameObject);//

        yield return null;
    }

    public IEnumerator Attack() {
        print("전투중");
        TargetUnit = CurrentTile.GetComponent<Tile>().Unit[0];
        if (TargetUnit != null) {
            this.GetComponent<Animator>().SetBool("isAttack", true);
            yield return new WaitForSeconds(0.35f);
            if (TargetUnit != null)
            {
                TargetUnit.GetComponent<Unit>().hp -= atk;
                print(TargetUnit.GetComponent<Unit>().hp);
                this.GetComponent<Animator>().SetBool("isAttack", false);
            }
            else
            {
                this.GetComponent<Animator>().SetBool("isAttack", false);
            }
        }
        yield return null;

    }


}
