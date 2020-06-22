using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance { get; private set; }

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
        //DoBattle();
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

        int unit_count = Unit.transform.GetChildCount() - 1;//유닛 카운트 생성

        Unit_inGame = new GameObject[unit_count];//유닛 배열 생성

        for (int i = 0; i < unit_count; i++) {//유닛 개수만큼 반복
            //print(i + "갯수");
            Unit_inGame[i] = Unit.transform.GetChild(i).gameObject;//유닛 배열에 유닛할당
            Unit_inGame[i].GetComponent<Unit>().hp = Unit_inGame[i].GetComponent<Unit>().Full_hp;
            //전투시작전에 영웅 제외 모든 유닛 체력 최대로 회복
        }

        MonsterManager.Instance.Regen();//리젠 시작
        isBattle = true;
    
    }


    public void ExitBattle() {
        CameraManager.Instance.ExitBattle();
    }
}
