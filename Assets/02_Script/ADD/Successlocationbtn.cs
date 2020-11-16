using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Successlocationbtn : MonoBehaviour
{
    
    public void OnButtonClick()
    {
        SoundManager.Instance.menu_ok_Play();
        PlacementManager.Instance.Close_Placement();
        
    }
    
}
