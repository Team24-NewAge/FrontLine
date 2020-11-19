using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class U_result_Popup : PopupBase
{
    public Text Popup_name;
    public Image unit_face;
    public Image[] unit1_star = new Image[5];
    public Text unit_name;
    public Text unit_hp;
    public Text unit_atk;
    public Text unit_spd;
    public Text unit_def ;
    public Text unit1_skill;

    bool fusion = false;
    bool reinforce = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void HidePopup()
    {
        if (fusion)
        {
            Hero_Skill_Popup information = PopupManager.Instance.ShowHero_Skill_Popup();
            information.SetText("유닛 획득", "유닛을 확인하고 배치하세요");
        }
        else 
        {
            PopupManager.Instance.ShowUnitShop_Popup();
        }
       

        base.HidePopup();

    }


    public void Fusion_popup(int code) {
        SoundManager.Instance.result_sound();
        fusion = true;

        Popup_name.text = "합성 결과";
        for (int i = 0; i < GetUnitSOInfo.Instance.getUnitGrade(code); i++)
        {
            unit1_star[i].gameObject.SetActive(true);
        }

        unit_face.sprite = GetUnitSOInfo.Instance.unitface[code];
        unit_name.text = "[" + GetUnitSOInfo.Instance.getUnitName(code) + "]";
        unit_hp.text = "HP : " + GetUnitSOInfo.Instance.getUnitHp(code);
        unit_atk.text = "ATK : " + GetUnitSOInfo.Instance.getUnitAtk(code);
        unit_spd.text = "SPD : " + GetUnitSOInfo.Instance.getUnitAtkSp(code);
        unit_def.text = "DEF : " + GetUnitSOInfo.Instance.getUnitDef(code);
    }
    public void Reinforce_Popup(int code ,int hp, int atk, int spd, int def)
    {
        SoundManager.Instance.result_sound();
        fusion = false;

        Popup_name.text = "강화 결과";
        for (int i = 0; i < GetUnitSOInfo.Instance.getUnitGrade(code); i++)
        {
            unit1_star[i].gameObject.SetActive(true);
        }
        unit_face.sprite = GetUnitSOInfo.Instance.unitface[code];
        unit_name.text = "[" + GetUnitSOInfo.Instance.getUnitName(code) + "]";
        unit_hp.text = "HP : " + hp;
        unit_atk.text = "ATK : " + atk;
        unit_spd.text = "SPD : " + spd;
        unit_def.text = "DEF : " + def;
    }
}
