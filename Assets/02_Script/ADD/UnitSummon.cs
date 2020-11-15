using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSummon : MonoBehaviour
{
    private GameObject camera;
    private Ray ray;
    RaycastHit hit;
    
    private Tile 
        tile_9, tile_8, tile_7, tile_6, tile_5,
        tile_4, tile_3, tile_2, tile_1, tile_0; //각 타일 타입 변수
    
    GameObject [] warriors;//용병전사용 배열
    GameObject[] knights;//용병검사용 배열

    public GameObject[] unit_ = new GameObject[100];//유닛들
    public GameObject anypush = null;//타일이 눌렸는지, 버튼이 눌렸는지 확인할 게임오브젝트
    public GameObject tile_po;//RayCast에서 콜라이더를 가져오기 위한 변수
    
    private bool btnanycheck;//타일이 눌렸는지 확인할 전역변수
    
    public static int tot_btn;//버튼 총개수

    public static int sel_btn;//선택한 버튼 번호를 통해 저장된 배열 방 번호 지정
    
    private GameObject Hero;//하이얼아키 창 영웅 

    public GameObject inven;
    public GameObject unit;
    
    public static int post_tot = 0;
    public static bool fusionchk = false;
    public int fusion;
    void Awake()
    {
        Hero = GameObject.Find("Unit").transform.Find("Hero_Warrior").gameObject;
        camera = GameObject.Find("Cameras").transform.Find("Battle Camera").gameObject;
        inven = GameObject.Find("Inventory");
        unit = GameObject.Find("Unit");
    }

    void Start() {  //각 타일 찾아서 연결
        
        tile_9 = GameObject.Find("tile_9").GetComponent<Tile>();
        tile_8 = GameObject.Find("tile_8").GetComponent<Tile>();
        tile_7 = GameObject.Find("tile_7").GetComponent<Tile>();
        tile_6 = GameObject.Find("tile_6").GetComponent<Tile>();
        tile_5 = GameObject.Find("tile_5").GetComponent<Tile>();
        tile_4 = GameObject.Find("tile_4").GetComponent<Tile>();
        tile_3 = GameObject.Find("tile_3").GetComponent<Tile>();
        tile_2 = GameObject.Find("tile_2").GetComponent<Tile>();
        tile_1 = GameObject.Find("tile_1").GetComponent<Tile>();
        tile_0 = GameObject.Find("tile_0").GetComponent<Tile>();

    }

    public IEnumerator FusionChk()
    {
        yield return new WaitForSeconds(0.5f);
        
        fusion = 0;
        
        for (int i = 0; i < 100; i++, fusion++)
                unit_[fusion] = null;
        
        BtnAct.unit_post = post_tot;
        
        fusion = 0;

        if (unit.transform.childCount != 0) 
            for (int i = 0; i < unit.transform.childCount - 1; i++, fusion++)
                unit_[fusion] = unit.transform.GetChild(i).gameObject;

        if (inven.transform.childCount != 0)
            for (int i = 0; i < inven.transform.childCount; i++, fusion++)
                unit_[fusion] = inven.transform.GetChild(i).gameObject;

        tot_btn = inven.transform.childCount + (unit.transform.childCount - 1);
        
        post_tot = tot_btn;

        GameObject.Find("Startlocation ").GetComponent<BtnAct>().OnClick();
        
        fusionchk = false;
        
    }//유닛 합성 코루틴
    
    public void Update()
    {
        //Debug.Log(tot_btn);
        //Debug.Log(post_tot);
        int num = 0;//유닛 배열 번호

        if (PlacementManager.batchstart)
        {
            for (int i = 0; i < 100; i++, num++)
                unit_[num] = null;
            
            num = 0;//유닛 배열 번호
            
            if (unit.transform.childCount != 0)
                for (int i = 0; i < unit.transform.childCount - 1; i++, num++)
                {
                    unit_[num] = unit.transform.GetChild(i).gameObject;
                }

            if (inven.transform.childCount != 0)
                for (int i = 0; i < inven.transform.childCount; i++, num++)
                {
                    unit_[num] = inven.transform.GetChild(i).gameObject;
                }
            
            tot_btn = inven.transform.childCount + (unit.transform.childCount - 1);
            PlacementManager.batchstart = false;
        }//유닛 배치가 시작되었을떄

        if (UnitCancelBtn.CancleCheack)
        {
            for (int i = 0; i < 100; i++, num++)
                unit_[num] = null;
            
            num = 0;//유닛 배열 번호
            
            if (unit.transform.childCount != 0)
                for (int i = 0; i < unit.transform.childCount - 1; i++, num++)
                {
                    unit_[num] = unit.transform.GetChild(i).gameObject;
                }

            if (inven.transform.childCount != 0)
                for (int i = 0; i < inven.transform.childCount; i++, num++)
                {
                    unit_[num] = inven.transform.GetChild(i).gameObject;
                }
            
            tot_btn = inven.transform.childCount + (unit.transform.childCount - 1);
        }//유닛 배치 취소 시

        if(fusionchk)
            StartCoroutine(FusionChk());//유닛 합성시 

        if (anypush != null)
        {
            btnanycheck = anypush.GetComponent<UnitSpawnBtn>().btnanycheck;// 버튼 누르고 타일 누른 상태 확인
        }
        else
        {
            return;
        }

        if (Input.GetMouseButtonDown(0) && btnanycheck)//마우스 왼쪽 버튼이 눌렸고 버튼이 눌린 상태라면
        {

            ray = camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out hit/*맞은 대상의 정보를 가져옴*/, 100f))//Ray 발사
            {
                if (hit.transform.gameObject.name == tile_9.name) //Raycast가 타일에 맞았다면
                {
                    tile_po = hit.collider.gameObject;//Ray 가져옴
                    GameObject [] tile_unit_po = new GameObject[3];// Tile 스크립트의 Unit_po 배열을 가져오기 위함
                    tile_unit_po[0] = tile_po.GetComponent<Tile>().Unit_po[0];
                    tile_unit_po[1] = tile_po.GetComponent<Tile>().Unit_po[1];
                    tile_unit_po[2] = tile_po.GetComponent<Tile>().Unit_po[2];
                    Vector3 first = tile_unit_po[0].transform.position; // 첫번쨰 위치
                    Vector3 second = tile_unit_po[1].transform.position; // 두번째 위치
                    Vector3 third = tile_unit_po[2].transform.position;// 세번째 위치
                    
                    Unit [] unit = new Unit[3]; //유닛 스크립트 사용을 위해 지역 변수 선언

                    if (tile_9.Unit[0] != null && tile_9.Unit[1] != null && tile_9.Unit[2] != null)
                        anypush.GetComponent<UnitSpawnBtn>().btnanyclick = false;//타일이 꽉차있는 상태에서 눌렀다면 버튼 활성화(false)해줌
                    else
                    
                        anypush.GetComponent<UnitSpawnBtn>().btnanyclick = true;// 타일이 눌렸다면 버튼 비활성화(true)해줌
                    
                    if (tile_9.Unit[0] == null)
                    {
                        tile_9.Unit[0] = unit_[sel_btn];
                        unit_[sel_btn].transform.position = first;
                        unit[0] = unit_[sel_btn].GetComponent<Unit>(); // 해당 PlayerPrefs에서 해당 이름의 유닛 가져옴 (예정)
                        unit[0].Current_Tile = tile_9; // 해당 유닛의 Current_Tile에 타일 연결
                        unit[0].Current_Location = tile_unit_po[0]; // 해당 유닛의 Current_Location에 게임 오브젝트 연결
                        unit[0].Current_Location_number = "1"; // 해당 유닛의 Current_Location_number 변경
                        unit_[sel_btn].transform.SetParent(GameManager.Instance.Units.transform); //해당 unit의 부모를 인벤에서 Unit으로 변경
                    }
                    else if (tile_9.Unit[1] == null)
                    {
                        tile_9.Unit[1] = unit_[sel_btn];
                        unit_[sel_btn].transform.position = second;
                        unit[1] = unit_[sel_btn].GetComponent<Unit>(); // 해당 PlayerPrefs에서 해당 이름의 유닛 가져옴 (예정)
                        unit[1].Current_Tile = tile_9; // 해당 유닛의 Current_Tile에 타일 연결
                        unit[1].Current_Location = tile_unit_po[1]; // 해당 유닛의 Current_Location에 게임 오브젝트 연결
                        unit[1].Current_Location_number = "2"; // 해당 유닛의 Current_Location_number 변경
                        unit_[sel_btn].transform.SetParent(GameManager.Instance.Units.transform); //해당 unit의 부모를 인벤에서 Unit으로 변경
                    }
                    else if (tile_9.Unit[2] == null)
                    {
                        tile_9.Unit[2] = unit_[sel_btn];
                        unit_[sel_btn].transform.position = third;
                        unit[2] = unit_[sel_btn].GetComponent<Unit>(); // 해당 PlayerPrefs에서 해당 이름의 유닛 가져옴 (예정)
                        unit[2].Current_Tile = tile_9; // 해당 유닛의 Current_Tile에 타일 연결
                        unit[2].Current_Location = tile_unit_po[2]; // 해당 유닛의 Current_Location에 게임 오브젝트 연결
                        unit[2].Current_Location_number = "3"; // 해당 유닛의 Current_Location_number 변경
                        unit_[sel_btn].transform.SetParent(GameManager.Instance.Units.transform); //해당 unit의 부모를 인벤에서 Unit으로 변경
                    }
                    
                }//9번 타일
                
                else if (hit.transform.gameObject.name == tile_8.name) //Raycast가 타일에 맞았다면
                {
                    tile_po = hit.collider.gameObject;//Ray 가져옴
                    GameObject [] tile_unit_po = new GameObject[3];// Tile 스크립트의 Unit_po 배열을 가져오기 위함
                    tile_unit_po[0] = tile_po.GetComponent<Tile>().Unit_po[0];
                    tile_unit_po[1] = tile_po.GetComponent<Tile>().Unit_po[1];
                    tile_unit_po[2] = tile_po.GetComponent<Tile>().Unit_po[2];
                    Vector3 first = tile_unit_po[0].transform.position; // 첫번쨰 위치
                    Vector3 second = tile_unit_po[1].transform.position; // 두번째 위치
                    Vector3 third = tile_unit_po[2].transform.position;// 세번째 위치
                    
                    Unit [] unit = new Unit[3]; //유닛 스크립트 사용을 위해 지역 변수 선언
                    
                    if (tile_8.Unit[0] != null && tile_8.Unit[1] != null && tile_8.Unit[2] != null)
                        anypush.GetComponent<UnitSpawnBtn>().btnanyclick = false;//타일이 꽉차있는 상태에서 눌렀다면 버튼 활성화(false)해줌
                    else
                    
                        anypush.GetComponent<UnitSpawnBtn>().btnanyclick = true;// 타일이 눌렸다면 버튼 비활성화(true)해줌
                    
                    if (tile_8.Unit[0] == null)
                    {
                        tile_8.Unit[0] = unit_[sel_btn];
                        unit_[sel_btn].transform.position = first;
                        unit[0] = unit_[sel_btn].GetComponent<Unit>(); // 해당 PlayerPrefs에서 해당 이름의 유닛 가져옴 (예정)
                        unit[0].Current_Tile = tile_8; // 해당 유닛의 Current_Tile에 타일 연결
                        unit[0].Current_Location = tile_unit_po[0]; // 해당 유닛의 Current_Location에 게임 오브젝트 연결
                        unit[0].Current_Location_number = "1"; // 해당 유닛의 Current_Location_number 변경
                        unit_[sel_btn].transform.SetParent(GameManager.Instance.Units.transform); //해당 unit의 부모를 인벤에서 Unit으로 변경
                    }
                    else if (tile_8.Unit[1] == null)
                    {
                        tile_8.Unit[1] = unit_[sel_btn];
                        unit_[sel_btn].transform.position = second;
                        unit[1] = unit_[sel_btn].GetComponent<Unit>(); // 해당 PlayerPrefs에서 해당 이름의 유닛 가져옴 (예정)
                        unit[1].Current_Tile = tile_8; // 해당 유닛의 Current_Tile에 타일 연결
                        unit[1].Current_Location = tile_unit_po[1]; // 해당 유닛의 Current_Location에 게임 오브젝트 연결
                        unit[1].Current_Location_number = "2"; // 해당 유닛의 Current_Location_number 변경
                        unit_[sel_btn].transform.SetParent(GameManager.Instance.Units.transform); //해당 unit의 부모를 인벤에서 Unit으로 변경
                    }
                    else if (tile_8.Unit[2] == null)
                    {
                        tile_8.Unit[2] = unit_[sel_btn];
                        unit_[sel_btn].transform.position = third;
                        unit[2] = unit_[sel_btn].GetComponent<Unit>(); // 해당 PlayerPrefs에서 해당 이름의 유닛 가져옴 (예정)
                        unit[2].Current_Tile = tile_8; // 해당 유닛의 Current_Tile에 타일 연결
                        unit[2].Current_Location = tile_unit_po[2]; // 해당 유닛의 Current_Location에 게임 오브젝트 연결
                        unit[2].Current_Location_number = "3"; // 해당 유닛의 Current_Location_number 변경
                        unit_[sel_btn].transform.SetParent(GameManager.Instance.Units.transform); //해당 unit의 부모를 인벤에서 Unit으로 변경
                    }
                  
                }//8번 타일
                
                else if (hit.transform.gameObject.name == tile_7.name) //Raycast가 타일에 맞았다면
                {
                    tile_po = hit.collider.gameObject;//Ray 가져옴
                    GameObject [] tile_unit_po = new GameObject[3];// Tile 스크립트의 Unit_po 배열을 가져오기 위함
                    tile_unit_po[0] = tile_po.GetComponent<Tile>().Unit_po[0];
                    tile_unit_po[1] = tile_po.GetComponent<Tile>().Unit_po[1];
                    tile_unit_po[2] = tile_po.GetComponent<Tile>().Unit_po[2];
                    Vector3 first = tile_unit_po[0].transform.position; // 첫번쨰 위치
                    Vector3 second = tile_unit_po[1].transform.position; // 두번째 위치
                    Vector3 third = tile_unit_po[2].transform.position;// 세번째 위치
                    
                    Unit [] unit = new Unit[3]; //유닛 스크립트 사용을 위해 지역 변수 선언
                    
                    if (tile_7.Unit[0] != null && tile_7.Unit[1] != null && tile_7.Unit[2] != null)
                        anypush.GetComponent<UnitSpawnBtn>().btnanyclick = false;//타일이 꽉차있는 상태에서 눌렀다면 버튼 활성화(false)해줌
                    else
                    
                        anypush.GetComponent<UnitSpawnBtn>().btnanyclick = true;// 타일이 눌렸다면 버튼 비활성화(true)해줌
                    
                    if (tile_7.Unit[0] == null)
                    {
                        tile_7.Unit[0] = unit_[sel_btn];
                        unit_[sel_btn].transform.position = first;
                        unit[0] = unit_[sel_btn].GetComponent<Unit>(); // 해당 PlayerPrefs에서 해당 이름의 유닛 가져옴 (예정)
                        unit[0].Current_Tile = tile_7; // 해당 유닛의 Current_Tile에 타일 연결
                        unit[0].Current_Location = tile_unit_po[0]; // 해당 유닛의 Current_Location에 게임 오브젝트 연결
                        unit[0].Current_Location_number = "1"; // 해당 유닛의 Current_Location_number 변경
                        unit_[sel_btn].transform.SetParent(GameManager.Instance.Units.transform); //해당 unit의 부모를 인벤에서 Unit으로 변경
                    }
                    else if (tile_7.Unit[1] == null)
                    {
                        tile_7.Unit[1] = unit_[sel_btn];
                        unit_[sel_btn].transform.position = second;
                        unit[1] = unit_[sel_btn].GetComponent<Unit>(); // 해당 PlayerPrefs에서 해당 이름의 유닛 가져옴 (예정)
                        unit[1].Current_Tile = tile_7; // 해당 유닛의 Current_Tile에 타일 연결
                        unit[1].Current_Location = tile_unit_po[1]; // 해당 유닛의 Current_Location에 게임 오브젝트 연결
                        unit[1].Current_Location_number = "2"; // 해당 유닛의 Current_Location_number 변경
                        unit_[sel_btn].transform.SetParent(GameManager.Instance.Units.transform); //해당 unit의 부모를 인벤에서 Unit으로 변경
                    }
                    else if (tile_7.Unit[2] == null)
                    {
                        tile_7.Unit[2] = unit_[sel_btn];
                        unit_[sel_btn].transform.position = third;
                        unit[2] = unit_[sel_btn].GetComponent<Unit>(); // 해당 PlayerPrefs에서 해당 이름의 유닛 가져옴 (예정)
                        unit[2].Current_Tile = tile_7; // 해당 유닛의 Current_Tile에 타일 연결
                        unit[2].Current_Location = tile_unit_po[2]; // 해당 유닛의 Current_Location에 게임 오브젝트 연결
                        unit[2].Current_Location_number = "3"; // 해당 유닛의 Current_Location_number 변경
                        unit_[sel_btn].transform.SetParent(GameManager.Instance.Units.transform); //해당 unit의 부모를 인벤에서 Unit으로 변경
                    }
                   
                }//7번 타일
                
                else if (hit.transform.gameObject.name == tile_6.name) //Raycast가 타일에 맞았다면
                {
                    tile_po = hit.collider.gameObject;//Ray 가져옴
                    GameObject [] tile_unit_po = new GameObject[3];// Tile 스크립트의 Unit_po 배열을 가져오기 위함
                    tile_unit_po[0] = tile_po.GetComponent<Tile>().Unit_po[0];
                    tile_unit_po[1] = tile_po.GetComponent<Tile>().Unit_po[1];
                    tile_unit_po[2] = tile_po.GetComponent<Tile>().Unit_po[2];
                    Vector3 first = tile_unit_po[0].transform.position; // 첫번쨰 위치
                    Vector3 second = tile_unit_po[1].transform.position; // 두번째 위치
                    Vector3 third = tile_unit_po[2].transform.position;// 세번째 위치
                    
                    Unit [] unit = new Unit[3]; //유닛 스크립트 사용을 위해 지역 변수 선언
                    
                    if (tile_6.Unit[0] != null && tile_6.Unit[1] != null && tile_6.Unit[2] != null)
                        anypush.GetComponent<UnitSpawnBtn>().btnanyclick = false;//타일이 꽉차있는 상태에서 눌렀다면 버튼 활성화(false)해줌
                    else
                    
                        anypush.GetComponent<UnitSpawnBtn>().btnanyclick = true;// 타일이 눌렸다면 버튼 비활성화(true)해줌
                    
                    if (tile_6.Unit[0] == null)
                    {
                        tile_6.Unit[0] = unit_[sel_btn];
                        unit_[sel_btn].transform.position = first;
                        unit[0] = unit_[sel_btn].GetComponent<Unit>(); // 해당 PlayerPrefs에서 해당 이름의 유닛 가져옴 (예정)
                        unit[0].Current_Tile = tile_6; // 해당 유닛의 Current_Tile에 타일 연결
                        unit[0].Current_Location = tile_unit_po[0]; // 해당 유닛의 Current_Location에 게임 오브젝트 연결
                        unit[0].Current_Location_number = "1"; // 해당 유닛의 Current_Location_number 변경
                        unit_[sel_btn].transform.SetParent(GameManager.Instance.Units.transform); //해당 unit의 부모를 인벤에서 Unit으로 변경
                    }
                    else if (tile_6.Unit[1] == null)
                    {
                        tile_6.Unit[1] = unit_[sel_btn];
                        unit_[sel_btn].transform.position = second;
                        unit[1] = unit_[sel_btn].GetComponent<Unit>(); // 해당 PlayerPrefs에서 해당 이름의 유닛 가져옴 (예정)
                        unit[1].Current_Tile = tile_6; // 해당 유닛의 Current_Tile에 타일 연결
                        unit[1].Current_Location = tile_unit_po[1]; // 해당 유닛의 Current_Location에 게임 오브젝트 연결
                        unit[1].Current_Location_number = "2"; // 해당 유닛의 Current_Location_number 변경
                        unit_[sel_btn].transform.SetParent(GameManager.Instance.Units.transform); //해당 unit의 부모를 인벤에서 Unit으로 변경
                    }
                    else if (tile_6.Unit[2] == null)
                    {
                        tile_6.Unit[2] = unit_[sel_btn];
                        unit_[sel_btn].transform.position = third;
                        unit[2] = unit_[sel_btn].GetComponent<Unit>(); // 해당 PlayerPrefs에서 해당 이름의 유닛 가져옴 (예정)
                        unit[2].Current_Tile = tile_6; // 해당 유닛의 Current_Tile에 타일 연결
                        unit[2].Current_Location = tile_unit_po[2]; // 해당 유닛의 Current_Location에 게임 오브젝트 연결
                        unit[2].Current_Location_number = "3"; // 해당 유닛의 Current_Location_number 변경
                        unit_[sel_btn].transform.SetParent(GameManager.Instance.Units.transform); //해당 unit의 부모를 인벤에서 Unit으로 변경
                    }
                
                }//6번 타일
                
                else if (hit.transform.gameObject.name == tile_5.name) //Raycast가 타일에 맞았다면
                {
                    tile_po = hit.collider.gameObject;//Ray 가져옴
                    GameObject [] tile_unit_po = new GameObject[3];// Tile 스크립트의 Unit_po 배열을 가져오기 위함
                    tile_unit_po[0] = tile_po.GetComponent<Tile>().Unit_po[0];
                    tile_unit_po[1] = tile_po.GetComponent<Tile>().Unit_po[1];
                    tile_unit_po[2] = tile_po.GetComponent<Tile>().Unit_po[2];
                    Vector3 first = tile_unit_po[0].transform.position; // 첫번쨰 위치
                    Vector3 second = tile_unit_po[1].transform.position; // 두번째 위치
                    Vector3 third = tile_unit_po[2].transform.position;// 세번째 위치
                    
                    Unit [] unit = new Unit[3]; //유닛 스크립트 사용을 위해 지역 변수 선언
                    
                    if (tile_5.Unit[0] != null && tile_5.Unit[1] != null && tile_5.Unit[2] != null)
                        anypush.GetComponent<UnitSpawnBtn>().btnanyclick = false;//타일이 꽉차있는 상태에서 눌렀다면 버튼 활성화(false)해줌
                    else
                    
                        anypush.GetComponent<UnitSpawnBtn>().btnanyclick = true;// 타일이 눌렸다면 버튼 비활성화(true)해줌
                    
                    if (tile_5.Unit[0] == null)
                    {
                        tile_5.Unit[0] = unit_[sel_btn];
                        unit_[sel_btn].transform.position = first;
                        unit[0] = unit_[sel_btn].GetComponent<Unit>(); // 해당 PlayerPrefs에서 해당 이름의 유닛 가져옴 (예정)
                        unit[0].Current_Tile = tile_5; // 해당 유닛의 Current_Tile에 타일 연결
                        unit[0].Current_Location = tile_unit_po[0]; // 해당 유닛의 Current_Location에 게임 오브젝트 연결
                        unit[0].Current_Location_number = "1"; // 해당 유닛의 Current_Location_number 변경
                        unit_[sel_btn].transform.SetParent(GameManager.Instance.Units.transform); //해당 unit의 부모를 인벤에서 Unit으로 변경
                    }
                    else if (tile_5.Unit[1] == null)
                    {
                        tile_5.Unit[1] = unit_[sel_btn];
                        unit_[sel_btn].transform.position = second;
                        unit[1] = unit_[sel_btn].GetComponent<Unit>(); // 해당 PlayerPrefs에서 해당 이름의 유닛 가져옴 (예정)
                        unit[1].Current_Tile = tile_5; // 해당 유닛의 Current_Tile에 타일 연결
                        unit[1].Current_Location = tile_unit_po[1]; // 해당 유닛의 Current_Location에 게임 오브젝트 연결
                        unit[1].Current_Location_number = "2"; // 해당 유닛의 Current_Location_number 변경
                        unit_[sel_btn].transform.SetParent(GameManager.Instance.Units.transform); //해당 unit의 부모를 인벤에서 Unit으로 변경
                    }
                    else if (tile_5.Unit[2] == null)
                    {
                        tile_5.Unit[2] = unit_[sel_btn];
                        unit_[sel_btn].transform.position = third;
                        unit[2] = unit_[sel_btn].GetComponent<Unit>(); // 해당 PlayerPrefs에서 해당 이름의 유닛 가져옴 (예정)
                        unit[2].Current_Tile = tile_5; // 해당 유닛의 Current_Tile에 타일 연결
                        unit[2].Current_Location = tile_unit_po[2]; // 해당 유닛의 Current_Location에 게임 오브젝트 연결
                        unit[2].Current_Location_number = "3"; // 해당 유닛의 Current_Location_number 변경
                        unit_[sel_btn].transform.SetParent(GameManager.Instance.Units.transform); //해당 unit의 부모를 인벤에서 Unit으로 변경
                    }
                    
                }//5번 타일
                
                else if (hit.transform.gameObject.name == tile_4.name) //Raycast가 타일에 맞았다면
                {
                    tile_po = hit.collider.gameObject;//Ray 가져옴
                    GameObject [] tile_unit_po = new GameObject[3];// Tile 스크립트의 Unit_po 배열을 가져오기 위함
                    tile_unit_po[0] = tile_po.GetComponent<Tile>().Unit_po[0];
                    tile_unit_po[1] = tile_po.GetComponent<Tile>().Unit_po[1];
                    tile_unit_po[2] = tile_po.GetComponent<Tile>().Unit_po[2];
                    Vector3 first = tile_unit_po[0].transform.position; // 첫번쨰 위치
                    Vector3 second = tile_unit_po[1].transform.position; // 두번째 위치
                    Vector3 third = tile_unit_po[2].transform.position;// 세번째 위치
                    
                    Unit [] unit = new Unit[3]; //유닛 스크립트 사용을 위해 지역 변수 선언
                    
                    if (tile_4.Unit[0] != null && tile_4.Unit[1] != null && tile_4.Unit[2] != null)
                        anypush.GetComponent<UnitSpawnBtn>().btnanyclick = false;//타일이 꽉차있는 상태에서 눌렀다면 버튼 활성화(false)해줌
                    else
                    
                        anypush.GetComponent<UnitSpawnBtn>().btnanyclick = true;// 타일이 눌렸다면 버튼 비활성화(true)해줌
                    
                    if (tile_4.Unit[0] == null)
                    {
                        tile_4.Unit[0] = unit_[sel_btn];
                        unit_[sel_btn].transform.position = first;
                        unit[0] = unit_[sel_btn].GetComponent<Unit>(); // 해당 PlayerPrefs에서 해당 이름의 유닛 가져옴 (예정)
                        unit[0].Current_Tile = tile_4; // 해당 유닛의 Current_Tile에 타일 연결
                        unit[0].Current_Location = tile_unit_po[0]; // 해당 유닛의 Current_Location에 게임 오브젝트 연결
                        unit[0].Current_Location_number = "1"; // 해당 유닛의 Current_Location_number 변경
                        unit_[sel_btn].transform.SetParent(GameManager.Instance.Units.transform); //해당 unit의 부모를 인벤에서 Unit으로 변경
                    }
                    else if (tile_4.Unit[1] == null)
                    {
                        tile_4.Unit[1] = unit_[sel_btn];
                        unit_[sel_btn].transform.position = second;
                        unit[1] = unit_[sel_btn].GetComponent<Unit>(); // 해당 PlayerPrefs에서 해당 이름의 유닛 가져옴 (예정)
                        unit[1].Current_Tile = tile_4; // 해당 유닛의 Current_Tile에 타일 연결
                        unit[1].Current_Location = tile_unit_po[1]; // 해당 유닛의 Current_Location에 게임 오브젝트 연결
                        unit[1].Current_Location_number = "2"; // 해당 유닛의 Current_Location_number 변경
                        unit_[sel_btn].transform.SetParent(GameManager.Instance.Units.transform); //해당 unit의 부모를 인벤에서 Unit으로 변경
                    }
                    else if (tile_4.Unit[2] == null)
                    {
                        tile_4.Unit[2] = unit_[sel_btn];
                        unit_[sel_btn].transform.position = third;
                        unit[2] = unit_[sel_btn].GetComponent<Unit>(); // 해당 PlayerPrefs에서 해당 이름의 유닛 가져옴 (예정)
                        unit[2].Current_Tile = tile_4; // 해당 유닛의 Current_Tile에 타일 연결
                        unit[2].Current_Location = tile_unit_po[2]; // 해당 유닛의 Current_Location에 게임 오브젝트 연결
                        unit[2].Current_Location_number = "3"; // 해당 유닛의 Current_Location_number 변경
                        unit_[sel_btn].transform.SetParent(GameManager.Instance.Units.transform); //해당 unit의 부모를 인벤에서 Unit으로 변경
                    }
                
                }//4번 타일
                
                else if (hit.transform.gameObject.name == tile_3.name) //Raycast가 타일에 맞았다면
                {
                    tile_po = hit.collider.gameObject;//Ray 가져옴
                    GameObject [] tile_unit_po = new GameObject[3];// Tile 스크립트의 Unit_po 배열을 가져오기 위함
                    tile_unit_po[0] = tile_po.GetComponent<Tile>().Unit_po[0];
                    tile_unit_po[1] = tile_po.GetComponent<Tile>().Unit_po[1];
                    tile_unit_po[2] = tile_po.GetComponent<Tile>().Unit_po[2];
                    Vector3 first = tile_unit_po[0].transform.position; // 첫번쨰 위치
                    Vector3 second = tile_unit_po[1].transform.position; // 두번째 위치
                    Vector3 third = tile_unit_po[2].transform.position;// 세번째 위치
                    
                    Unit [] unit = new Unit[3]; //유닛 스크립트 사용을 위해 지역 변수 선언
                    
                    if (tile_3.Unit[0] != null && tile_3.Unit[1] != null && tile_3.Unit[2] != null)
                        anypush.GetComponent<UnitSpawnBtn>().btnanyclick = false;//타일이 꽉차있는 상태에서 눌렀다면 버튼 활성화(false)해줌
                    else
                    
                        anypush.GetComponent<UnitSpawnBtn>().btnanyclick = true;// 타일이 눌렸다면 버튼 비활성화(true)해줌
                    
                    if (tile_3.Unit[0] == null)
                    {
                        tile_3.Unit[0] = unit_[sel_btn];
                        unit_[sel_btn].transform.position = first;
                        unit[0] = unit_[sel_btn].GetComponent<Unit>(); // 해당 PlayerPrefs에서 해당 이름의 유닛 가져옴 (예정)
                        unit[0].Current_Tile = tile_3; // 해당 유닛의 Current_Tile에 타일 연결
                        unit[0].Current_Location = tile_unit_po[0]; // 해당 유닛의 Current_Location에 게임 오브젝트 연결
                        unit[0].Current_Location_number = "1"; // 해당 유닛의 Current_Location_number 변경
                        unit_[sel_btn].transform.SetParent(GameManager.Instance.Units.transform); //해당 unit의 부모를 인벤에서 Unit으로 변경
                    }
                    else if (tile_3.Unit[1] == null)
                    {
                        tile_3.Unit[1] = unit_[sel_btn];
                        unit_[sel_btn].transform.position = second;
                        unit[1] = unit_[sel_btn].GetComponent<Unit>(); // 해당 PlayerPrefs에서 해당 이름의 유닛 가져옴 (예정)
                        unit[1].Current_Tile = tile_3; // 해당 유닛의 Current_Tile에 타일 연결
                        unit[1].Current_Location = tile_unit_po[1]; // 해당 유닛의 Current_Location에 게임 오브젝트 연결
                        unit[1].Current_Location_number = "2"; // 해당 유닛의 Current_Location_number 변경
                        unit_[sel_btn].transform.SetParent(GameManager.Instance.Units.transform); //해당 unit의 부모를 인벤에서 Unit으로 변경
                    }
                    else if (tile_3.Unit[2] == null)
                    {
                        tile_3.Unit[2] = unit_[sel_btn];
                        unit_[sel_btn].transform.position = third;
                        unit[2] = unit_[sel_btn].GetComponent<Unit>(); // 해당 PlayerPrefs에서 해당 이름의 유닛 가져옴 (예정)
                        unit[2].Current_Tile = tile_3; // 해당 유닛의 Current_Tile에 타일 연결
                        unit[2].Current_Location = tile_unit_po[2]; // 해당 유닛의 Current_Location에 게임 오브젝트 연결
                        unit[2].Current_Location_number = "3"; // 해당 유닛의 Current_Location_number 변경
                        unit_[sel_btn].transform.SetParent(GameManager.Instance.Units.transform); //해당 unit의 부모를 인벤에서 Unit으로 변경
                    }
                    
                }//3번 타일
                
                else if (hit.transform.gameObject.name == tile_2.name) //Raycast가 타일에 맞았다면
                {
                    tile_po = hit.collider.gameObject;//Ray 가져옴
                    GameObject [] tile_unit_po = new GameObject[3];// Tile 스크립트의 Unit_po 배열을 가져오기 위함
                    tile_unit_po[0] = tile_po.GetComponent<Tile>().Unit_po[0];
                    tile_unit_po[1] = tile_po.GetComponent<Tile>().Unit_po[1];
                    tile_unit_po[2] = tile_po.GetComponent<Tile>().Unit_po[2];
                    Vector3 first = tile_unit_po[0].transform.position; // 첫번쨰 위치
                    Vector3 second = tile_unit_po[1].transform.position; // 두번째 위치
                    Vector3 third = tile_unit_po[2].transform.position;// 세번째 위치
                    
                    Unit [] unit = new Unit[3]; //유닛 스크립트 사용을 위해 지역 변수 선언
                    
                    if (tile_2.Unit[0] != null && tile_2.Unit[1] != null && tile_2.Unit[2] != null)
                        anypush.GetComponent<UnitSpawnBtn>().btnanyclick = false;//타일이 꽉차있는 상태에서 눌렀다면 버튼 활성화(false)해줌
                    else
                    
                        anypush.GetComponent<UnitSpawnBtn>().btnanyclick = true;// 타일이 눌렸다면 버튼 비활성화(true)해줌
                    
                    if (tile_2.Unit[0] == null)
                    {
                        tile_2.Unit[0] = unit_[sel_btn];
                        unit_[sel_btn].transform.position = first;
                        unit[0] = unit_[sel_btn].GetComponent<Unit>(); // 해당 PlayerPrefs에서 해당 이름의 유닛 가져옴 (예정)
                        unit[0].Current_Tile = tile_2; // 해당 유닛의 Current_Tile에 타일 연결
                        unit[0].Current_Location = tile_unit_po[0]; // 해당 유닛의 Current_Location에 게임 오브젝트 연결
                        unit[0].Current_Location_number = "1"; // 해당 유닛의 Current_Location_number 변경
                        unit_[sel_btn].transform.SetParent(GameManager.Instance.Units.transform); //해당 unit의 부모를 인벤에서 Unit으로 변경
                    }
                    else if (tile_2.Unit[1] == null)
                    {
                        tile_2.Unit[1] = unit_[sel_btn];
                        unit_[sel_btn].transform.position = second;
                        unit[1] = unit_[sel_btn].GetComponent<Unit>(); // 해당 PlayerPrefs에서 해당 이름의 유닛 가져옴 (예정)
                        unit[1].Current_Tile = tile_2; // 해당 유닛의 Current_Tile에 타일 연결
                        unit[1].Current_Location = tile_unit_po[1]; // 해당 유닛의 Current_Location에 게임 오브젝트 연결
                        unit[1].Current_Location_number = "2"; // 해당 유닛의 Current_Location_number 변경
                        unit_[sel_btn].transform.SetParent(GameManager.Instance.Units.transform); //해당 unit의 부모를 인벤에서 Unit으로 변경
                    }
                    else if (tile_2.Unit[2] == null)
                    {
                        tile_2.Unit[2] = unit_[sel_btn];
                        unit_[sel_btn].transform.position = third;
                        unit[2] = unit_[sel_btn].GetComponent<Unit>(); // 해당 PlayerPrefs에서 해당 이름의 유닛 가져옴 (예정)
                        unit[2].Current_Tile = tile_2; // 해당 유닛의 Current_Tile에 타일 연결
                        unit[2].Current_Location = tile_unit_po[2]; // 해당 유닛의 Current_Location에 게임 오브젝트 연결
                        unit[2].Current_Location_number = "3"; // 해당 유닛의 Current_Location_number 변경
                        unit_[sel_btn].transform.SetParent(GameManager.Instance.Units.transform); //해당 unit의 부모를 인벤에서 Unit으로 변경
                    }
                   
                }//2번 타일
                
                else if (hit.transform.gameObject.name == tile_1.name) //Raycast가 타일에 맞았다면
                {
                    tile_po = hit.collider.gameObject;//Ray 가져옴
                    GameObject [] tile_unit_po = new GameObject[3];// Tile 스크립트의 Unit_po 배열을 가져오기 위함
                    tile_unit_po[0] = tile_po.GetComponent<Tile>().Unit_po[0];
                    tile_unit_po[1] = tile_po.GetComponent<Tile>().Unit_po[1];
                    tile_unit_po[2] = tile_po.GetComponent<Tile>().Unit_po[2];
                    Vector3 first = tile_unit_po[0].transform.position; // 첫번쨰 위치
                    Vector3 second = tile_unit_po[1].transform.position; // 두번째 위치
                    Vector3 third = tile_unit_po[2].transform.position;// 세번째 위치
                    
                    Unit [] unit = new Unit[3]; //유닛 스크립트 사용을 위해 지역 변수 선언
                    
                    if (tile_1.Unit[0] != null && tile_1.Unit[1] != null && tile_1.Unit[2] != null)
                        anypush.GetComponent<UnitSpawnBtn>().btnanyclick = false;//타일이 꽉차있는 상태에서 눌렀다면 버튼 활성화(false)해줌
                    else
                    
                        anypush.GetComponent<UnitSpawnBtn>().btnanyclick = true;// 타일이 눌렸다면 버튼 비활성화(true)해줌
                    
                    if (tile_1.Unit[0] == null)
                    {
                        tile_1.Unit[0] = unit_[sel_btn];
                        unit_[sel_btn].transform.position = first;
                        unit[0] = unit_[sel_btn].GetComponent<Unit>(); // 해당 PlayerPrefs에서 해당 이름의 유닛 가져옴 (예정)
                        unit[0].Current_Tile = tile_1; // 해당 유닛의 Current_Tile에 타일 연결
                        unit[0].Current_Location = tile_unit_po[0]; // 해당 유닛의 Current_Location에 게임 오브젝트 연결
                        unit[0].Current_Location_number = "1"; // 해당 유닛의 Current_Location_number 변경
                        unit_[sel_btn].transform.SetParent(GameManager.Instance.Units.transform); //해당 unit의 부모를 인벤에서 Unit으로 변경
                    }
                    else if (tile_1.Unit[1] == null)
                    {
                        tile_1.Unit[1] = unit_[sel_btn];
                        unit_[sel_btn].transform.position = second;
                        unit[1] = unit_[sel_btn].GetComponent<Unit>(); // 해당 PlayerPrefs에서 해당 이름의 유닛 가져옴 (예정)
                        unit[1].Current_Tile = tile_1; // 해당 유닛의 Current_Tile에 타일 연결
                        unit[1].Current_Location = tile_unit_po[1]; // 해당 유닛의 Current_Location에 게임 오브젝트 연결
                        unit[1].Current_Location_number = "2"; // 해당 유닛의 Current_Location_number 변경
                        unit_[sel_btn].transform.SetParent(GameManager.Instance.Units.transform); //해당 unit의 부모를 인벤에서 Unit으로 변경
                    }
                    else if (tile_1.Unit[2] == null)
                    {
                        tile_1.Unit[2] = unit_[sel_btn];
                        unit_[sel_btn].transform.position = third;
                        unit[2] = unit_[sel_btn].GetComponent<Unit>(); // 해당 PlayerPrefs에서 해당 이름의 유닛 가져옴 (예정)
                        unit[2].Current_Tile = tile_1; // 해당 유닛의 Current_Tile에 타일 연결
                        unit[2].Current_Location = tile_unit_po[2]; // 해당 유닛의 Current_Location에 게임 오브젝트 연결
                        unit[2].Current_Location_number = "3"; // 해당 유닛의 Current_Location_number 변경
                        unit_[sel_btn].transform.SetParent(GameManager.Instance.Units.transform); //해당 unit의 부모를 인벤에서 Unit으로 변경
                    }
                
                }//1번 타일
                
                 else if (hit.transform.gameObject.name == tile_0.name) //Raycast가 타일에 맞았다면
                {
                    tile_po = hit.collider.gameObject;//Ray 가져옴
                    GameObject [] tile_unit_po = new GameObject[3];// Tile 스크립트의 Unit_po 배열을 가져오기 위함
                    tile_unit_po[0] = tile_po.GetComponent<Tile>().Unit_po[0];
                    tile_unit_po[1] = tile_po.GetComponent<Tile>().Unit_po[1];
                    tile_unit_po[2] = tile_po.GetComponent<Tile>().Unit_po[2];
                    Vector3 first = tile_unit_po[0].transform.position; // 첫번쨰 위치
                    Vector3 second = tile_unit_po[1].transform.position; // 두번째 위치
                    Vector3 third = tile_unit_po[2].transform.position;// 세번째 위치
                    
                    Unit [] unit = new Unit[3]; //유닛 스크립트 사용을 위해 지역 변수 선언
                    
                    if (tile_0.Unit[0] != null && tile_0.Unit[1] != null && tile_0.Unit[2] != null)
                        anypush.GetComponent<UnitSpawnBtn>().btnanyclick = false;//타일이 꽉차있는 상태에서 눌렀다면 버튼 활성화(false)해줌
                    else
                    
                        anypush.GetComponent<UnitSpawnBtn>().btnanyclick = true;// 타일이 눌렸다면 버튼 비활성화(true)해줌
                    
                    if (tile_0.Unit[0] == null)
                    {
                        tile_0.Unit[0] = unit_[sel_btn];
                        unit_[sel_btn].transform.position = first;
                        unit[0] = unit_[sel_btn].GetComponent<Unit>(); // 해당 PlayerPrefs에서 해당 이름의 유닛 가져옴 (예정)
                        unit[0].Current_Tile = tile_0; // 해당 유닛의 Current_Tile에 타일 연결
                        unit[0].Current_Location = tile_unit_po[0]; // 해당 유닛의 Current_Location에 게임 오브젝트 연결
                        unit[0].Current_Location_number = "1"; // 해당 유닛의 Current_Location_number 변경
                        unit_[sel_btn].transform.SetParent(GameManager.Instance.Units.transform); //해당 unit의 부모를 인벤에서 Unit으로 변경
                    }
                    else if (tile_0.Unit[1] == null)
                    {
                        tile_0.Unit[1] = unit_[sel_btn];
                        unit_[sel_btn].transform.position = second;
                        unit[1] = unit_[sel_btn].GetComponent<Unit>(); // 해당 PlayerPrefs에서 해당 이름의 유닛 가져옴 (예정)
                        unit[1].Current_Tile = tile_0; // 해당 유닛의 Current_Tile에 타일 연결
                        unit[1].Current_Location = tile_unit_po[1]; // 해당 유닛의 Current_Location에 게임 오브젝트 연결
                        unit[1].Current_Location_number = "2"; // 해당 유닛의 Current_Location_number 변경
                        unit_[sel_btn].transform.SetParent(GameManager.Instance.Units.transform); //해당 unit의 부모를 인벤에서 Unit으로 변경
                    }
                    else if (tile_0.Unit[2] == null)
                    {
                        tile_0.Unit[2] = unit_[sel_btn];
                        unit_[sel_btn].transform.position = third;
                        unit[2] = unit_[sel_btn].GetComponent<Unit>(); // 해당 PlayerPrefs에서 해당 이름의 유닛 가져옴 (예정)
                        unit[2].Current_Tile = tile_0; // 해당 유닛의 Current_Tile에 타일 연결
                        unit[2].Current_Location = tile_unit_po[2]; // 해당 유닛의 Current_Location에 게임 오브젝트 연결
                        unit[2].Current_Location_number = "3"; // 해당 유닛의 Current_Location_number 변경
                        unit_[sel_btn].transform.SetParent(GameManager.Instance.Units.transform); //해당 unit의 부모를 인벤에서 Unit으로 변경
                    }
                   
                }//0번 타일
                
                anypush = null;// 다른 버튼에서도 사용을 위해 비워줌
                
            }
            
        }
        
        Hero.transform.SetAsLastSibling();//영웅유닛 추가시 유닛 태그 값으로 변경할 예정
        
    }
    
}
