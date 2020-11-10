using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Checkpaper_Popup : PopupBase
{
    int[,] MonthPapers = new int[30, 11];
    public GameObject Content;
    public GameObject image;
    public ScrollRect scroll;
    // Start is called before the first frame update
    void Start()
    {
        int today = PaperManager.Instance.today;
        int lastclick = PaperManager.Instance.Last_Click;
     MonthPapers = PaperManager.Instance.MonthPapers;
        for (int day = 29; day >= 0; day--)//세로 30개
        {
            for (int id = 10; id >= 0; id--)//가로 11개
            {
                GameObject paper = Instantiate(image);
                paper.transform.SetParent(Content.transform);
                paper.transform.localScale = Vector3.one;
                paper.GetComponent<RectTransform>().anchoredPosition = new Vector3(-500+(100*(id)), 1310-(100*(29-day)), 0);
  

                int code = MonthPapers[day, id];
             

                switch (code)
                {
                    case 0: paper.GetComponent<Image>().color = Color.red;
                        paper.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Boss";
                        break;
                    case 1:
                        paper.GetComponent<Image>().color = Color.yellow;
                        paper.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Elite";
                        break;
                    case 2:
                        paper.GetComponent<Image>().color = Color.yellow;
                        paper.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Elite";
                        break;
                    case 3:
                        paper.GetComponent<Image>().color = Color.magenta;
                        paper.transform.GetChild(0).gameObject.GetComponent<Text>().text = "R/R";
                        break;
                    case 4:
                        paper.GetComponent<Image>().color = Color.green;
                        paper.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Shop";
                        break;
                    case 5:
                        paper.GetComponent<Image>().color = Color.magenta;
                        paper.transform.GetChild(0).gameObject.GetComponent<Text>().text = "R/R";
                        break;
                    case 6:
                        paper.GetComponent<Image>().color = Color.blue;
                        paper.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Event";
                        break;
                    case 7:
                        paper.GetComponent<Image>().color = Color.white;
                        paper.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Battle";
                        break;

                }
                if (day == today + 2 && !(id == lastclick || id == lastclick + 1 || id == lastclick + 2 || id == lastclick + 3 || id == lastclick - 1 || id == lastclick - 2 || id == lastclick - 3))
                {
                    paper.GetComponent<Image>().color = new Color(paper.GetComponent<Image>().color.r, paper.GetComponent<Image>().color.g, paper.GetComponent<Image>().color.b, 0.5f);
                    paper.transform.GetChild(0).GetComponent<Text>().color = new Color(paper.GetComponent<Image>().color.r, paper.GetComponent<Image>().color.g, paper.GetComponent<Image>().color.b, 0.5f);
                } else if (day == today + 2 && (id == lastclick || id == lastclick + 1 || id == lastclick + 2 || id == lastclick + 3 || id == lastclick - 1 || id == lastclick - 2 || id == lastclick - 3))
                {
                    paper.GetComponent<Outline>().effectColor = Color.red;
                    paper.GetComponent<Outline>().effectDistance = new Vector2(5, -5);
                }

                if (day == today+1 && !(id == lastclick || id == lastclick + 1 || id == lastclick + 2 || id == lastclick - 1 || id == lastclick - 2))
                {
                    paper.GetComponent<Image>().color = new Color(paper.GetComponent<Image>().color.r, paper.GetComponent<Image>().color.g, paper.GetComponent<Image>().color.b, 0.5f);
                    paper.transform.GetChild(0).GetComponent<Text>().color = new Color(paper.GetComponent<Image>().color.r, paper.GetComponent<Image>().color.g, paper.GetComponent<Image>().color.b, 0.5f);
                } else if (day == today + 1 && (id == lastclick || id == lastclick + 1 || id == lastclick + 2 || id == lastclick - 1 || id == lastclick - 2))
                {
                    paper.GetComponent<Outline>().effectColor = Color.red;
                    paper.GetComponent<Outline>().effectDistance = new Vector2(5, -5);
                }

                if (day == today &&!(id == lastclick|| id == lastclick+1 || id == lastclick-1))
                {
                    paper.GetComponent<Image>().color = new Color(paper.GetComponent<Image>().color.r, paper.GetComponent<Image>().color.g, paper.GetComponent<Image>().color.b, 0.5f);
                    paper.transform.GetChild(0).GetComponent<Text>().color = new Color(paper.GetComponent<Image>().color.r, paper.GetComponent<Image>().color.g, paper.GetComponent<Image>().color.b, 0.5f);
                } else if (day == today && (id == lastclick || id == lastclick + 1 || id == lastclick - 1))
                {
                    paper.GetComponent<Outline>().effectColor = Color.red;
                    paper.GetComponent<Outline>().effectDistance = new Vector2(5, -5);
                }

                if (day < today)
                {
                    paper.GetComponent<Image>().color = new Color(paper.GetComponent<Image>().color.r, paper.GetComponent<Image>().color.g, paper.GetComponent<Image>().color.b, 0.5f);
                    paper.transform.GetChild(0).GetComponent<Text>().color = new Color(paper.GetComponent<Image>().color.r, paper.GetComponent<Image>().color.g, paper.GetComponent<Image>().color.b, 0.5f);
                }

            }
        }
        float scroll_ver =0 + (today/30f);
        scroll.normalizedPosition = new Vector3(0, scroll_ver);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void HidePopup()
    {
        base.HidePopup();
    }
}
