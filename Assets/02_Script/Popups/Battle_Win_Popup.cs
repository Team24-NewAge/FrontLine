using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle_Win_Popup : PopupBase
{
    int Clear_gold;
    public Text gold_text;
    public Text win_text;
    private void Awake()
    {
        Clear_gold = 10 + (int)(Random.Range(1.0f, 10.0f) * BarManager.Instance.date);
        gold_text.text = Clear_gold.ToString();

        switch (Random.Range(0, 5))
        {
            case 0: win_text.text = "영광스러운 승리로군, 계속 이대로 가세나";break;
            case 1: win_text.text = "전열을 가다듬고 승리를 쟁취하세"; break;
            case 2: win_text.text = "마물들 따위는 내게 상대도 되지 않는다네"; break;
            case 3: win_text.text = "생각보다 힘든 전투였군. 하지만 물러설수는 없다네"; break;
            case 4: win_text.text = "잡념을 버리고 적에게만 몰두하면 승리는 따라올 것이네"; break;
        }

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void HidePopup()
    {
        SoundManager.Instance.Lobby_On();
        BarManager.Instance.gold += Clear_gold;
        BarManager.Instance._SetCoin();
        base.HidePopup();
    }
}
