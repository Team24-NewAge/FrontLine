using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Successlocationbtn : MonoBehaviour
{
    public GameObject Summon;
    public GameObject Monsterstart;
    public Camera camera;


    public void OnButtonClick()
    {
        Summon.SetActive(false);
        camera.rect = new Rect(0.0f,0.0f,1.0f,1.0f);
        Monsterstart.SetActive(true);


    }
}
