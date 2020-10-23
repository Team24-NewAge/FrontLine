using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitShop_Popup : PopupBase
{


    public Text buygold;
    public Text fusiongold;
    public Text reinforcegold;

    public void Awake()
    {

    }


    // Start is called before the first frame update
    void Start()
    {
        buygold.text = (200 + (GameManager.Instance.UnitBuyStack * 20)).ToString();
        fusiongold.text = (200 + (GameManager.Instance.UnitBuyStack * 20)).ToString();
        reinforcegold.text = (200 + (GameManager.Instance.UnitBuyStack * 20)).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    public void UnitBuy() { 
    
    
    
    }

    public void UnitFusion()
    {



    }

    public void UnitReinforce()
    {



    }


    public override void HidePopup()
    {

        base.HidePopup();

    }
}
