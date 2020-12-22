using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarManager : MonoBehaviour
{
    public Text date_text;
    public int date=0;
    public Text gold_text;
    public int gold=0;


    public Image hp_bar;
    public Text hp_string;

    public Image mp_bar;
    public Text mp_string;

    public Image pray_color;
    public int pray_code;
    public int pray_turn;
    public int pray_power;
    public Text pray_string;

    public GameObject Hero;

    public static BarManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;


       int  prefs_continue = PlayerPrefs.GetInt("CONTINUE", 0);
        if (prefs_continue == 0)
        {  
            //CONTINUE = false;
            _SetDate();
            _SetCoin();
        }
        else
        {
            //CONTINUE = true;
            gold = PlayerPrefs.GetInt("Gold", 0);
            date = PlayerPrefs.GetInt("Date", date);
            _SetDate();
            _SetCoin();
        }
     

    }

    public void _SetDate() {
        //print(PaperManager.Instance.today);
        PlayerPrefs.SetInt("Date",date);
        date_text.text = "D + " + date;
    }

    public void _SetCoin()
    {
        PlayerPrefs.SetInt("Gold", gold);
        gold_text.text = gold.ToString();
    }

    public void _SetDate_test()
    {
        InputField cd = GameObject.Find("cd").GetComponent<InputField>();
        print(cd.text);
        int test_date =  int.Parse(cd.text) ;
        date = test_date;
        //PlayerPrefs.SetInt("Date", date);
        date_text.text = "D + " + date;
    }

    public void _SetCoin_test()
    {
        InputField cg = GameObject.Find("cg").GetComponent<InputField>();
        int test_gold = int.Parse(cg.text);
        gold = test_gold;
        //PlayerPrefs.SetInt("Gold", gold);
        gold_text.text = gold.ToString();
    }


    private void Update()
    {
        float full = Hero.GetComponent<Unit>().Max_hp;
        float c_hp = Hero.GetComponent<Unit>().hp;
        hp_bar.fillAmount =  c_hp/full;
        hp_string.text = Hero.GetComponent<Unit>().hp.ToString()+"/"+ Hero.GetComponent<Unit>().Max_hp.ToString();

        if (BattleManager.Instance.isBattle)
        {
            if (BattleManager.Instance.Hero_Mana < 100)
            {
                if (pray_code == 2)
                {
                    BattleManager.Instance.Hero_Mana += (10 * Time.deltaTime)* (1 + (pray_power/100f));
                }
                else {
                    BattleManager.Instance.Hero_Mana += 10 * Time.deltaTime;
                }
              
            }
            else {
                BattleManager.Instance.Hero_Mana = 100f;
            }


            mp_bar.fillAmount = BattleManager.Instance.Hero_Mana / 100;
            mp_string.text = Mathf.FloorToInt(BattleManager.Instance.Hero_Mana) + "/ 100";

        }

    }

    public void Update_Pray()
    {
        pray_turn--;
        if (pray_turn < 0)
        {
            pray_string.text = "현재 아무런 축복이 없습니다.";
            pray_code = 0;
            pray_color.color = Color.white;
        }
        switch (pray_code)
        {
            case 1:
                pray_string.text = "공격력 " + pray_turn + "일 간 " + pray_power + "% 증가";
                PlayerPrefs.SetInt("pray_code", pray_code);
                PlayerPrefs.SetInt("pray_turn", pray_turn);
                PlayerPrefs.SetInt("pray_power", pray_power);
                break;
            case 2:
               pray_string.text = "마나재생 " + pray_turn + "일 간 " + pray_power + "% 증가";
                PlayerPrefs.SetInt("pray_code", pray_code);
                PlayerPrefs.SetInt("pray_turn", pray_turn);
                PlayerPrefs.SetInt("pray_power", pray_power);
                break;
            case 3:
                pray_string.text = "방어력 " + pray_turn + "일 간 " + pray_power + "증가";
                PlayerPrefs.SetInt("pray_code", pray_code);
                PlayerPrefs.SetInt("pray_turn", pray_turn);
                PlayerPrefs.SetInt("pray_power", pray_power);
                break;
        }
    }
}
