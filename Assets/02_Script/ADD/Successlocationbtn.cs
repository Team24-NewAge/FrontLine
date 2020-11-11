using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Successlocationbtn : MonoBehaviour
{
    
    public void OnButtonClick()
    {
        
        PlacementManager.Instance.Close_Placement();
        
    }
    
}
