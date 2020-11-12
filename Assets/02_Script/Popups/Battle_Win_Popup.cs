using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle_Win_Popup : PopupBase
{
    int Clear_gold;
    public Text gold_text;
    public Text win_text;
    public Button Reward_btn1, Reward_btn2, Reward_btn3;
    public Sprite openbox1,openbox2,openbox3;
    public int Reward_check=0;

    public GameObject exit_popup;
    public GameObject fadeimage;

    private void Awake()
    {
        Clear_gold = 10 + (int)(Random.Range(1.0f, 5.0f) * BarManager.Instance.date);
        gold_text.text = Clear_gold.ToString();

        switch (Random.Range(0, 5))
        {
            case 0: win_text.text = "영광스러운 승리로군, 계속 이대로 가세나";break;
            case 1: win_text.text = "전열을 가다듬고 승리를 쟁취하세"; break;
            case 2: win_text.text = "마물들 따위는 내게 상대도 되지 않는다네"; break;
            case 3: win_text.text = "생각보다 힘든 전투였군. 하지만 물러설수는 없다네"; break;
            case 4: win_text.text = "잡념을 버리고 적에게만 몰두하면 승리는 따라올 것이네"; break;
        }

        if (Random.Range(0f, 1.0f) < Reward(1))
        {
            Reward_btn1.gameObject.SetActive(true);
            Reward_check++;
            if (Random.Range(0f, 1.0f) < Reward(2))
            {
                Reward_btn2.gameObject.SetActive(true);
                Reward_check++;
                if (Random.Range(0f, 1.0f) < Reward(3))
                {
                    Reward_btn3.gameObject.SetActive(true);
                    Reward_check++;
                }
            }
        }

    }
    void Start()
    {
        
    }


     float Reward(int r_num) {

        switch (GameManager.Instance.Battle)
        {
            case GameManager.battleState.nomal:
                {
                    switch (r_num) 
                    {
                        case 1: return 0.3f;
                        case 2: return 0.0f;
                        case 3: return 0.0f;

                    }
                    return 0.3f;
                    
                }
            case GameManager.battleState.elite:
                {
                    switch (r_num)
                    {
                        case 1: return 0.7f;
                        case 2: return 0.3f;
                        case 3: return 0.0f;

                    }
                    return 0.7f;
                }
            case GameManager.battleState.boss:
                {
                    switch (r_num)
                    {
                        case 1: return 1f;
                        case 2: return 0.7f;
                        case 3: return 0.3f;
                    }
                    return 1f;
                }

        }
        return 0.3f;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reward_Open(int box_num) 
    {
        Reward_check--;
        PlacementManager.Instance.root = PlacementManager.Root._reward;
        GameManager.Instance.SavePopup = gameObject;
        PopupManager.Instance.ShowUnitBuy_Popup();
        switch (box_num) 
        {
            case 1: Reward_btn1.image.sprite = openbox1;
                Reward_btn1.interactable = false;
               // Reward_btn1.gameObject.GetComponent<RectTransform>().position -= new Vector3(0, 15, 0);
                break;
            case 2: Reward_btn2.image.sprite = openbox2;
                Reward_btn2.interactable = false;
                Reward_btn2.gameObject.GetComponent<RectTransform>().position -= new Vector3(0, -15, 0);
                break;
            case 3: Reward_btn3.image.sprite = openbox3;
                Reward_btn3.interactable = false;
                Reward_btn3.gameObject.GetComponent<RectTransform>().position -= new Vector3(0, -15, 0);
                break;
        }


        gameObject.SetActive(false);
    }

    public void exit_btn() {

        if (Reward_check != 0)
        {
            Exitpopup_on();
        }
        else 
        {
            HidePopup();
        }
    
    }

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
        PlacementManager.Instance.root = PlacementManager.Root._none;
        Reward_check = 0;
        SoundManager.Instance.Lobby_On();
        BarManager.Instance.gold += Clear_gold;
        BarManager.Instance._SetCoin();
        base.HidePopup();
    }
}
