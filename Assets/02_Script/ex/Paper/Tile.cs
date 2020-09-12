using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject tar_lo;
    public GameObject[] Unit_po = new GameObject[3];
    public GameObject[] Unit = new GameObject[3];
    public GameObject[] Mons_po = new GameObject[3];
    public GameObject[] Mons = new GameObject[3];


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void UnitDie(int loc) {

        switch (loc)
        {
            case 1: Unit[0] = null;break;
            case 2: Unit[1] = null;break;
            case 3: Unit[2] = null;break;
        }    
    
    
    }
}
