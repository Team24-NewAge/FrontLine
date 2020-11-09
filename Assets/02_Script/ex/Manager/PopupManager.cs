using System;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private OptionPopup _optionPopup;
    [SerializeField] private ModeSelectPopup _gamemodeselectPopup;
    [SerializeField] private N_Select_Hero_Popup _select_hero_Popup;
    [SerializeField] private N_Select_Pick_Popup _select_pick_Popup;
    [SerializeField] private N_Select_Ban_Popup _select_ban_Popup;
    [SerializeField] private N_Select_Inherit_Popup _select_Inherit_Popup;
    [SerializeField] private Difficulty_Select_Popup _difficulty_Select_Popup;
    [SerializeField] private N_Setting_Check_Popup _setting_check_Popup;
    [SerializeField] private Battle_Win_Popup _battle_win_Popup;
    [SerializeField] private Event_Popup _event_Popup;
    [SerializeField] private UnitShop_Popup _unitshop_Popup;
    [SerializeField] private UnitBuy_Popup _unitbuy_Popup;
    [SerializeField] private Rebuild_Popup _rebuild_Popup;
    [SerializeField] private Rebuild_result_Popup _rebuild_result_Popup;
    [SerializeField] private Hero_Skill_Popup _hero_Skill_Popup;

    public PopupBase CurrnetPopup { get; private set; }

 // [SerializeField] private GetStringPopup _getStringPopup;

 public static PopupManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public OptionPopup ShowOptionPopup()
    {
        var newPopup = Instantiate(_optionPopup, _canvas.transform);

        CurrnetPopup = newPopup;

        return newPopup;
    }

    public ModeSelectPopup ShowGameModeSelectPopup()
    {
        return Instantiate(_gamemodeselectPopup, _canvas.transform);
    }

    public N_Select_Hero_Popup ShowSelectHeroPopup()
    {
        return Instantiate(_select_hero_Popup, _canvas.transform);
    }

    public N_Select_Pick_Popup ShowSelelctPickPopup()
    {
        return Instantiate (_select_pick_Popup, _canvas.transform);
    }

    public N_Select_Ban_Popup ShowSelelctBanPopup()
    {
        return Instantiate(_select_ban_Popup, _canvas.transform);
    }

    public N_Select_Inherit_Popup ShowSelectInheritPopup()
    {
        return Instantiate(_select_Inherit_Popup, _canvas.transform);
    }

    public Difficulty_Select_Popup ShowDifficultySelectPopup()
    {
        return Instantiate(_difficulty_Select_Popup, _canvas.transform);
    }

    public N_Setting_Check_Popup ShowSetting_Check_Popup()
    {
        return Instantiate(_setting_check_Popup, _canvas.transform);
    }

    public Battle_Win_Popup ShowBattle_Win_Popup()
    {
        return Instantiate(_battle_win_Popup, _canvas.transform);
    }


    public Event_Popup ShowEvent_Popup()
    {
        return Instantiate(_event_Popup, _canvas.transform);
    }

    public UnitShop_Popup ShowUnitShop_Popup()
    {
        return Instantiate(_unitshop_Popup, _canvas.transform);
    }


    public UnitBuy_Popup ShowUnitBuy_Popup()
    {
        return Instantiate(_unitbuy_Popup, _canvas.transform);
    }

    public Rebuild_Popup ShowRebuild_Popup()
    {
        return Instantiate(_rebuild_Popup, _canvas.transform);
    }
    public Rebuild_result_Popup ShowRebuild_Result_Popup()
    {
        return Instantiate(_rebuild_result_Popup, _canvas.transform);
    }

    public Hero_Skill_Popup ShowHero_Skill_Popup()
    {
        return Instantiate(_hero_Skill_Popup, _canvas.transform);
    }


    // public GetStringPopup ShowGetStringPopup()
    //{
    //return Instantiate(_getStringPopup, _canvas.transform);
    //}
}
