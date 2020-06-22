using DG.Tweening;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PaperManager : MonoBehaviour
{
    int[,] MonthPapers = new int[30, 11];
    int[] ClickPaper = new int[30];
    public int today = 0;
    public int Last_Click;



    public Image fade;
    float fadetime = 1;
    public Color Now;
    Color oriC;



    public GameObject accpet;
    public GameObject[] EmptyPapers = new GameObject[15];
    public GameObject[] TodayPaper = new GameObject[3];
    GameObject[] TomorrowPaper = new GameObject[5];
    GameObject[] TTomorrowPaper = new GameObject[7];

    public GameObject[] Papers = new GameObject[8];
    



    public static PaperManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;


        N_NewMonth();
        PaperSetting();
    }

    void Start()
    {

    }


    void Update()
    {

    }

    public void N_NewMonth() { 
    
        for(int day=0; day < 30; day++)
        {
            for(int id = 0; id < 11; id++)
            {
                if (day == 29)
                { MonthPapers[day, id] = 0 ;print(MonthPapers[day, id]); }
                else if (day == 28)
                { MonthPapers[day, id] = 5; print(MonthPapers[day, id]); }
                else
                { 
                    MonthPapers[day, id] = UnityEngine.Random.Range(1, 30);
                    if (MonthPapers[day, id] > 7) 
                    { MonthPapers[day, id] = 7; }
                    //print("[" + day + "," + id + "]" + "="+MonthPapers[day, id]); 
                }
            }
            ClickPaper[day] = -1;
        }
        today = 0;
    }

    public void NextDay(int click) { }
    public void PaperSetting() {




        for (int i = 0; i < 3; i++)
        {
            Destroy(TodayPaper[i]);
        }
        for (int i = 0; i < 5; i++)
        {
            Destroy(TomorrowPaper[i]);
        }
        for (int i = 0; i < 7; i++)
        {
            Destroy(TTomorrowPaper[i]);
        }


        switch (Last_Click)
        {
           case 0 : Last0();break;
           case 1 : Last1();break;
           case 2:  Last2();break;
           case 3: Last3_7(); break;
           case 4: Last3_7(); break;
           case 5: Last3_7(); break;
           case 6: Last3_7(); break;
           case 7: Last3_7(); break;
           case 8: Last8(); break;
           case 9: Last9(); break;
           case 10: Last10(); break;
        }

        //TodayPaper[0].GetComponent<TodayPaper>().sizeUD();
        //TodayPaper[1].GetComponent<TodayPaper>().sizeUD();
       // TodayPaper[2].GetComponent<TodayPaper>().sizeUD();
    }

    /// <summary>
    /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    private void Last0()
    {


        for (int i = 1; i < 3; i++)
        {

            TodayPaper[i] = Instantiate(Papers[MonthPapers[today, (Last_Click - 1 + i)]], EmptyPapers[i].transform.position, Quaternion.identity);
            TodayPaper[i].transform.parent = EmptyPapers[i].transform;
            TodayPaper[i].transform.localScale = new Vector3(1, 1, 1);
            TodayPaper[i].transform.rotation = EmptyPapers[1].transform.rotation;
            switch (i)
            {
                case 0: TodayPaper[i].GetComponent<TodayPaper>().curruntClick = Last_Click - 1; break;
                case 1: TodayPaper[i].GetComponent<TodayPaper>().curruntClick = Last_Click; break;
                case 2: TodayPaper[i].GetComponent<TodayPaper>().curruntClick = Last_Click + 1; break;
            }
            TodayPaper[i].GetComponent<TodayPaper>().sizeUD();
        }
        for (int i = 2; i < 5; i++)
        {

            int tp = i + 3;
            TomorrowPaper[i] = Instantiate(Papers[MonthPapers[today + 1, (Last_Click - 2 + i)]], EmptyPapers[tp].transform.position, Quaternion.identity);
            TomorrowPaper[i].transform.parent = EmptyPapers[tp].transform;
            TomorrowPaper[i].transform.localScale = new Vector3(1, 1, 1);
            TomorrowPaper[i].transform.rotation = EmptyPapers[1].transform.rotation;
            TomorrowPaper[i].GetComponent<EventTrigger>().enabled = false;
            TomorrowPaper[i].GetComponent<Image>().color = TomorrowPaper[i].GetComponent<Image>().color - new Color(0.3f, 0.3f, 0.3f, 0);
        }
        for (int i = 3; i < 7; i++)
        {
            int ttp = i + 8;
            TTomorrowPaper[i] = Instantiate(Papers[MonthPapers[today + 2, (Last_Click - 3 + i)]], EmptyPapers[ttp].transform.position, Quaternion.identity);
            TTomorrowPaper[i].transform.parent = EmptyPapers[ttp].transform;
            TTomorrowPaper[i].transform.localScale = new Vector3(1, 1, 1);
            TTomorrowPaper[i].transform.rotation = EmptyPapers[1].transform.rotation;
            TTomorrowPaper[i].GetComponent<EventTrigger>().enabled = false;
            TTomorrowPaper[i].GetComponent<Image>().color = TTomorrowPaper[i].GetComponent<Image>().color - new Color(0.3f, 0.3f, 0.3f, 0);
        }
    }

    private void Last1()
    {
        for (int i = 0; i < 3; i++)
        {

            TodayPaper[i] = Instantiate(Papers[MonthPapers[today, (Last_Click - 1 + i)]], EmptyPapers[i].transform.position, Quaternion.identity);
            TodayPaper[i].transform.parent = EmptyPapers[i].transform;
            TodayPaper[i].transform.localScale = new Vector3(1, 1, 1);
            TodayPaper[i].transform.rotation = EmptyPapers[1].transform.rotation;
            switch (i)
            {
                case 0: TodayPaper[i].GetComponent<TodayPaper>().curruntClick = Last_Click - 1; break;
                case 1: TodayPaper[i].GetComponent<TodayPaper>().curruntClick = Last_Click; break;
                case 2: TodayPaper[i].GetComponent<TodayPaper>().curruntClick = Last_Click + 1; break;
            }
            TodayPaper[i].GetComponent<TodayPaper>().sizeUD();
        }
        for (int i = 1; i < 5; i++)
        {

            int tp = i + 3;
            TomorrowPaper[i] = Instantiate(Papers[MonthPapers[today + 1, (Last_Click - 2 + i)]], EmptyPapers[tp].transform.position, Quaternion.identity);
            TomorrowPaper[i].transform.parent = EmptyPapers[tp].transform;
            TomorrowPaper[i].transform.localScale = new Vector3(1, 1, 1);
            TomorrowPaper[i].transform.rotation = EmptyPapers[1].transform.rotation;
            TomorrowPaper[i].GetComponent<EventTrigger>().enabled = false;
            TomorrowPaper[i].GetComponent<Image>().color = TomorrowPaper[i].GetComponent<Image>().color - new Color(0.3f, 0.3f, 0.3f, 0);
        }
        for (int i = 2; i < 7; i++)
        {
            int ttp = i + 8;
            TTomorrowPaper[i] = Instantiate(Papers[MonthPapers[today + 2, (Last_Click - 3 + i)]], EmptyPapers[ttp].transform.position, Quaternion.identity);
            TTomorrowPaper[i].transform.parent = EmptyPapers[ttp].transform;
            TTomorrowPaper[i].transform.localScale = new Vector3(1, 1, 1);
            TTomorrowPaper[i].transform.rotation = EmptyPapers[1].transform.rotation;
            TTomorrowPaper[i].GetComponent<EventTrigger>().enabled = false;
            TTomorrowPaper[i].GetComponent<Image>().color = TTomorrowPaper[i].GetComponent<Image>().color - new Color(0.3f, 0.3f, 0.3f, 0);
        }
    }

    private void Last2()
    {
        for (int i = 0; i < 3; i++)
        {

            TodayPaper[i] = Instantiate(Papers[MonthPapers[today, (Last_Click - 1 + i)]], EmptyPapers[i].transform.position, Quaternion.identity);
            TodayPaper[i].transform.parent = EmptyPapers[i].transform;
            TodayPaper[i].transform.localScale = new Vector3(1, 1, 1);
            TodayPaper[i].transform.rotation = EmptyPapers[1].transform.rotation;
            switch (i)
            {
                case 0: TodayPaper[i].GetComponent<TodayPaper>().curruntClick = Last_Click - 1; break;
                case 1: TodayPaper[i].GetComponent<TodayPaper>().curruntClick = Last_Click; break;
                case 2: TodayPaper[i].GetComponent<TodayPaper>().curruntClick = Last_Click + 1; break;
            }
            TodayPaper[i].GetComponent<TodayPaper>().sizeUD();

        }
        for (int i = 0; i < 5; i++)
        {

            int tp = i + 3;
            TomorrowPaper[i] = Instantiate(Papers[MonthPapers[today + 1, (Last_Click - 2 + i)]], EmptyPapers[tp].transform.position, Quaternion.identity);
            TomorrowPaper[i].transform.parent = EmptyPapers[tp].transform;
            TomorrowPaper[i].transform.localScale = new Vector3(1, 1, 1);
            TomorrowPaper[i].transform.rotation = EmptyPapers[1].transform.rotation;
            TomorrowPaper[i].GetComponent<EventTrigger>().enabled = false;
            TomorrowPaper[i].GetComponent<Image>().color = TomorrowPaper[i].GetComponent<Image>().color - new Color(0.3f, 0.3f, 0.3f, 0);

        }
        for (int i = 1; i < 7; i++)
        {
            int ttp = i + 8;
            TTomorrowPaper[i] = Instantiate(Papers[MonthPapers[today + 2, (Last_Click - 3 + i)]], EmptyPapers[ttp].transform.position, Quaternion.identity);
            TTomorrowPaper[i].transform.parent = EmptyPapers[ttp].transform;
            TTomorrowPaper[i].transform.localScale = new Vector3(1, 1, 1);
            TTomorrowPaper[i].transform.rotation = EmptyPapers[1].transform.rotation;
            TTomorrowPaper[i].GetComponent<EventTrigger>().enabled = false;
            TTomorrowPaper[i].GetComponent<Image>().color = TTomorrowPaper[i].GetComponent<Image>().color - new Color(0.3f, 0.3f, 0.3f, 0);
        }
    }

    private void Last3_7()
    {

        for (int i = 0; i < 3; i++)
        {

            TodayPaper[i] = Instantiate(Papers[MonthPapers[today, (Last_Click - 1 + i)]], EmptyPapers[i].transform.position, Quaternion.identity);
            TodayPaper[i].transform.parent = EmptyPapers[i].transform;
            TodayPaper[i].transform.localScale = new Vector3(1, 1, 1);
            TodayPaper[i].transform.rotation = EmptyPapers[1].transform.rotation;
            switch (i) {
                case 0: TodayPaper[i].GetComponent<TodayPaper>().curruntClick = Last_Click-1;break;
                case 1: TodayPaper[i].GetComponent<TodayPaper>().curruntClick = Last_Click; break;
                case 2: TodayPaper[i].GetComponent<TodayPaper>().curruntClick = Last_Click+1; break;
            }
            TodayPaper[i].GetComponent<TodayPaper>().sizeUD();
        }
        for (int i = 0; i < 5; i++)
        {

            int tp = i + 3;
            TomorrowPaper[i] = Instantiate(Papers[MonthPapers[today + 1, (Last_Click - 2 + i)]], EmptyPapers[tp].transform.position, Quaternion.identity);
            TomorrowPaper[i].transform.parent = EmptyPapers[tp].transform;
            TomorrowPaper[i].transform.localScale = new Vector3(1, 1, 1);
            TomorrowPaper[i].transform.rotation = EmptyPapers[1].transform.rotation;
            TomorrowPaper[i].GetComponent<EventTrigger>().enabled = false;
            TomorrowPaper[i].GetComponent<Image>().color = TomorrowPaper[i].GetComponent<Image>().color - new Color(0.3f, 0.3f, 0.3f, 0);

        }
        for (int i = 0; i < 7; i++)
        {
            int ttp = i + 8;
            TTomorrowPaper[i] = Instantiate(Papers[MonthPapers[today + 2, (Last_Click - 3 + i)]], EmptyPapers[ttp].transform.position, Quaternion.identity);
            TTomorrowPaper[i].transform.parent = EmptyPapers[ttp].transform;
            TTomorrowPaper[i].transform.localScale = new Vector3(1, 1, 1);
            TTomorrowPaper[i].transform.rotation = EmptyPapers[1].transform.rotation;
            TTomorrowPaper[i].GetComponent<EventTrigger>().enabled = false;
            TTomorrowPaper[i].GetComponent<Image>().color =TTomorrowPaper[i].GetComponent<Image>().color - new Color(0.3f, 0.3f, 0.3f, 0);
        }

    }

    private void Last8()
    {

        for (int i = 0; i < 3; i++)
        {

            TodayPaper[i] = Instantiate(Papers[MonthPapers[today, (Last_Click - 1 + i)]], EmptyPapers[i].transform.position, Quaternion.identity);
            TodayPaper[i].transform.parent = EmptyPapers[i].transform;
            TodayPaper[i].transform.localScale = new Vector3(1, 1, 1);
            TodayPaper[i].transform.rotation = EmptyPapers[1].transform.rotation;
            switch (i)
            {
                case 0: TodayPaper[i].GetComponent<TodayPaper>().curruntClick = Last_Click - 1; break;
                case 1: TodayPaper[i].GetComponent<TodayPaper>().curruntClick = Last_Click; break;
                case 2: TodayPaper[i].GetComponent<TodayPaper>().curruntClick = Last_Click + 1; break;
            }
            TodayPaper[i].GetComponent<TodayPaper>().sizeUD();
        }
        for (int i = 0; i < 5; i++)
        {

            int tp = i + 3;
            TomorrowPaper[i] = Instantiate(Papers[MonthPapers[today + 1, (Last_Click - 2 + i)]], EmptyPapers[tp].transform.position, Quaternion.identity);
            TomorrowPaper[i].transform.parent = EmptyPapers[tp].transform;
            TomorrowPaper[i].transform.localScale = new Vector3(1, 1, 1);
            TomorrowPaper[i].transform.rotation = EmptyPapers[1].transform.rotation;
            TomorrowPaper[i].GetComponent<EventTrigger>().enabled = false;
            TomorrowPaper[i].GetComponent<Image>().color = TomorrowPaper[i].GetComponent<Image>().color - new Color(0.3f, 0.3f, 0.3f, 0);

        }
        for (int i = 0; i < 6; i++)
        {
            int ttp = i + 8;
            TTomorrowPaper[i] = Instantiate(Papers[MonthPapers[today + 2, (Last_Click - 3 + i)]], EmptyPapers[ttp].transform.position, Quaternion.identity);
            TTomorrowPaper[i].transform.parent = EmptyPapers[ttp].transform;
            TTomorrowPaper[i].transform.localScale = new Vector3(1, 1, 1);
            TTomorrowPaper[i].transform.rotation = EmptyPapers[1].transform.rotation;
            TTomorrowPaper[i].GetComponent<EventTrigger>().enabled = false;
            TTomorrowPaper[i].GetComponent<Image>().color = TTomorrowPaper[i].GetComponent<Image>().color - new Color(0.3f, 0.3f, 0.3f, 0);
        }

    }

    private void Last9()
    {

        for (int i = 0; i < 3; i++)
        {

            TodayPaper[i] = Instantiate(Papers[MonthPapers[today, (Last_Click - 1 + i)]], EmptyPapers[i].transform.position, Quaternion.identity);
            TodayPaper[i].transform.parent = EmptyPapers[i].transform;
            TodayPaper[i].transform.localScale = new Vector3(1, 1, 1);
            TodayPaper[i].transform.rotation = EmptyPapers[1].transform.rotation;
            switch (i)
            {
                case 0: TodayPaper[i].GetComponent<TodayPaper>().curruntClick = Last_Click - 1; break;
                case 1: TodayPaper[i].GetComponent<TodayPaper>().curruntClick = Last_Click; break;
                case 2: TodayPaper[i].GetComponent<TodayPaper>().curruntClick = Last_Click + 1; break;
            }
            TodayPaper[i].GetComponent<TodayPaper>().sizeUD();
        }
        for (int i = 0; i < 4; i++)
        {

            int tp = i + 3;
            TomorrowPaper[i] = Instantiate(Papers[MonthPapers[today + 1, (Last_Click - 2 + i)]], EmptyPapers[tp].transform.position, Quaternion.identity);
            TomorrowPaper[i].transform.parent = EmptyPapers[tp].transform;
            TomorrowPaper[i].transform.localScale = new Vector3(1, 1, 1);
            TomorrowPaper[i].transform.rotation = EmptyPapers[1].transform.rotation;
            TomorrowPaper[i].GetComponent<EventTrigger>().enabled = false;
            TomorrowPaper[i].GetComponent<Image>().color = TomorrowPaper[i].GetComponent<Image>().color - new Color(0.3f, 0.3f, 0.3f, 0);

        }
        for (int i = 0; i < 5; i++)
        {
            int ttp = i + 8;
            TTomorrowPaper[i] = Instantiate(Papers[MonthPapers[today + 2, (Last_Click - 3 + i)]], EmptyPapers[ttp].transform.position, Quaternion.identity);
            TTomorrowPaper[i].transform.parent = EmptyPapers[ttp].transform;
            TTomorrowPaper[i].transform.localScale = new Vector3(1, 1, 1);
            TTomorrowPaper[i].transform.rotation = EmptyPapers[1].transform.rotation;
            TTomorrowPaper[i].GetComponent<EventTrigger>().enabled = false;
            TTomorrowPaper[i].GetComponent<Image>().color = TTomorrowPaper[i].GetComponent<Image>().color - new Color(0.3f, 0.3f, 0.3f, 0);
        }

    }

    private void Last10()
    {

        for (int i = 0; i < 2; i++)
        {

            TodayPaper[i] = Instantiate(Papers[MonthPapers[today, (Last_Click - 1 + i)]], EmptyPapers[i].transform.position, Quaternion.identity);
            TodayPaper[i].transform.parent = EmptyPapers[i].transform;
            TodayPaper[i].transform.localScale = new Vector3(1, 1, 1);
            TodayPaper[i].transform.rotation = EmptyPapers[1].transform.rotation;
            switch (i)
            {
                case 0: TodayPaper[i].GetComponent<TodayPaper>().curruntClick = Last_Click - 1; break;
                case 1: TodayPaper[i].GetComponent<TodayPaper>().curruntClick = Last_Click; break;
                case 2: TodayPaper[i].GetComponent<TodayPaper>().curruntClick = Last_Click + 1; break;
            }
            TodayPaper[i].GetComponent<TodayPaper>().sizeUD();
        }
        for (int i = 0; i < 3; i++)
        {

            int tp = i + 3;
            TomorrowPaper[i] = Instantiate(Papers[MonthPapers[today + 1, (Last_Click - 2 + i)]], EmptyPapers[tp].transform.position, Quaternion.identity);
            TomorrowPaper[i].transform.parent = EmptyPapers[tp].transform;
            TomorrowPaper[i].transform.localScale = new Vector3(1, 1, 1);
            TomorrowPaper[i].transform.rotation = EmptyPapers[1].transform.rotation;
            TomorrowPaper[i].GetComponent<EventTrigger>().enabled = false;
            TomorrowPaper[i].GetComponent<Image>().color = TomorrowPaper[i].GetComponent<Image>().color - new Color(0.3f, 0.3f, 0.3f, 0);

        }
        for (int i = 0; i < 4; i++)
        {
            int ttp = i + 8;
            TTomorrowPaper[i] = Instantiate(Papers[MonthPapers[today + 2, (Last_Click - 3 + i)]], EmptyPapers[ttp].transform.position, Quaternion.identity);
            TTomorrowPaper[i].transform.parent = EmptyPapers[ttp].transform;
            TTomorrowPaper[i].transform.localScale = new Vector3(1, 1, 1);
            TTomorrowPaper[i].transform.rotation = EmptyPapers[1].transform.rotation;
            TTomorrowPaper[i].GetComponent<EventTrigger>().enabled = false;
            TTomorrowPaper[i].GetComponent<Image>().color = TTomorrowPaper[i].GetComponent<Image>().color - new Color(0.3f, 0.3f, 0.3f, 0);
        }

    }

    /// <summary>
    /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    /// 

    public IEnumerator Fadein_Next(String tag)
    {

        float curT = 0; //현재시간 초기화
        fade.gameObject.SetActive(true); //오브젝트 활성화
        while (curT < fadetime)
        {
            curT += Time.deltaTime*3; //현재시간 ++
            fade.color = Color.Lerp(oriC, Now, curT); //현재시간 값 만큼 러프

            yield return null;

        }

        switch (tag)
        {
            case "BattlePaper":
                {


                    BattleManager.Instance.DoBattle(); CameraManager.Instance.DoBattle(); break;
                }



        }

        yield return null;

        if (curT > 1)
        {
            yield return new WaitForSeconds(0.2F);
            fade.color = new Color(0, 0, 0, 0);
            fade.gameObject.SetActive(false);
            //CameraManager.Instance.DoBattle();
        }
        yield return null;
    }

    public void Paper_action() {

       
    
    
    }

}
