using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{


  
    public static SoundManager Instance { get; private set; }
   


    public void Awake()
    {
        Instance = this;
    }


    public void Start()
    {
        this.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("bgm", 0f);
    }

    






}
