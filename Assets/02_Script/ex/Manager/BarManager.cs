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

    public GameObject Hero;

    public static BarManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        date_text.text = "D + " + date;

    }

    public void _SetDate() {
        //print(PaperManager.Instance.today);
        date_text.text = "D + " + date;
    }

    public void _SetCoin()
    {
        //print(PaperManager.Instance.today);
        gold_text.text = gold.ToString();
    }

    private void Update()
    {
        float full = Hero.GetComponent<Unit>().Full_hp;
        float c_hp = Hero.GetComponent<Unit>().hp;
        hp_bar.fillAmount =  c_hp/full;
        hp_string.text = Hero.GetComponent<Unit>().hp.ToString()+"/"+ Hero.GetComponent<Unit>().Full_hp.ToString();

    }
}
