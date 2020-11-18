using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainPanel : MonoBehaviour

{
    public GameObject Continue_btn;
    public void Awake()
    {
       int prefs_continue = PlayerPrefs.GetInt("CONTINUE", 0);
        if (prefs_continue == 0)
        {
            //CONTINUE = false;
            Continue_btn.SetActive(false) ;
        }
        else
        {
            //CONTINUE = true;
            Continue_btn.SetActive(true);
        }
    }

    public void OnOptionButtonClick()
    {
        var popup = PopupManager.Instance.ShowOptionPopup();
    }


    public void OnGameModeSelectBuootnClick()
    {
        var popup = PopupManager.Instance.ShowGameModeSelectPopup();
        //popup._HideAction += () => { print("hide option"); };
    }
    public void OnLoadBuootnClick()
    {
        PlayerPrefs.SetInt("CONTINUE", 1);
        SceneManager.LoadScene("InGame");
        SoundManager.Instance.Lobby_On();
    }

    public void BtnClick()
    {
        SoundManager.Instance.menu_ok_Play();
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
