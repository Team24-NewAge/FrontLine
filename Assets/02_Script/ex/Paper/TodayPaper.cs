using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class TodayPaper : PaperBase
{
    object tweenId = new object();

    public int curruntClick;
    bool plus = true;
    GameObject accpetion;
    public override void ClickPaper()
    {
        base.ClickPaper();

        print(curruntClick);
    }


    public void OnClick()
    {

        accpetion =Instantiate(PaperManager.Instance.accpet,this.transform.position, Quaternion.identity);
        accpetion.transform.position += new Vector3(0, 0, 0);
        accpetion.transform.parent = PanelManager.Instance._commandPanel.transform;
        accpetion.transform.localScale = new Vector3(1, 1, 1);
        accpetion.transform.rotation = this.transform.rotation;

        StartCoroutine(Accpet());
        //StartCoroutine(PaperManager.Instance.Fadein());
        print(this.tag);

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



    IEnumerator Accpet() {



        yield return new WaitForSeconds(1.0f);

        Destroy(accpetion);

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




}
