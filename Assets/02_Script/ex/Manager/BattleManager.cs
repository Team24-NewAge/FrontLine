using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance { get; private set; }

    public GameObject commandcanvas;
    public GameObject Unit;
    public GameObject[] Unit_inGame;
    public GameObject Hero;

    public AudioClip Battle_win1, Battle_win2;
    public bool isBattle;

    public float Hero_Mana;

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
        }
    }

    public void DoBattle() {

        Unit_Setting();
        MonsterManager.Instance.Regen();//리젠 시작
        isBattle = true;//전투중인지 알려주는 bool값 
    
    }

    public void Unit_Setting()
    {

        int unit_count = Unit.transform.childCount - 1;//유닛 카운트 생성

        Unit_inGame = new GameObject[unit_count];//유닛 배열 생성

        for (int i = 0; i < unit_count; i++)
        {//유닛 개수만큼 반복
            print(i + "갯수");
            Unit_inGame[i] = Unit.transform.GetChild(i).gameObject;//유닛 배열에 유닛할당
            Unit_inGame[i].GetComponent<Unit>().hp = Unit_inGame[i].GetComponent<Unit>().Max_hp;
            Unit_inGame[i].GetComponent<Unit>().Reset();
            Unit_inGame[i].gameObject.SetActive(true);
            Unit_inGame[i].GetComponent<Unit>().Current_Tile.GetComponent<Tile>().Unit[int.Parse(Unit_inGame[i].GetComponent<Unit>().Current_Location_number) - 1] = Unit_inGame[i];
            Unit_inGame[i].GetComponent<Unit>().isbattile = false;
            //전투시작전에 영웅 제외 모든 유닛 체력 최대로 회복
        }
    }

    public void ExitBattle() {

        Hero_Mana = 0f;
        BarManager.Instance.mp_bar.fillAmount = Hero_Mana / 100;
        BarManager.Instance.mp_string.text = Mathf.FloorToInt(Hero_Mana) + "/ 100";

        SoundManager.Instance.SE_Play(Battle_win1, 3f);
        SoundManager.Instance.BgmAudio.clip = Battle_win2;
        SoundManager.Instance.BgmAudio.Play();
        PopupManager.Instance.ShowBattle_Win_Popup();
        CameraManager.Instance.ExitBattle();
        Unit_Setting();
        PaperManager.Instance.Paper_Locked_off();

    }


    public int Damage_Monster(GameObject UNIT, GameObject  MONSTER)//유닛이 몬스터 공격
    {
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
    public int Damage_Skill(GameObject UNIT, GameObject MONSTER, float coefficient)//유닛이 스킬로 몬스터 공격
    {
        Unit unit = UNIT.GetComponent<Unit>();
        Monster monster = MONSTER.GetComponent<Monster>();

        int damage;//초기 데미지 0

        damage = Mathf.FloorToInt(unit.atk * coefficient);//유닛의 공격력
        damage = (damage / ((100 + monster.def) / 100));//몬스터 방어력 계산

        MonsterManager.Instance.DamageFont_produce(damage, MONSTER);
        return damage;
    }

    public int Damage_Unit(GameObject Monster, GameObject Unit)//몬스터가 유닛공격
    {
  
        Monster monster = Monster.GetComponent<Monster>();
        Unit unit = Unit.GetComponent<Unit>();
        int damage;//초기 데미지 0

        damage = monster.atk;//유닛의 공격력
        damage = (damage / ((100 + unit.def) / 100));//몬스터 방어력 계산


        return damage;
    }



}
