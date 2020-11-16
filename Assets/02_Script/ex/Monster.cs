using Microsoft.Win32;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public int Monster_Code;
    public int Code;
    public string Name;
    public Sprite sprite;
    public int grade;
    public string description;
    public int Max_hp;
    public int hp;
    public int atk;
    public int def;
    public int a_spd;
    public int a_del;
    public int m_spd; // 스텟들

    public GameObject TargetUnit;//공격대상

    public GameObject Currentlocation;

    public AudioClip Attack_sound;
    public AudioClip Deadsound;

    public ParticleSystem Attack_Effect;

    public GameObject Targetlocation;
    public Tile Targettile;
    public Tile CurrentTile;
    public Animator animator;


    public Slider Hp_bar;
    public bool Do_Battle;
    public bool isBoss = false;
    float add_state;
    void Start()
    {
        switch (GameManager.Instance.Battle) {
            case GameManager.battleState.nomal:
                {
                    add_state = 1.0f;
                    break;
                }
            case GameManager.battleState.elite:
                {
                    add_state = 1.2f;
                    break;
                }
            case GameManager.battleState.boss:
                {
                    add_state = 1.4f;
                    break;
                }

        }
        if (isBoss)
        {
            add_state *= 1.5f;
        }

        Code = GetEnemyInfo.Instance.getEnemyCode(Monster_Code);
        Name = GetEnemyInfo.Instance.getEnemyName(Monster_Code);
        //sprite = GetEnemyInfo.Instance.ge
        grade = GetEnemyInfo.Instance.getEnemyGrade(Monster_Code);
        description = GetEnemyInfo.Instance.getEnemyDescript(Monster_Code);
        Max_hp = Mathf.FloorToInt(GetEnemyInfo.Instance.getEnemyHp(Monster_Code)*add_state);
        hp = Mathf.FloorToInt(GetEnemyInfo.Instance.getEnemyHp(Monster_Code) * add_state);
        atk = Mathf.FloorToInt(GetEnemyInfo.Instance.getEnemyAtk(Monster_Code) * add_state);
        def = Mathf.FloorToInt(GetEnemyInfo.Instance.getEnemyDef(Monster_Code) * add_state);
        a_spd = GetEnemyInfo.Instance.getEnemyAtkSp(Monster_Code);
        m_spd = GetEnemyInfo.Instance.getEnemyMvSp(Monster_Code);
        //스텟들 할당
        animator = this.GetComponent<Animator>();

        MonsterManager.Instance.Move(this.gameObject);//시작하면 이동
}

    // Update is called once per frame
    void Update()
    {
        if (this.hp <= 0)
        {
            Destroy(this.gameObject);
            MonsterManager.Instance.Clear_Count--;
        }
        else if (hp != Max_hp && Do_Battle)
        {
            Hp_bar.gameObject.SetActive(true);
            Hp_bar.value = (float)hp / (float)Max_hp;

        }
        else
        {
            Hp_bar.gameObject.SetActive(false);
        }
    }

    public IEnumerator GotoTarget() //타일 위치로 이동하는 코루틴
    {
        Do_Battle = false;
        while (Vector3.Distance(transform.position, Targetlocation.GetComponent<Transform>().position)>=0.01f)
        {
            Vector3 dir = Targetlocation.transform.position - this.transform.position;
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 3);

            transform.position = Vector3.MoveTowards(transform.position,Targetlocation.GetComponent<Transform>().position, 3 * Time.deltaTime);
            yield return null;
        }

        Currentlocation = Targetlocation;
        CurrentTile = Targettile;
        MonsterManager.Instance.InTile(this.gameObject);


    }

    public IEnumerator Battle_Monster() //
    {
        while (MonsterManager.Instance.isUnit(CurrentTile))//적유닛이 없을 때까지 반복
        {
            Do_Battle = true;
            yield return new WaitForSeconds(a_spd / 100); //공격 속도 이후에
            StartCoroutine(Attack());//공격


        yield return new WaitForSeconds(a_spd /100);
        }
        Do_Battle = false;
        this.GetComponent<Animator>().SetBool("isIdle", false);//이동애니를위한 변수조정
        this.GetComponent<Animator>().SetBool("isAttack", false);//이동애니를위한 변수조정
        MonsterManager.Instance.Move(this.gameObject);//이동시작

        yield return null;
    }

    public IEnumerator Attack() {
       // print("전투중");

        if (TargetUnit == null && MonsterManager.Instance.isUnit(CurrentTile)) //타겟 유닛이 없으면
        {
            int target = Random.Range(0, 3);
            while (CurrentTile.GetComponent<Tile>().Unit[target] == null)
            {
                target = Random.Range(0, 3);
            }
            TargetUnit = CurrentTile.GetComponent<Tile>().Unit[target];//타겟유닛 할당

        }


        if (TargetUnit != null) {//타겟 유닛이 있으면
            this.GetComponent<Animator>().SetBool("isAttack", true);
           // yield return new WaitForSeconds(0.35f);//공격 선딜레이후
            if (TargetUnit != null)//선딜중에 유닛이 안죽었으면
            {
                SoundManager.Instance.SE_Play(Attack_sound, 1f);
                int dmg;
                dmg = BattleManager.Instance.Damage_Unit(this.gameObject, TargetUnit);
                TargetUnit.GetComponent<Unit>().hp -= dmg;
                MonsterManager.Instance.DamageFont_produce(dmg, TargetUnit);
                Attack_Effect_on();
                //TargetUnit.GetComponent<Unit>().hp -= atk;//유닛의 체력 공격력만큼 감소
                //print("적hp  "+TargetUnit.GetComponent<Unit>().hp);

            }
           // else//선딜중에 적이 죽었으면
            //{
               // this.GetComponent<Animator>().SetBool("isAttack", false);
                //공격취소
           // }

            if (TargetUnit.GetComponent<Unit>().hp < 0)
            {
                TargetUnit = null;
            }

        }
        
        yield return null;
        this.GetComponent<Animator>().SetBool("isAttack", false);
    }

    void Attack_Effect_on()
    {
        Attack_Effect.transform.position = TargetUnit.transform.position + new Vector3(0, 1, 0);
        Attack_Effect.Play();
        print("몬스터 이펙트");
    }

}
