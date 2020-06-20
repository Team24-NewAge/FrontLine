using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TodayPaper : PaperBase
{
    public int curruntClick;
    bool plus = true;
    public override void ClickPaper()
    {
        base.ClickPaper();

        print(curruntClick);
    }


    public void OnClick()
    {
        print(curruntClick);
       
        PaperManager.Instance.Last_Click = curruntClick;
        BarManager.Instance.date++;
        PaperManager.Instance.today++;
        BarManager.Instance._SetDate();
 
        if (PaperManager.Instance.today == 30)
        {
            PaperManager.Instance.N_NewMonth();
        }

        PaperManager.Instance.PaperSetting();

    }


    public void sizeUD()
    {
        StartCoroutine(clickable());
    }

    IEnumerator clickable() {
        while (true){

            yield return null;
            if (plus == true)
            {
                for (float f = 0.9f; f < 1.1; f += 0.002f)
                {
                    this.transform.localScale = new Vector3(f, f, f);

                    if (f >= 1.09f)
                    {
                        plus = false;
                        break;
                    }
                    yield return null;
                }
            } else
            {
                for (float f = 1.1f; f > 0.9; f -= 0.002f)
                {
                    this.transform.localScale = new Vector3(f, f, f);
                    if (f <= 0.91f)
                    {
                        plus = true;
                        break;
                    }
                    yield return null;
                }

            }
            yield return null;
        }




    }





}
