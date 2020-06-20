using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public Camera Maincam;
    public Camera Battlecam;


    public static CameraManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }



    public void DoBattle() {
        Maincam.gameObject.SetActive(false);
        Battlecam.gameObject.SetActive(true);
    }

}
