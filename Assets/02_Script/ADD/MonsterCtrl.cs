using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCtrl : MonoBehaviour
{
    private Transform monsterTr;
    private Transform UnitTr;//추적대상
    private UnityEngine.AI.NavMeshAgent/*안될 경우 UnityEngine.AI.NavMeshAgent*/ nvAgent;
    private Animator animator;

    public enum MonsterState 
    {
        idle,
        trace,
        attack,
        die
    };
    public MonsterState monsterState = MonsterState.idle;
	
    public float traceDist = 10.0f; // 추적 사정거리
    public float attackDist = 2.0f; // 공격 사정거리
    private bool isDie = false;
	
    void Start ()
    {
        monsterTr = this.gameObject.GetComponent<Transform>();
        UnitTr = GameObject.FindWithTag("Unit").GetComponent<Transform>();
        nvAgent = this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent/*안될 경우 UnityEngine.AI.NavMeshAgent*/>();
        animator = this.gameObject.GetComponent<Animator>();
        //nvAgent./*중요*/destination/*목적지 목표*/ = playerTr.position;
        StartCoroutine(this.CheckMonsterState()); // 몬스터 행동상태 체크
        StartCoroutine(this.MonsterAnim()); // 몬스터 상태에 따른 동작
    }

    IEnumerator CheckMonsterState()
    {
        while (!isDie)
        {
            yield return new WaitForSeconds(0.2f);
            float dist = Vector3.Distance(UnitTr.position, monsterTr.position);
            if (dist <= attackDist)//2미터 안에 들어오면
            {
                monsterState = MonsterState.attack;
            }
            else if (dist <= traceDist)//10미터 안에 들어오면
            {
                monsterState = MonsterState.trace;
            }
            else
            {
                monsterState = MonsterState.idle;
            }
        }
    }
	
    IEnumerator MonsterAnim()
    {
        while (!isDie)
        {
            switch (monsterState)
            {
                case MonsterState.idle: 
                    nvAgent.Stop();
                    animator.SetBool("IsTrace",false);
                    break;
                case MonsterState.trace:
                    nvAgent.destination = UnitTr.position;//목표
                    nvAgent.Resume()/*재시작*/;         
                    animator.SetBool("IsAttack",false);
                    animator.SetBool("IsTrace",true);
                    break;
                case MonsterState.attack: 
                    nvAgent.Stop();
                    animator.SetBool("IsAttack",true);
                    break;
            }
            yield return null;
        }
    }
}
