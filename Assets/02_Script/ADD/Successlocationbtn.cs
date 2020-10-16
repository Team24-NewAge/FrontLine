using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Successlocationbtn : MonoBehaviour
{
    public GameObject Summon;
    public GameObject Hero_info;
    public GameObject Monsterstart;
 
    


    public void OnButtonClick()
    {
        Summon.SetActive(false);
        Hero_info.SetActive(true);
        Monsterstart.SetActive(true);

    }
}
