using UnityEngine;

public class PopupBase : MonoBehaviour
{
    public virtual void HidePopup()
    {
        Destroy(gameObject);
    }
}
