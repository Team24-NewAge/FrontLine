
using UnityEngine;
using UnityEngine.UI;

public class TestPanel : PanelBase
{
    [SerializeField] private Text _nameText;
    [SerializeField] private Button _StartButton;

    private string _name;

    public override void OnShow()
    {

    }


    public override void OnHide()
    {
        Destroy(gameObject);
    }


    public void Refresh()

    {
        _nameText.text = _name;
    }

}
