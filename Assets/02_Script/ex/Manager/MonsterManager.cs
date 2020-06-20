using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public static MonsterManager Instance { get; private set; }
    //public 

    public int Clear_Count;
    public GameObject regentr;
    int[] mons_list;
    public GameObject[] mons;


    private void Awake()
    {
        Instance = this;
    }


    public void Regen() {

        int mons_cont = 10 + (BarManager.Instance.date / 3);

        mons_list = new int[mons_cont];
        mons = new GameObject[mons_cont];

        for (int i = 0; i < mons_cont; i++)
        { 
            mons_list[i] = UnityEngine.Random.Range(0, 0);
            print(mons_list[i]);
        }
        Clear_Count = mons_cont;
        StartCoroutine(RegenStart(mons_cont));

   
    }


    public IEnumerator RegenStart(int mons_cont)
    {
        for (int i = 0; i < mons_cont; i++)
        {
            mons[i] = Instantiate(GetEnemyInfo.Instance.enemy[mons_list[i]], regentr.transform.position, Quaternion.Euler(new Vector3(0,-90,0))) ;
            mons[i].name = GetEnemyInfo.Instance.getEnemyName(mons_list[i]) + i;

            mons[i].GetComponent<Monster>().Currentlocation = regentr;

           yield return new WaitForSeconds(Random.Range(0.1f, 0.7f));
        }


    }


    public void Move(GameObject mon)
    {
         switch( mon.GetComponent<Monster>().Currentlocation.name)
        {
            case "regen":mon.GetComponent<Monster>().Targerlocation = TileManager.Instance.tiles[0].GetComponent<Tile>().tar_lo; break;
            case "TargetLocation_1" : break;

        }

    }

}
