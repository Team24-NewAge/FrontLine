
using UnityEngine;
using UnityEngine.UI;

public class TestPanel : PanelBase
{
    [SerializeField] private Text _nameText;
    [SerializeField] private Button _StartButton;

    private string _name;

    public override void OnShow(params object[] args)
    {
        _name = (string)args[0];
    }


    public override void OnHide()
    {

    }

}
