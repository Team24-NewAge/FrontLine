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
    public int go; // 앞으로 갈 확률
    public int back;// 뒤로 갈 확률


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
            mons[i].GetComponent<Monster>().Targettile = TileManager.Instance.tiles[0];

          yield return new WaitForSeconds(Random.Range(0.1f, 0.7f));
        }


    }


    public void Move(GameObject mon)
    {
         switch( mon.GetComponent<Monster>().Currentlocation.name)
        {
            case "regen":mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[0].GetComponent<Tile>().tar_lo;
              
                StartCoroutine(mon.GetComponent<Monster>().GotoTarget());
                
                
                
                break;
            case "TargetLocation_0" : /////////////////0번타일
                if (Random.Range(1, 100) >= back)//앞으로 감
                {
                    switch (Random.Range(0, 3)){
                        case 0:
                            {
                                mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[1].GetComponent<Tile>().tar_lo;
                                mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[1];
                               StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

                                break;
                            }
                        case 1:
                            {
                                mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[2].GetComponent<Tile>().tar_lo;
                                mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[2];
                                StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

                                break;
                            }
                        case 2:
                            {
                                mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[3].GetComponent<Tile>().tar_lo;
                                mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[3];
                                StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

                                break;
                            }
                    }

                }//뒤로감
                else {
                    switch (Random.Range(0, 3))
                    {
                        case 0:
                            {
                                mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[1].GetComponent<Tile>().tar_lo;
                                mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[1];
                                StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

                                break;
                            }
                        case 1:
                            {
                                mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[2].GetComponent<Tile>().tar_lo;
                                mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[2];
                                StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

                                break;
                            }
                        case 2:
                            {
                                mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[3].GetComponent<Tile>().tar_lo;
                                mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[3];
                                StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

                                break;
                            }
                    }

                }
                break;

            case "TargetLocation_1"://///////////////1번타일
                if (Random.Range(1, 100) >= back)//앞으로 감
                {
                    switch (Random.Range(0, 2))
                    {
                        case 0:
                            {
                                mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[2].GetComponent<Tile>().tar_lo;
                                mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[2];
                                StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

                                break;
                            }
                        case 1:
                            {
                                mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[4].GetComponent<Tile>().tar_lo;
                                mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[4];
                                StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

                                break;
                            }
                    }

                }//뒤로감
                else
                {
                                mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[0].GetComponent<Tile>().tar_lo;
                                mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[0];
                    StartCoroutine(mon.GetComponent<Monster>().GotoTarget());


                }
                break;

            case "TargetLocation_2"://///////////////2번타일
                if (Random.Range(1, 100) >= back)//앞으로 감
                {
                    switch (Random.Range(0, 3))
                    {
                        case 0:
                            {
                                mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[4].GetComponent<Tile>().tar_lo;
                                mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[4];
                                StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

                                break;
                            }
                        case 1:
                            {
                                mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[5].GetComponent<Tile>().tar_lo;
                                mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[5];
                                StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

                                break;
                            }
                        case 2:
                            {
                                mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[6].GetComponent<Tile>().tar_lo;
                                mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[6];
                                StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

                                break;
                            }
                    }

                }//뒤로감
                else
                {
                    switch (Random.Range(0, 3))
                    {
                        case 0:
                            {
                                mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[0].GetComponent<Tile>().tar_lo;
                                mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[0];
                                StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

                                break;
                            }
                        case 1:
                            {
                                mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[1].GetComponent<Tile>().tar_lo;
                                mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[1];
                                StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

                                break;
                            }
                        case 2:
                            {
                                mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[3].GetComponent<Tile>().tar_lo;
                                mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[3];
                                StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

                                break;
                            }
                    }

                }
                break;

            case "TargetLocation_3"://///////////////3번타일
                if (Random.Range(1, 100) >= back)//앞으로 감
                {
                    switch (Random.Range(0, 2))
                    {
                        case 0:
                            {
                                mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[2].GetComponent<Tile>().tar_lo;
                                mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[2];
                                StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

                                break;
                            }
                        case 1:
                            {
                                mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[6].GetComponent<Tile>().tar_lo;
                                mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[6];
                                StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

                                break;
                            }

                    }

                }//뒤로감
                else
                {

                                mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[0].GetComponent<Tile>().tar_lo;
                    mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[0];
                    StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

            

                }
                break;


            case "TargetLocation_4"://///////////////4번타일
                if (Random.Range(1, 100) >= back)//앞으로 감
                {
                    switch (Random.Range(0, 2))
                    {
                        case 0:
                            {
                                mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[5].GetComponent<Tile>().tar_lo;
                                mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[5];
                                StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

                                break;
                            }
                        case 1:
                            {
                                mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[7].GetComponent<Tile>().tar_lo;
                                mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[7];
                                StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

                                break;
                            }
                    }

                }//뒤로감
                else
                {
                    switch (Random.Range(0, 2))
                    {
                        case 0:
                            {
                                mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[1].GetComponent<Tile>().tar_lo;
                                mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[1];
                                StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

                                break;
                            }
                        case 1:
                            {
                                mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[2].GetComponent<Tile>().tar_lo;
                                mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[2];
                                StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

                                break;
                            }

                    }

                }
                break;


            case "TargetLocation_5"://///////////////5번타일
                if (Random.Range(1, 100) >= back)//앞으로 감
                {
                    switch (Random.Range(0, 3))
                    {
                        case 0:
                            {
                                mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[7].GetComponent<Tile>().tar_lo;
                                mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[7];
                                StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

                                break;
                            }
                        case 1:
                            {
                                mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[8].GetComponent<Tile>().tar_lo;
                                mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[8];
                                StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

                                break;
                            }
                        case 2:
                            {
                                mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[9].GetComponent<Tile>().tar_lo;
                                mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[9];
                                StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

                                break;
                            }
                    }

                }//뒤로감
                else
                {
                    switch (Random.Range(0, 3))
                    {
                        case 0:
                            {
                                mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[2].GetComponent<Tile>().tar_lo;
                                mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[2];
                                StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

                                break;
                            }
                        case 1:
                            {
                                mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[4].GetComponent<Tile>().tar_lo;
                                mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[4];
                                StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

                                break;
                            }
                        case 2:
                            {
                                mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[6].GetComponent<Tile>().tar_lo;
                                mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[6];
                                StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

                                break;
                            }
                    }

                }
                break;

            case "TargetLocation_6"://///////////////6번타일
                if (Random.Range(1, 100) >= back)//앞으로 감
                {
                    switch (Random.Range(0, 2))
                    {
                        case 0:
                            {
                                mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[5].GetComponent<Tile>().tar_lo;
                                mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[5];
                                StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

                                break;
                            }
                        case 1:
                            {
                                mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[9].GetComponent<Tile>().tar_lo;
                                mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[9];
                                StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

                                break;
                            }
                    }

                }//뒤로감
                else
                {
                    switch (Random.Range(0, 2))
                    {
                        case 0:
                            {
                                mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[2].GetComponent<Tile>().tar_lo;
                                mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[2];
                                StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

                                break;
                            }
                        case 1:
                            {
                                mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[3].GetComponent<Tile>().tar_lo;
                                mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[3];
                                StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

                                break;
                            }

                    }

                }
                break;

            case "TargetLocation_7"://///////////////7번타일
                if (Random.Range(1, 100) >= back)//앞으로 감
                {
                    mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[8].GetComponent<Tile>().tar_lo;
                    mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[8];
                    StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

                }//뒤로감
                else
                {
                    

                    switch (Random.Range(0, 2))
                    {
                        case 0:
                            {
                                mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[4].GetComponent<Tile>().tar_lo;
                                mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[4];
                                StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

                                break;
                            }
                        case 1:
                            {
                                mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[5].GetComponent<Tile>().tar_lo;
                                mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[5];
                                StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

                                break;
                            }
                    }
                }
                break;

            case "TargetLocation_8": /////////////////8번타일
                if (Random.Range(1, 100) >= back)//앞으로 감
                {
                    mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[10].GetComponent<Tile>().tar_lo;
                    mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[10];
                    StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

                }//뒤로감
                else
                {
                    switch (Random.Range(0, 3))
                    {
                        case 0:
                            {
                                mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[5].GetComponent<Tile>().tar_lo;
                                mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[5];
                                StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

                                break;
                            }
                        case 1:
                            {
                                mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[7].GetComponent<Tile>().tar_lo;
                                mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[7];
                                StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

                                break;
                            }
                        case 2:
                            {
                                mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[9].GetComponent<Tile>().tar_lo;
                                mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[9];
                                StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

                                break;
                            }
                    }

                }
                break;


            case "TargetLocation_9"://///////////////9번타일
                if (Random.Range(1, 100) >= back)//앞으로 감
                {
                    mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[8].GetComponent<Tile>().tar_lo;
                    mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[8];
                    StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

                }//뒤로감
                else
                {


                    switch (Random.Range(0, 2))
                    {
                        case 0:
                            {
                                mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[5].GetComponent<Tile>().tar_lo;
                                mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[5];
                                StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

                                break;
                            }
                        case 1:
                            {
                                mon.GetComponent<Monster>().Targetlocation = TileManager.Instance.tiles[6].GetComponent<Tile>().tar_lo;
                                mon.GetComponent<Monster>().Targettile = TileManager.Instance.tiles[6];
                                StartCoroutine(mon.GetComponent<Monster>().GotoTarget());

                                break;
                            }
                    }
                }
                break;
        }

    }


    public void InTile(GameObject mon)
    {
        Tile Current_tile = mon.GetComponent<Monster>().CurrentTile;
        if (Current_tile.GetComponent<Tile>().Mons[0] == null && isUnit(Current_tile))
        {
            Current_tile.GetComponent<Tile>().Mons[0] = mon;
            mon.transform.position = Current_tile.Mons_po[0].transform.position;
            mon.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
            mon.GetComponent<Monster>().animator.SetBool("isIdle", true);
            StartCoroutine(mon.GetComponent<Monster>().Battle_Monster());

        }
        else if (Current_tile.GetComponent<Tile>().Mons[1] == null && isUnit(Current_tile))
        {
            Current_tile.GetComponent<Tile>().Mons[1] = mon;
            mon.transform.position = Current_tile.Mons_po[1].transform.position;
            mon.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
            mon.GetComponent<Monster>().animator.SetBool("isIdle", true);
            StartCoroutine(mon.GetComponent<Monster>().Battle_Monster());
        }
        else if (Current_tile.GetComponent<Tile>().Mons[2] == null && isUnit(Current_tile))
        {
            Current_tile.GetComponent<Tile>().Mons[2] = mon;
            mon.transform.position = Current_tile.Mons_po[2].transform.position;
            mon.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
            mon.GetComponent<Monster>().animator.SetBool("isIdle", true);
            StartCoroutine(mon.GetComponent<Monster>().Battle_Monster());
        }
        else {
            Move(mon);
        }


    }



    public bool isUnit(Tile Tile)//유닛이 하나도 없으면 false  하나라도 있으면 트루 
    {
        if (Tile.GetComponent<Tile>().Unit[0] != null || Tile.GetComponent<Tile>().Unit[1] != null || Tile.GetComponent<Tile>().Unit[2] != null)
        {
            return true;
        }
        else
        { 
            return false;
        }

    }

}
