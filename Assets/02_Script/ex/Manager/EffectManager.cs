using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{

    public static EffectManager Instance { get; private set; }


    public GameObject Healeffect;
    public GameObject traning_debuff;
    public GameObject traning_buff;
    public GameObject traning_perfect;
    public GameObject pray;
    public GameObject BossEffect;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
