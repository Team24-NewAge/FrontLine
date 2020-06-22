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

            print("전투승리!!!");
            isBattle = false;
            Invoke("ExitBattle", 1f);
            PopupManager.Instance.ShowBattle_Win_Popup();
        
        }
    }



    public void DoBattle() {

        int unit_count = Unit.transform.GetChildCount() - 1;

        Unit_inGame = new GameObject[unit_count];

        for (int i = 0; i < unit_count; i++) {
            print(i + "갯수");
            Unit_inGame[i] = Unit.transform.GetChild(i).gameObject;
            Unit_inGame[i].GetComponent<Unit>().hp = Unit_inGame[i].GetComponent<Unit>().Full_hp;
        }

        MonsterManager.Instance.Regen();
        isBattle = true;
    
    }


    public void ExitBattle() {
        CameraManager.Instance.ExitBattle();
    }
}
