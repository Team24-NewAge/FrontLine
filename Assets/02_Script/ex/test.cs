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
}
