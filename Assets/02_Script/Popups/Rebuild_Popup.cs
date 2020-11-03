using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rebuild_Popup : PopupBase
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public override void HidePopup()
    {
        PaperManager.Instance.Paper_Locked_off();
        base.HidePopup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
