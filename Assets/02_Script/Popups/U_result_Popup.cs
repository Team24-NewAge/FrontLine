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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void HidePopup()
    {

        base.HidePopup();

    }


    public void Fusion_popup(int code) {
        Popup_name.text = "합성 결과";
        unit_face.sprite = GetUnitSOInfo.Instance.unitface[code];
        unit_name.text = "[" + GetUnitSOInfo.Instance.getUnitName(code) + "]";
        unit_hp.text = "HP : " + GetUnitSOInfo.Instance.getUnitHp(code);
        unit_atk.text = "ATK : " + GetUnitSOInfo.Instance.getUnitAtk(code);
        unit_spd.text = "SPD : " + GetUnitSOInfo.Instance.getUnitAtkSp(code);
        unit_def.text = "DEF : " + GetUnitSOInfo.Instance.getUnitDef(code);
    }
    public void Reinforce_Popup()
    {
        Popup_name.text = "강화 결과";

    }
}
