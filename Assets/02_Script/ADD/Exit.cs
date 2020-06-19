using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
   public GameObject Panel;
   public GameObject OpenBtn;
   
   public void OnClickExit()
   {
      Panel.SetActive(false);
      OpenBtn.SetActive(true);
   }
}
