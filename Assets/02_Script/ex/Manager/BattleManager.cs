using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance { get; private set; }

    public GameObject commandcanvas;
    public GameObject Unit;
    public GameObject[] Unit_inGame;
    bool isBattle;


    public void Awake()
    {
        Instance = this;
        isBattle = false;
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (isBattle == true && MonsterManager.Instance.Clear_Count <= 0) 
        {
            isBattle = false;
            Invoke("ExitBattle", 1f);
            PopupManager.Instance.ShowBattle_Win_Popup();
        
        }
    }



    public void DoBattle() {
        int unit_count = Unit.transform.childCount - 1;//유닛 카운트 생성

        Unit_inGame = new GameObject[unit_count];//유닛 배열 생성

        for (int i = 0; i < unit_count; i++) {//유닛 개수만큼 반복
            //print(i + "갯수");
            Unit_inGame[i] = Unit.transform.GetChild(i).gameObject;//유닛 배열에 유닛할당
            Unit_inGame[i].GetComponent<Unit>().hp = Unit_inGame[i].GetComponent<Unit>().Max_hp;
            Unit_inGame[i].gameObject.SetActive(true);
            Unit_inGame[i].GetComponent<Unit>().Current_Tile.GetComponent<Tile>().Unit[int.Parse(Unit_inGame[i].GetComponent<Unit>().Current_Location_number) - 1] = Unit_inGame[i];
            Unit_inGame[i].GetComponent<Unit>().isbattile = false;
            //전투시작전에 영웅 제외 모든 유닛 체력 최대로 회복
        }

        MonsterManager.Instance.Regen();//리젠 시작
        isBattle = true;//전투중인지 알려주는 bool값 
    
    }
   

    public void ExitBattle() {
        CameraManager.Instance.ExitBattle();
        PaperManager.Instance.Paper_Locked_off();
        SoundManager.Instance.Lobby_On();
    }


    public int Damage_Monster(GameObject UNIT, GameObject  MONSTER) {
        Unit unit = UNIT.GetComponent<Unit>();
        Monster monster = MONSTER.GetComponent<Monster>();

        int damage;//초기 데미지 0

        damage = unit.atk;//유닛의 공격력
        damage = (damage /((100 + monster.def)/100));//몬스터 방어력 계산


        //격노 스탯의 존재 | 존재할경우 데미지 1.5배
        if (unit.rage > 0 )
        {
            damage = Mathf.RoundToInt(damage * 1.5f);
            unit.rage--;
            print("데미지 증가! " + damage+"의 피해!");
        }

        //버서커 상태 | 존재할경우 데미지 1.5배
        if (unit.Berserk == true)
        {
            damage = Mathf.RoundToInt(damage * 1.5f);
            print("데미지 증가! " + damage + "의 피해!");
        }

        //스택형 공격의 존재 | 스택을 터뜨려 추가 효과 적용
        if (unit.end_stack == unit.stack)
        {
            damage = Mathf.RoundToInt(damage * unit.stack_buff);
            print("스택 폭발! " + damage + "의 피해!");
        }


        return damage;
    }

    public int Damage_Unit(GameObject Monster, GameObject Unit)
    {
  
        Monster monster = Monster.GetComponent<Monster>();
        Unit unit = Unit.GetComponent<Unit>();
        int damage;//초기 데미지 0

        damage = monster.atk;//유닛의 공격력
        damage = (damage / ((100 + unit.def) / 100));//몬스터 방어력 계산


        return damage;
    }



}
