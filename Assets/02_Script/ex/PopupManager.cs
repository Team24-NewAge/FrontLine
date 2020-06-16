using System;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private OptionPopup _optionPopup;
    [SerializeField] private ModeSelectPopup _gamemodeselectPopup;
    [SerializeField] private N_Select_Hero_Popup _select_hero_Popup;

    // [SerializeField] private GetStringPopup _getStringPopup;

    public static PopupManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public OptionPopup ShowOptionPopup()
    {
        return Instantiate(_optionPopup, _canvas.transform);
    }

    public ModeSelectPopup ShowGameModeSelectPopup()
    {
        return Instantiate(_gamemodeselectPopup, _canvas.transform);
    }

    public N_Select_Hero_Popup ShowSelectHeroPopup()
    {
        return Instantiate(_select_hero_Popup, _canvas.transform);
    }




    // public GetStringPopup ShowGetStringPopup()
    //{
    //return Instantiate(_getStringPopup, _canvas.transform);
    //}
}
