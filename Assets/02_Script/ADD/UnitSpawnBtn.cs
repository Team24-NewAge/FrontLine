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
                    if (unit_tot.unit_[i].tag == "mercenarywarrior") //태그가 용병전사
                    {
                        unit_face.sprite = GetUnitSOInfo.Instance.unitface[0];
                    }
                    else if (unit_tot.unit_[i].tag == "shieldsoldier")//태그가 방패병
                    {
                        unit_face.sprite = GetUnitSOInfo.Instance.unitface[1];
                    }
                    else if (unit_tot.unit_[i].tag == "rogue")//태그가 도적
                    {
                        unit_face.sprite = GetUnitSOInfo.Instance.unitface[2];
                    }
                    else if (unit_tot.unit_[i].tag == "mercenaryknight")//태그가 용병검사
                    {
                        unit_face.sprite = GetUnitSOInfo.Instance.unitface[3];
                    }
                    else if (unit_tot.unit_[i].tag == "axewarrior")//태그가 도끼전사
                    {
                        unit_face.sprite = GetUnitSOInfo.Instance.unitface[4];
                    }
                    else if (unit_tot.unit_[i].tag == "protectiongeneral")//태그가 수호대장
                    {
                        unit_face.sprite = GetUnitSOInfo.Instance.unitface[5];
                    }
                    else if (unit_tot.unit_[i].tag == "mercenarylancemaster")//태그가 용병창술사
                    {
                        unit_face.sprite = GetUnitSOInfo.Instance.unitface[6];
                    }
                    else if (unit_tot.unit_[i].tag == "apprentice")//태그가 견습술사
                    {
                        unit_face.sprite = GetUnitSOInfo.Instance.unitface[7];
                    }
                    else if (unit_tot.unit_[i].tag == "gladiator")//태그가 검투사
                    {
                        unit_face.sprite = GetUnitSOInfo.Instance.unitface[8];
                    }
                    else if (unit_tot.unit_[i].tag == "mercenarygeneral")//태그가 용병대장
                    {
                        unit_face.sprite = GetUnitSOInfo.Instance.unitface[9];
                    }
                    else if (unit_tot.unit_[i].tag == "priest")//태그가 프리스트
                    {
                        unit_face.sprite = GetUnitSOInfo.Instance.unitface[10];
                    }
                    else if (unit_tot.unit_[i].tag == "plaguedoctor")//태그가 역병의사
                    {
                        unit_face.sprite = GetUnitSOInfo.Instance.unitface[11];
                    }
                    else if (unit_tot.unit_[i].tag == "maestre")//태그가 기사단장
                    {
                        unit_face.sprite = GetUnitSOInfo.Instance.unitface[12];
                    }
                    else if (unit_tot.unit_[i].tag == "elfmagition")//태그가 엘프마법사이면
                    {
                        unit_face.sprite = GetUnitSOInfo.Instance.unitface[13];
                    }
                    else if (unit_tot.unit_[i].tag == "highpriestess")//태그가 하이프리스트리스
                    {
                        unit_face.sprite = GetUnitSOInfo.Instance.unitface[14];
                    }
                    //유닛 추가시 작성할 부분
                }
            }
            else if (objimg == "Summonclick (" + num + ")")
            {
                 if (unit_tot.unit_[i].tag == "mercenarywarrior") //태그가 용병전사
                    {
                        unit_face.sprite = GetUnitSOInfo.Instance.unitface[0];
                    }
                    else if (unit_tot.unit_[i].tag == "shieldsoldier")//태그가 방패병
                    {
                        unit_face.sprite = GetUnitSOInfo.Instance.unitface[1];
                    }
                    else if (unit_tot.unit_[i].tag == "rogue")//태그가 도적
                    {
                        unit_face.sprite = GetUnitSOInfo.Instance.unitface[2];
                    }
                    else if (unit_tot.unit_[i].tag == "mercenaryknight")//태그가 용병검사
                    {
                        unit_face.sprite = GetUnitSOInfo.Instance.unitface[3];
                    }
                    else if (unit_tot.unit_[i].tag == "axewarrior")//태그가 도끼전사
                    {
                        unit_face.sprite = GetUnitSOInfo.Instance.unitface[4];
                    }
                    else if (unit_tot.unit_[i].tag == "protectiongeneral")//태그가 수호대장
                    {
                        unit_face.sprite = GetUnitSOInfo.Instance.unitface[5];
                    }
                    else if (unit_tot.unit_[i].tag == "mercenarylancemaster")//태그가 용병창술사
                    {
                        unit_face.sprite = GetUnitSOInfo.Instance.unitface[6];
                    }
                    else if (unit_tot.unit_[i].tag == "apprentice")//태그가 견습술사
                    {
                        unit_face.sprite = GetUnitSOInfo.Instance.unitface[7];
                    }
                    else if (unit_tot.unit_[i].tag == "gladiator")//태그가 검투사
                    {
                        unit_face.sprite = GetUnitSOInfo.Instance.unitface[8];
                    }
                    else if (unit_tot.unit_[i].tag == "mercenarygeneral")//태그가 용병대장
                    {
                        unit_face.sprite = GetUnitSOInfo.Instance.unitface[9];
                    }
                    else if (unit_tot.unit_[i].tag == "priest")//태그가 프리스트
                    {
                        unit_face.sprite = GetUnitSOInfo.Instance.unitface[10];
                    }
                    else if (unit_tot.unit_[i].tag == "plaguedoctor")//태그가 역병의사
                    {
                        unit_face.sprite = GetUnitSOInfo.Instance.unitface[11];
                    }
                    else if (unit_tot.unit_[i].tag == "maestre")//태그가 기사단장
                    {
                        unit_face.sprite = GetUnitSOInfo.Instance.unitface[12];
                    }
                    else if (unit_tot.unit_[i].tag == "elfmagition")//태그가 엘프마법사이면
                    {
                        unit_face.sprite = GetUnitSOInfo.Instance.unitface[13];
                    }
                    else if (unit_tot.unit_[i].tag == "highpriestess")//태그가 하이프리스트리스
                    {
                        unit_face.sprite = GetUnitSOInfo.Instance.unitface[14];
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
                    
                     if (status[i].tag == "mercenarywarrior") //태그가 용병전사
                    {
                        UnitImg.sprite = GetUnitSOInfo.Instance.unitface[0];
                    }
                    else if (status[i].tag == "shieldsoldier")//태그가 방패병
                    {
                        UnitImg.sprite = GetUnitSOInfo.Instance.unitface[1];
                    }
                    else if (status[i].tag == "rogue")//태그가 도적
                    {
                        UnitImg.sprite = GetUnitSOInfo.Instance.unitface[2];
                    }
                    else if (status[i].tag == "mercenaryknight")//태그가 용병검사
                    {
                        UnitImg.sprite = GetUnitSOInfo.Instance.unitface[3];
                    }
                    else if (status[i].tag == "axewarrior")//태그가 도끼전사
                    {
                        UnitImg.sprite = GetUnitSOInfo.Instance.unitface[4];
                    }
                    else if (status[i].tag == "protectiongeneral")//태그가 수호대장
                    {
                        UnitImg.sprite = GetUnitSOInfo.Instance.unitface[5];
                    }
                    else if (status[i].tag == "mercenarylancemaster")//태그가 용병창술사
                    {
                        UnitImg.sprite = GetUnitSOInfo.Instance.unitface[6];
                    }
                    else if (status[i].tag == "apprentice")//태그가 견습술사
                    {
                        UnitImg.sprite = GetUnitSOInfo.Instance.unitface[7];
                    }
                    else if (status[i].tag == "gladiator")//태그가 검투사
                    {
                        UnitImg.sprite = GetUnitSOInfo.Instance.unitface[8];
                    }
                    else if (status[i].tag == "mercenarygeneral")//태그가 용병대장
                    {
                        UnitImg.sprite = GetUnitSOInfo.Instance.unitface[9];
                    }
                    else if (status[i].tag == "priest")//태그가 프리스트
                    {
                        UnitImg.sprite = GetUnitSOInfo.Instance.unitface[10];
                    }
                    else if (status[i].tag == "plaguedoctor")//태그가 역병의사
                    {
                        UnitImg.sprite = GetUnitSOInfo.Instance.unitface[11];
                    }
                    else if (status[i].tag == "maestre")//태그가 기사단장
                    {
                        UnitImg.sprite = GetUnitSOInfo.Instance.unitface[12];
                    }
                    else if (status[i].tag == "elfmagition")//태그가 엘프마법사이면
                    {
                        UnitImg.sprite = GetUnitSOInfo.Instance.unitface[13];
                    }
                    else if (status[i].tag == "highpriestess")//태그가 하이프리스트리스
                    {
                        UnitImg.sprite = GetUnitSOInfo.Instance.unitface[14];
                    }
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
                
                  if (status[i].tag == "mercenarywarrior") //태그가 용병전사
                    {
                        UnitImg.sprite = GetUnitSOInfo.Instance.unitface[0];
                    }
                    else if (status[i].tag == "shieldsoldier")//태그가 방패병
                    {
                        UnitImg.sprite = GetUnitSOInfo.Instance.unitface[1];
                    }
                    else if (status[i].tag == "rogue")//태그가 도적
                    {
                        UnitImg.sprite = GetUnitSOInfo.Instance.unitface[2];
                    }
                    else if (status[i].tag == "mercenaryknight")//태그가 용병검사
                    {
                        UnitImg.sprite = GetUnitSOInfo.Instance.unitface[3];
                    }
                    else if (status[i].tag == "axewarrior")//태그가 도끼전사
                    {
                        UnitImg.sprite = GetUnitSOInfo.Instance.unitface[4];
                    }
                    else if (status[i].tag == "protectiongeneral")//태그가 수호대장
                    {
                        UnitImg.sprite = GetUnitSOInfo.Instance.unitface[5];
                    }
                    else if (status[i].tag == "mercenarylancemaster")//태그가 용병창술사
                    {
                        UnitImg.sprite = GetUnitSOInfo.Instance.unitface[6];
                    }
                    else if (status[i].tag == "apprentice")//태그가 견습술사
                    {
                        UnitImg.sprite = GetUnitSOInfo.Instance.unitface[7];
                    }
                    else if (status[i].tag == "gladiator")//태그가 검투사
                    {
                        UnitImg.sprite = GetUnitSOInfo.Instance.unitface[8];
                    }
                    else if (status[i].tag == "mercenarygeneral")//태그가 용병대장
                    {
                        UnitImg.sprite = GetUnitSOInfo.Instance.unitface[9];
                    }
                    else if (status[i].tag == "priest")//태그가 프리스트
                    {
                        UnitImg.sprite = GetUnitSOInfo.Instance.unitface[10];
                    }
                    else if (status[i].tag == "plaguedoctor")//태그가 역병의사
                    {
                        UnitImg.sprite = GetUnitSOInfo.Instance.unitface[11];
                    }
                    else if (status[i].tag == "maestre")//태그가 기사단장
                    {
                        UnitImg.sprite = GetUnitSOInfo.Instance.unitface[12];
                    }
                    else if (status[i].tag == "elfmagition")//태그가 엘프마법사이면
                    {
                        UnitImg.sprite = GetUnitSOInfo.Instance.unitface[13];
                    }
                    else if (status[i].tag == "highpriestess")//태그가 하이프리스트리스
                    {
                        UnitImg.sprite = GetUnitSOInfo.Instance.unitface[14];
                    }
                //유닛 추가시 작성할 부분
                break;
            }  

        }
    }//호버한 버튼의 이름을 비교해 해당 영웅 스테이터스 표시

}
