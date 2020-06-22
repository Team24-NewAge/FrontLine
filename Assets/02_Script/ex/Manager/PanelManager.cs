using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{


    [SerializeField] private Canvas _panelCanvas;
    [SerializeField] private TTestPanel _testPanel;
    [SerializeField] private ModeSelectPopup _modeSelectPanel;
    public CommandPanel _commandPanel;



    //[SerializeField] private OptionPanel _optionPanel;


    public static PanelManager Instance { get; private set; }
    private PopupBase _currunt;
   

    public void Awake()
    {
        Instance = this;
    }

    public void ShowTestPanel(string a) //테스트 패널
    {


        var panel = Instantiate(_testPanel, _panelCanvas.transform);



       _currunt = panel;

    }

    public void ShowModeSelelct()
    {


        var panel = Instantiate (_modeSelectPanel, _panelCanvas.transform);


    }

    public void ShowOption()
    {

       // _optionPanel.gameObject.SetActive(true);
        //var panel = Instantiate(_optionPanel, _panelCanvas.transform);


    }



}
