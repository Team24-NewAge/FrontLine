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
    public int hp;
    public int atk;
    public int def;
    public int a_spd;
    public int m_spd; // 스텟들

    public GameObject TargetUnit;//공격대상


    public GameObject Current_Tile; // 현재 배치된 타일
    public GameObject Current_Location; // 현재 배치된 타일위치
    public string Current_Location_number;// 현재 배치된 타일번호

    void Start()
    {
        Current_Location_number = Current_Location.name;
        Current_Location_number = Current_Location_number[Current_Location_number.Length - 1].ToString();

        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }


        
    }

    void Reset()
    {
        this.transform.position = Current_Location.transform.position;

    }

}
