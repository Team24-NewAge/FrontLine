﻿
using UnityEngine;
using UnityEngine.UI;

public class TestPanel : PopupBase
{
    [SerializeField] private Text _nameText;
    [SerializeField] private Button _StartButton;

    private string _name;


    public void Refresh()

    {
        _nameText.text = _name;
    }

}
