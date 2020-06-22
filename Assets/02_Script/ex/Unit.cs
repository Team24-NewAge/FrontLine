using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    public int Code;
    public string Name;
    public Sprite sprite;
    public int grade;
    public string description;

    public int Full_hp;

    public int hp;

    public int atk;
    public int def;
    public int a_spd;
    public float a_del;
    public int m_spd; // 스텟들

    public GameObject TargetUnit;//공격대상

    float t=0;
    float a_speed;

    public Tile Current_Tile; // 현재 배치된 타일
    public GameObject Current_Location; // 현재 배치된 타일위치
    public string Current_Location_number;// 현재 배치된 타일번호

    void Start()
    {
        Current_Location_number = Current_Location.name;
        Current_Location_number = Current_Location_number[Current_Location_number.Length - 1].ToString();
        a_speed = a_spd;
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }


        t += Time.deltaTime;
        if (t > a_speed / 100.0f) 
        {
            this.transform.position = Current_Location.transform.position;
            //print(t);
            if (UnitManager.Instance.isMons(Current_Tile)&&TargetUnit==null) 
        {
            int target = Random.Range(0, 3);
            while (Current_Tile.GetComponent<Tile>().Mons[target] == null)
            {
                target = Random.Range(0, 3);
            }
            TargetUnit = Current_Tile.GetComponent<Tile>().Mons[target];//타겟유닛 할당
            StartCoroutine(Attack());
        }
            t = 0;
        }

    }

    void Reset()
    {
        this.transform.position = Current_Location.transform.position;

    }
    public IEnumerator Attack()
    {
        t = 0;
        while (TargetUnit != null) {
            print("유닛공격함!");
            this.GetComponent<Animator>().SetBool("isAttack", true);
            yield return new WaitForSeconds(a_del);

            if (TargetUnit != null)
            {
                TargetUnit.GetComponent<Monster>().hp -= atk;
                print("적hp  " + TargetUnit.GetComponent<Monster>().hp);
                this.GetComponent<Animator>().SetBool("isAttack", false);
                t = 0;
            }
            else
            {
                this.GetComponent<Animator>().SetBool("isAttack", false);
                t = 0;
            }

            t = 0;
            yield return new WaitForSeconds(a_speed / 100.0f);
        }
        t = 0;
        yield return new  WaitForSeconds(a_speed / 100.0f);
        
    }
}
