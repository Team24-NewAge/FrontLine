using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TodayPaper : PaperBase
{
    public int curruntClick;

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

}
