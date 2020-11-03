using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitShop_Popup : PopupBase
{


    public Text buygold;
    public Text fusiongold;
    public Text reinforcegold;

    public GameObject exit_popup;
    public GameObject fadeimage;
    public void Awake()
    {

    }


    // Start is called before the first frame update
    void Start()
    {
        buygold.text = (200 + (GameManager.Instance.UnitBuyStack * 20)).ToString();
        fusiongold.text = (200 + (GameManager.Instance.UnitFusionStack * 20)).ToString();
        reinforcegold.text = (200 + (GameManager.Instance.UnitReinForceStack * 20)).ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }




    public void UnitBuy() {

        PopupManager.Instance.ShowUnitBuy_Popup();
        HidePopup();

        GameManager.Instance.UnitBuyStack++;
    }

    public void UnitFusion()
    {



    }

    public void UnitReinforce()
    {



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
}
