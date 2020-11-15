using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitShop_Popup : PopupBase
{


    public Text buygold;
    public Text fusiongold;
    public Text reinforcegold;

    public Button buy, fusion, reinforce;

    public GameObject exit_popup;
    public GameObject fadeimage;

    int buygold_num;
    int fusiongold_num;
    int reinforcegold_num;
    public void Awake()
    {

    }


    // Start is called before the first frame update
    void Start()
    {
        buygold_num = (100 + (GameManager.Instance.UnitBuyStack * 20));
        fusiongold_num = (100 + (GameManager.Instance.UnitFusionStack * 20));
        reinforcegold_num = (100 + (GameManager.Instance.UnitReinForceStack * 20));

        buygold.text = buygold_num.ToString();
        fusiongold.text = fusiongold_num.ToString();
        reinforcegold.text = reinforcegold_num.ToString();


        if (BarManager.Instance.gold < buygold_num) {

            buy.interactable = false;
        }
        if (BarManager.Instance.gold < fusiongold_num)
        {

            fusion.interactable = false;
        }
        if (BarManager.Instance.gold < reinforcegold_num)
        {

            reinforce.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }




    public void UnitBuy() {

        BarManager.Instance.gold -= buygold_num;
        BarManager.Instance._SetCoin();


        PopupManager.Instance.ShowUnitBuy_Popup();
        HidePopup();

        GameManager.Instance.UnitBuyStack++;
    }

    public void UnitFusion()
    {
        BarManager.Instance.gold -= fusiongold_num;
        BarManager.Instance._SetCoin();

        GameManager.Instance.UnitFusionStack++;
        HidePopup();
        InventoryManager.Instance.Open_Fusion();
        
    }

    public void UnitReinforce()
    {
        BarManager.Instance.gold -= reinforcegold_num;
        BarManager.Instance._SetCoin();

        GameManager.Instance.UnitReinForceStack++;
        HidePopup();
        InventoryManager.Instance.Open_Reinforce();
    }

    public void Exitpopup_on()
    {
        exit_popup.SetActive(true);
        fadeimage.SetActive(true);
    }
    public void Exitpopup_off()
    {
        exit_popup.SetActive(false);
        fadeimage.SetActive(false);
    }

    public override void HidePopup()
    {

        base.HidePopup();

    }

    public void LobbyBGM_On()
    {
        SoundManager.Instance.Lobby_On();
    }
}
