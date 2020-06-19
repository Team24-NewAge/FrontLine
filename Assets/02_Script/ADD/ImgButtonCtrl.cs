using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ImgButtonCtrl : MonoBehaviour
{
    public GameObject ClickImage;//이미지
    private GameObject ShowBtn;//버튼 이름 받아올 값
    public GameObject OtherImage,
        OtherImage2,
        OtherImage3,
        OtherImage4,
        OtherImage5,
        OtherImage6,
        OtherImage7,
        OtherImage8,
        OtherImage9;
    //각 버튼에 대한 이벤트


    public String Quality/*속성*/,
        Health_point/*HP*/,
        Attack_point/*공격력*/,
        Armor_point/*방어력*/,
        Level_info/*레벨*/,
        Skill_info/*스킬 1*/,
        Skill_info2/*스킬 2*/,
        Skill_info3/*스킬 3*/,
        Skill_info4/*스킬 4*/;
    /*스킬은 일단 최대 4개까지 받음*/
  // DB에서 클릭시 받아올 값들
  
  public void OnShowButton()
    {
        ClickImage.SetActive(true);
        OtherImage.SetActive(false);
        OtherImage2.SetActive(false);
        OtherImage3.SetActive(false);
        OtherImage4.SetActive(false);
        OtherImage5.SetActive(false);
        OtherImage6.SetActive(false);
        OtherImage7.SetActive(false);
        OtherImage8.SetActive(false);
        OtherImage9.SetActive(false);

        ShowBtn = EventSystem.current.currentSelectedGameObject; //버튼 이름 받음
      
        OnShowInfo(ShowBtn.name);
    }
  
  public void OnShowInfo(String Name) // 이름을 받아서 Update문에서 이름을 비교
     {
         if (Name == "ShowButton")
         {
             Debug.Log(Name);
             //각 내용에서 보여줄 DB 값들을 String 배열로 가져와
             //이름 설명 등에 뿌려줌
         }
         else if (Name == "ShowButton (1)")
         {
             Debug.Log(Name);
         }
         else if (Name == "ShowButton (2)")
         {
             Debug.Log(Name);
         }
         else if (Name == "ShowButton (3)")
         {
             Debug.Log(Name);
         }
         else if (Name == "ShowButton (4)")
         {
             Debug.Log(Name);
         }
         else if (Name == "ShowButton (5)")
         {
             Debug.Log(Name);
         }
         else if (Name == "ShowButton (6)")
         {
             Debug.Log(Name);
         }
         else if (Name == "ShowButton (7)")
         {
             Debug.Log(Name);
         }
         else if (Name == "ShowButton (8)")
         {
             Debug.Log(Name);
         }
         else if (Name == "ShowButton (9)")
         {
             Debug.Log(Name);
         }
     }
}
