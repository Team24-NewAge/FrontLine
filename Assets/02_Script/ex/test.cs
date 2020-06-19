using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            PanelManager.Instance.ShowTestPanel("선택했다");
           
        }
        
    }


   public void testimage() 
    {
        print("클릭작동");

        PaperManager.Instance.N_NewMonth();
        PaperManager.Instance.PaperSetting();

    }
}
