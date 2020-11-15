using UnityEngine;

public class PopupBase : MonoBehaviour
{
   
    public virtual void HidePopup()
    {
        Destroy(gameObject);
    }


    public void ok_sound() {

        SoundManager.Instance.menu_ok_Play();
    }
    public void cancle_sound()
    {

        SoundManager.Instance.cancle_menu();
    }
    public void upgrade_sound()
    {

        SoundManager.Instance.reinforce_menu();
    }
}
