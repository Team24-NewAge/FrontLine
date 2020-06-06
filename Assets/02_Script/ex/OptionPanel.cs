using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OptionPanel : PanelBase

{
    public override void OnShow()
    {
    }


    public override void OnHide()
    {
    }

    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Escape))

            {
            gameObject.SetActive(false);

            }

    }

}
