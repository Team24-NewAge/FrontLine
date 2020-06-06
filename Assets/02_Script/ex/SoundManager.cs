using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    [SerializeField] private AudioSource BGM;
    [SerializeField] private Slider BGMChanger;


    public static SoundManager Instance { get; private set; }
    private SoundManager _currunt;


    public void Awake()
    {
        Instance = this;
    }

    public void BGMoption()
    {
        BGM.volume = BGMChanger.value;
    }






}
