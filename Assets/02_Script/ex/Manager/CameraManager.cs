using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public Camera Maincam;
    public Camera Battlecam;
    public Camera Resultcam;


    public static CameraManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }



    public void BattleCam_on()
    {
        Maincam.gameObject.SetActive(false);
        Resultcam.gameObject.SetActive(false);
        Battlecam.gameObject.SetActive(true);
    }

    public void MainCam_on()
    {
        Maincam.gameObject.SetActive(true);
        Resultcam.gameObject.SetActive(false);
        Battlecam.gameObject.SetActive(false);
    }
    public void ResultCam_on()
    {
        Maincam.gameObject.SetActive(false);
        Resultcam.gameObject.SetActive(true);
        Battlecam.gameObject.SetActive(false);
    }
}

