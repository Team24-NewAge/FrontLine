using System.Collections;
using System.Collections.Generic;
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

    public void Awake()
    {

    }
    // Start is called before the first frame update
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
}
