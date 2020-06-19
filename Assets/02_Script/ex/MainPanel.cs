using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPanel : MonoBehaviour



{
    public void OnOptionButtonClick()
    {
        var popup = PopupManager.Instance.ShowOptionPopup();
        //popup._HideAction += () => { print("hide option"); };
    }


    public void OnGameModeSelectBuootnClick()
    {
        var popup = PopupManager.Instance.ShowGameModeSelectPopup();
        //popup._HideAction += () => { print("hide option"); };
    }

   // public void OnGetNameButtonClick()
    //{
        //var popup = PopupManager.Instance.ShowGetStringPopup();
        //popup.NickNameAction += nickName => { print(nickName); };

        //popup.GetInitNameFunc += () =>
       // {
            //return "123123";
        //};
    //}
}
