using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class UnitBuy_Popup : PopupBase
{
    public Image[] unit_face = new Image[3];
    public Image[] unit1_star = new Image[5];
    public Image[] unit2_star = new Image[5];
    public Image[] unit3_star = new Image[5];
    public Text[] unit_name = new Text[3];
    public Text[] unit_hp = new Text[3];
    public Text[] unit_atk = new Text[3];
    public Text[] unit_spd = new Text[3];
    public Text[] unit_def = new Text[3];
    public Text[] unit1_skill = new Text[3];
    public Text[] unit2_skill = new Text[3];
    public Text[] unit3_skill = new Text[3];
    public int[] unit_code = new int[3];
    public void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        RandomUnit(0);
        RandomUnit(1);
        RandomUnit(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public override void HidePopup()
    {

        base.HidePopup();

    }



    void RandomUnit(int num) {
        float unitpercentage = Random.Range(0f,1f);
        int unitgrade,unitcode;

        if (unitpercentage < GameManager.Instance.unitper_add[1])//1성뜸
        {
            do
            {
                unitcode = Random.Range(0, 5);
                unitgrade = GetUnitSOInfo.Instance.getUnitGrade(unitcode);
            } while (unitgrade != 1);
            unit_code[num] = unitcode;
            UpdateBuyPopup(num, unitcode,1);

        }
        else if (GameManager.Instance.unitper_add[1] <= unitpercentage && unitpercentage < GameManager.Instance.unitper_add[2]) //2성뜸
        {
            do
            {
                unitcode = Random.Range(0, 5);
                unitgrade = GetUnitSOInfo.Instance.getUnitGrade(unitcode);
            } while (unitgrade != 2);
            unit_code[num] = unitcode;
            UpdateBuyPopup(num, unitcode,2);


        }
        else if (GameManager.Instance.unitper_add[2] <= unitpercentage && unitpercentage < GameManager.Instance.unitper_add[3])//3성뜸
        {
            do
            {
                unitcode = Random.Range(0, 5);
                unitgrade = GetUnitSOInfo.Instance.getUnitGrade(unitcode);
            } while (unitgrade != 3);
            unit_code[num] = unitcode;
            UpdateBuyPopup(num, unitcode,3);

        }
        else if (GameManager.Instance.unitper_add[3] <= unitpercentage && unitpercentage < GameManager.Instance.unitper_add[4])//4성뜸
        {
            do
            {
                unitcode = Random.Range(0, 5);
                unitgrade = GetUnitSOInfo.Instance.getUnitGrade(unitcode);
            } while (unitgrade != 4);
            unit_code[num] = unitcode;
            UpdateBuyPopup(num, unitcode,4);

        }
        else if (GameManager.Instance.unitper_add[4] <= unitpercentage && unitpercentage <= GameManager.Instance.unitper_add[5])//5성뜸
        {
            do
            {
                unitcode = Random.Range(0, 5);
                unitgrade = GetUnitSOInfo.Instance.getUnitGrade(unitcode);
            } while (unitgrade != 5);
            unit_code[num] = unitcode;
            UpdateBuyPopup(num, unitcode,5);

        }

    }


    void UpdateBuyPopup(int num, int code,int grade) {
        unit_face[num].sprite = GetUnitSOInfo.Instance.unitface[code];
        switch(num){
            case 0: { for (int i = 0; i < grade; i++) {
                        unit1_star[i].gameObject.SetActive(true);
                    }
                } break;
            case 1: {
                    for (int i = 0; i < grade; i++)
                    {
                        unit2_star[i].gameObject.SetActive(true);
                    }
                }break;
            case 2: {
                    for (int i = 0; i < grade; i++)
                    {
                        unit3_star[i].gameObject.SetActive(true);
                    }
                } break;
        }

        unit_name[num].text = "[" + GetUnitSOInfo.Instance.getUnitName(code) +"]";
        unit_hp[num].text = "HP : " + GetUnitSOInfo.Instance.getUnitHp(code);
        unit_atk[num].text = "ATK : " + GetUnitSOInfo.Instance.getUnitAtk(code);
        unit_spd[num].text = "SPD : " + GetUnitSOInfo.Instance.getUnitAtkSp(code);
        unit_def[num].text = "DEF : " + GetUnitSOInfo.Instance.getUnitDef(code);

        int unitskill_count = GetUnitSOInfo.Instance.getUnitSkillLength(code);

    }


   public void test() {

        for (int i = 0; i < 5; i++)
        {
            unit1_star[i].gameObject.SetActive(false);
            unit2_star[i].gameObject.SetActive(false);
            unit3_star[i].gameObject.SetActive(false);
        }
        RandomUnit(0);
        RandomUnit(1);
        RandomUnit(2);
    }
}
