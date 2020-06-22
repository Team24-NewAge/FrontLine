using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static UnitManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isMons(Tile Tile)//몬스터가 하나도 없으면 false  하나라도 있으면 트루 
    {
        if (Tile.GetComponent<Tile>().Mons[0] != null || Tile.GetComponent<Tile>().Mons[1] != null || Tile.GetComponent<Tile>().Mons[2] != null)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

}
