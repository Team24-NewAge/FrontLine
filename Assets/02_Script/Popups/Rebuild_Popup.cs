using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rebuild_Popup : PopupBase
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public GameObject exit_popup;
    public GameObject fadeimage;
    public void Exitpopup_on()
    {
        exit_popup.SetActive(true);
        fadeimage.SetActive(true);
    }
    public void Exitpopup_off()
    {
        exit_popup.SetActive(false);
        fadeimage.SetActive(false);
    }

    public override void HidePopup()
    {
        PaperManager.Instance.Paper_Locked_off();
        base.HidePopup();
    }


    public void LobbyBGM_On() {
        SoundManager.Instance.Lobby_On();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
