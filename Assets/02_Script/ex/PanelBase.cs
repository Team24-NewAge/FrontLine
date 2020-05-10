
using UnityEngine;

public abstract class PanelBase : MonoBehaviour
{
    public abstract void OnShow(params object[] args);
    public abstract void OnHide();

}
