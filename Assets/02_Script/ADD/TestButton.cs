using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TestButton : MonoBehaviour
{
    [SerializeField] private Image _charImage;

    
    private int _charId;
    private TestPanel _testPanel; // 패널을 알게하지 않고 Action으로 대체하는 것이 좋음
    public static bool chack = false;
    public void SetImage(int charId, TestPanel testPanel)
    {
        _charId = charId;
        _testPanel = testPanel;
        _charImage.sprite = Resources.Load<Sprite>("UnitImage/" + _charId);
    }

    public void OnButtonClick()
    {
        chack = true;
    }
    
    private void Update()
    {
        if(chack)
        _testPanel.CreateChar(_charId);
    }
}
