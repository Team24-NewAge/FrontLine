using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSelectPanel : PanelBase
{

    public GameObject panel;
    public GameObject HeroSelectpanel;
    int stage = 0;


    public override void OnShow()
    {
    }



    public override void OnHide()
    {
    }


    public void SelectHero()//
    {
        stage = 1;
    }

    void Update()
    {

        //if (Application.platform == RuntimePlatform.Android)

        {

            if (Input.GetKeyDown(KeyCode.Escape))

            {


                switch(stage){
                    case 1: HeroSelectpanel.SetActive(false);
                        stage = 0;
                        break;
                    case 0: Destroy(panel);
                        break;

                }



               // Destroy(panel);


            }

        }



    }

}
