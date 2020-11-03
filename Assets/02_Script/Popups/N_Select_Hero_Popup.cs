using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class N_Select_Hero_Popup : PopupBase
{
    [SerializeField] private string Hero_name;
    [SerializeField] private GameObject Warrior;
    [SerializeField] private Button Warrior_Btn;

    [SerializeField] private GameObject Mage;
    [SerializeField] private Button Mage_Btn;



    public void Awake()
    {
        OnWarrirBtn();
    }

    void Update()
    {

        //if (Application.platform == RuntimePlatform.Android)

        {

            if (Input.GetKeyDown(KeyCode.Escape))

            {
                var popup = PopupManager.Instance.ShowGameModeSelectPopup();
                HidePopup();
            }



        }

    }

    public void OnWarrirBtn()
    {
        SetBtn();

        Warrior.SetActive(true);
        Warrior_Btn.enabled = false;
        GameObject hero_model = Warrior.transform.Find("Warrior-model").gameObject;
        hero_model.GetComponent<HeroSelectPosition>().Rerot();
        


        Hero_name = "전사";
    }

    public void OnMageBtn()
    {
        SetBtn();

        Mage.SetActive(true);
        Mage_Btn.enabled = false;
        GameObject hero_model = Mage.transform.Find("Mage-model").gameObject;
        hero_model.GetComponent<HeroSelectPosition>().Rerot();
 

        Hero_name = "마법사";
    }


    public void SetBtn() {
        Warrior.SetActive(false);
        Warrior_Btn.enabled = true;


        Mage.SetActive(false);
        Mage_Btn.enabled = true;
    }



    public void Onprevious()
    {
        var popup = PopupManager.Instance.ShowGameModeSelectPopup();
        HidePopup();
    }

    public void OnNext()
    {
        var popup = PopupManager.Instance.ShowSelelctPickPopup();
        HidePopup();

        PlayerPrefs.SetString("Hero", Hero_name);
    }


    public override void HidePopup()
    {
        base.HidePopup();

    }
}
