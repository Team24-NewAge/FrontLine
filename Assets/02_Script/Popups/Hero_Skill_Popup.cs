using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero_Skill_Popup : PopupBase
{
   public Text Skill_name;
    public Text Skill_ex;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetText(string name, string ex)
    {
        Skill_name.text = name;
        Skill_ex.text = ex;
    }

    public override void HidePopup()
    {

        base.HidePopup();

    }

}
