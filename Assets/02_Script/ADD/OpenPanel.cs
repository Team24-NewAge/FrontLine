using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanel : MonoBehaviour
{
    public GameObject Panel;
    public GameObject OpenBtn;
   
    public void OnClickOpen()
    {
        Panel.SetActive(true);
        OpenBtn.SetActive(false);
    }
}
