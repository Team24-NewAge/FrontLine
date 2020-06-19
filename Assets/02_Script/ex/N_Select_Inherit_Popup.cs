using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class N_Select_Inherit_Popup : PopupBase
{
    [SerializeField] private Button _reversebtn;
    void Update()
    {

        //if (Application.platform == RuntimePlatform.Android)

        {

            if (Input.GetKeyDown(KeyCode.Escape))

            {
                var popup = PopupManager.Instance.ShowSelelctBanPopup();
                HidePopup();
            }



        }

    }



    public void Onprevious()
    {
        var popup = PopupManager.Instance.ShowSelelctBanPopup();
        HidePopup();
    }

    public void OnNext()
    {
        var popup = PopupManager.Instance.ShowDifficultySelectPopup();
        HidePopup();
    }

    public void OnReverse()
    {if (_reversebtn.GetComponentInChildren<Text>().text == "유닛")
        {
            _reversebtn.GetComponentInChildren<Text>().text = "구조물";
            //여기에 변경점 입력

        }
        else if (_reversebtn.GetComponentInChildren<Text>().text == "구조물") {
            _reversebtn.GetComponentInChildren<Text>().text = "유닛";
            //여기에 변경점 입력
        }

    }

    public override void HidePopup()
    {
        base.HidePopup();

    }
}
