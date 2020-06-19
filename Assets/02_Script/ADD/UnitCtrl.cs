using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCtrl : MonoBehaviour
{
    private Transform monsterTr;//추적대상
    private Transform UnitTr;
    private Animator animator;
    
    public enum UnitState
    {
        idle,
        attack,
        die
    };
    public UnitState unitState = UnitState.idle;
    public float attackDist = 2.0f;
    private bool isDie = false;
    
    void Start()
    {
        UnitTr = this.gameObject.GetComponent<Transform>();
        monsterTr = GameObject.FindWithTag("Monster").GetComponent<Transform>();
        animator = this.gameObject.GetComponent<Animator>();
        StartCoroutine(this.CheckUnitState()); // 몬스터 행동상태 체크
        StartCoroutine(this.UnitAnim()); // 몬스터 상태에 따른 동작
    }

    IEnumerator CheckUnitState()
    {
        while (!isDie)
        {
            yield return new WaitForSeconds(0.2f);
            float dist = Vector3.Distance(UnitTr.position, monsterTr.position);
            if (dist <= attackDist)//2미터 안에 들어오면
            {
                unitState = UnitState.attack;
            }
            else
            {
                unitState = UnitState.idle;
            }
        }
    }
    
    IEnumerator UnitAnim()
    {
        while (!isDie)
        {
            switch (unitState)
            {
                case UnitState.idle:
                    //animator.SetBool("IsAttack",false);
                    break;
                case UnitState.attack:
                    animator.SetBool("IsAttack",true);
                    break;
            }
            yield return null;
        }
    }
    void Update()
    {
        
    }
}
