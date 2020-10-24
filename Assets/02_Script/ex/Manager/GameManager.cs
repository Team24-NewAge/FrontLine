using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int UnitBuyStack=0;
    public int UnitReinForceStack=0;


    public float[] unitper = new float[6];
    public float[] unitper_add = new float[6];

    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
        unitper[0] = 0.0f;
        unitper[1] = 0.4f;
        unitper[2] = 0.3f;
        unitper[3] = 0.15f;
        unitper[4] = 0.1f;
        unitper[5] = 0.05f;

        unitper_add[0] = 0f;

        for (int i=0; i < (unitper_add.Length)-1; i++) {

            unitper_add[i+1] = unitper_add[i] + unitper[i+1];
        }
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
