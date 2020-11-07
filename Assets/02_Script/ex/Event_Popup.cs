using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class Event_Popup : PopupBase
{

    public Text main_text, button_text1, button_text2, button_text3;
    public Button button1, button2, button3;


    private void Awake()
    {
       // button1.onClick.AddListener(() => { EventManager.Instance.Play_the_horses_1(); });
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void HidePopup()
    {
        PaperManager.Instance.Paper_Locked_off();
        base.HidePopup();
    }

    public void LobbyBGM_On()
    {
        SoundManager.Instance.Lobby_On();
    }
    public void addEvent() {

        button1.onClick.AddListener(() => { EventManager.Instance.Play_the_horses_1(); });
        main_text.text = "엌ㅋㅋ개이득ㅋㅋㅋ ";
    }

}
