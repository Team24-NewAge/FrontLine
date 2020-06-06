using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{


    [SerializeField] private Canvas _panelCanvas;
    [SerializeField] private TestPanel _testPanel;
    [SerializeField] private ModeSelectPanel _modeSelectPanel;
    [SerializeField] private OptionPanel _optionPanel;


    public static PanelManager Instance { get; private set; }
    private PanelBase _currunt;
   

    public void Awake()
    {
        Instance = this;
    }

    public void ShowTestPanel(string a) //테스트 패널
    {

        if (_currunt != null)
        {
            _currunt.OnHide();

            Destroy(_currunt);
        }

        var panel = Instantiate(_testPanel, _panelCanvas.transform);
        panel.OnShow();


       _currunt = panel;

    }

    public void ShowModeSelelct()
    {


        var panel = Instantiate (_modeSelectPanel, _panelCanvas.transform);


    }

    public void ShowOption()
    {

        _optionPanel.gameObject.SetActive(true);
        //var panel = Instantiate(_optionPanel, _panelCanvas.transform);


    }



}
