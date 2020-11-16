using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using Image = UnityEngine.UI.Image;

public class UnitSpawnBtn : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{
    public bool btnanycheck = false;
    public bool btnanyclick = false;
    public Image unit_face;
    private GameObject summonmanager;
    public Image overimg;
    private UnitSummon unit_tot;//유닛 배열을 받아오기 위함
    private String objname;//현재 클릭한 버튼 이름
    private String objimg;//현재 클릭한 버튼 이름

    public Text UnitName;
    public Text UnitHp;
    public Text UnitAtk; 
    public Text UnitDef; 
    public Text UnitA_spd;
    //텍스트
    public Image UnitImg;//이미지
    
    private GameObject[] UnitImgStatus;//텍스트 표시를 위한 게임 오브젝트

    private void Awake()
    {
        summonmanager = GameObject.Find("SummonUnit");
    }

    public void Start()
    {
        unit_tot = GameObject.Find("SummonUnit").GetComponent<UnitSummon>();
        UnitImgStatus = unit_tot.unit_;           
        objimg = gameObject.name;
    }

    public void OnClick()
    {
        SoundManager.Instance.menu_ok_Play();
        
        summonmanager.GetComponent<UnitSummon>().anypush = this.gameObject;//눌린 버튼의 오브젝트 할당
        btnanycheck = true;//버튼 눌림 확인
        objname = gameObject.name;//현재 클릭한 버튼

        for (int i = 0; i < UnitSummon.tot_btn; i++) // 버튼 총 개수 대로 for문 
        {
            string num = i.ToString();

            if (i == 0)
            {
                if (objname == "Summonclick")
                    UnitSummon.sel_btn = 0;
            }
            else if (objname == "Summonclick (" + num + ")")
                UnitSummon.sel_btn = i;
        }
        
    }

    void Update()
    {
        
        for (int i = 0; i < UnitSummon.tot_btn; i++) // 버튼 총 개수 대로 for문 
        {
            string num = i.ToString();

            if (i == 0)
            {
                if (objimg == "Summonclick")
                {
                    if (unit_tot.unit_[i].tag == "mercenarywarrior") //태그가 전사이면
                    {
                        unit_face.sprite = GetUnitSOInfo.Instance.unitface[0];
                    }
                    else if (unit_tot.unit_[i].tag == "mercenaryknight")//태그가 검사이면
                    {
                        unit_face.sprite = GetUnitSOInfo.Instance.unitface[1];
                    }
                    else if (unit_tot.unit_[i].tag == "mercenarylancemaster")//태그가 창술사라면
                    {
                        unit_face.sprite = GetUnitSOInfo.Instance.unitface[2];
                    }
                    //유닛 추가시 작성할 부분
                }
            }
            else if (objimg == "Summonclick (" + num + ")")
            {
                if (unit_tot.unit_[i].tag == "mercenarywarrior") //태그가 전사이면
                {
                    unit_face.sprite = GetUnitSOInfo.Instance.unitface[0];
                }
                else if (unit_tot.unit_[i].tag == "mercenaryknight") //태그가 검사이면
                {
                    unit_face.sprite = GetUnitSOInfo.Instance.unitface[1];
                }
                else if (unit_tot.unit_[i].tag == "mercenarylancemaster")//태그가 창술사라면
                {
                    unit_face.sprite = GetUnitSOInfo.Instance.unitface[2];
                }
                //유닛 추가시 작성할 부분
            }
            
        } //버튼에 태그별로 이미지 보여줌
        
        if (btnanyclick)
        {
            this.gameObject.SetActive(false);//버튼 비활성화
        }
        
        if (UnitCancelBtn.CancleCheack)
        {
            UnitCancelBtn.CancleCheack = false;//배치취소 비활성화
        }
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        overimg.gameObject.SetActive(true);
        CreateStatus(UnitImgStatus);
    }//마우스 오버시 정보창 보임

    public void OnPointerExit(PointerEventData eventData)
    {
        overimg.gameObject.SetActive(false);
    }//마우스가 바깥으로 이동시 사라짐

    public void CreateStatus(GameObject[] status)
    {
        for (int i = 0; i < UnitSummon.tot_btn; i++) // 버튼 총 개수 대로 for문 
        {
            string num = i.ToString();

            if (i == 0)
            {
                if (objimg == "Summonclick")
                {
                    UnitName.text = status[i].GetComponent<Unit>().Name;
                    UnitHp.text = status[i].GetComponent<Unit>().hp.ToString();
                    UnitAtk.text = status[i].GetComponent<Unit>().atk.ToString();
                    UnitDef.text = status[i].GetComponent<Unit>().def.ToString();
                    UnitA_spd.text = status[i].GetComponent<Unit>().a_spd.ToString();
                    
                    if (status[i].tag == "mercenarywarrior")
                        UnitImg.sprite = GetUnitSOInfo.Instance.unitface[0];
                    else if (status[i].tag == "mercenaryknight")
                        UnitImg.sprite = GetUnitSOInfo.Instance.unitface[1];
                    else if (status[i].tag == "mercenarylancemaster")
                        UnitImg.sprite = GetUnitSOInfo.Instance.unitface[2];
                    //유닛 추가시 작성할 부분
                    break;
                }  
            }  
            
            if (objimg == "Summonclick (" + num + ")")
            {
                UnitName.text = status[i].GetComponent<Unit>().Name;
                UnitHp.text = status[i].GetComponent<Unit>().hp.ToString();
                UnitAtk.text = status[i].GetComponent<Unit>().atk.ToString();
                UnitDef.text = status[i].GetComponent<Unit>().def.ToString();
                UnitA_spd.text = status[i].GetComponent<Unit>().a_spd.ToString();
                
                if (status[i].tag == "mercenarywarrior")
                    UnitImg.sprite = GetUnitSOInfo.Instance.unitface[0];
                else if (status[i].tag == "mercenaryknight")
                    UnitImg.sprite = GetUnitSOInfo.Instance.unitface[1];
                else if (status[i].tag == "mercenarylancemaster")
                    UnitImg.sprite = GetUnitSOInfo.Instance.unitface[2];
                //유닛 추가시 작성할 부분
                break;
            }  

        }
    }//호버한 버튼의 이름을 비교해 해당 영웅 스테이터스 표시

}
