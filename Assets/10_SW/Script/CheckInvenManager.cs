using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AllEnum;


public class CheckInvenManager : MonoBehaviour
{
    // 이 스크립트는 이미 PlayerPrefs에 값이 존재한다는 것을 가정하에 작동합니다.
    // 테스트용으로 Awake에 PlayerPrefs를 생성하는 내용을 넣을 수 있습니다. (어디까지나 테스트용, 사용하지 않아도 괜찮, 할 수 있다는 의미.)

    public struct UnitDataClassification
    {
        public bool isEmpty; // 구조체가 비어있는지 판단. 삭제 된다면 없다는 것을 알려줘야 하니까 만듦.
        // Load한 유닛들의 모든 정보를 변수로 저장하기 위해서 필요한 구조체
        public int code; // 유닛을 구분(식별)하기 위한 ID
        public string name; // 유닛의 이름
        public Sprite[] sprite; // 유닛의 이미지
        public int grade; // 유닛의 등급
        public string descript; // 유닛의 설명
        public int maxHp; // 유닛의 최대 생명력
        public int hp; //유닛의 생명력
        public int atk; //유닛의 공격력
        public int def; //유닛의 방어력
        public int atkSp; //유닛의 공격 속도
        public int tile; // 유닛의 배치된 타일번호
        public int location; //유닛의 타일에서의 추가 위치값
        public int price; // 유닛의 가격
    }

    public UnitInfo[] allUnitSO; // 게임 내에서 사용하는 모든 Unit 의 Scriptable Object 변수
    public GameObject[] inventory = new GameObject[10]; // 게임 내의 인벤토리 (10칸)
    public GameObject showingData;  // 데이터를 보여주는 UI 및 상호 작용 Button.
    public GameObject pageText; // 현재 페이지를 알려주는 텍스트 오브젝트;
    public int selectedButtonNumber = 0; // 현재 선택된 버튼이 몇번째 버튼인지 알려주는 변수. (해당 변수를 통해서, 선택한 데이터의 정보를 확인할 수 있음.)
    public int pageNumber = 1;  // 현재 Page Number를 알려주는 변수

    private const int MAX_NAME_ENUM = 5;
    private const int MAX_ATTRIBUTE_ENUM = 9;

    //Inventory Local Data Manager를 담당함.
    #region
    private static UnitDataClassification[] in_UDC = new UnitDataClassification[100]; // 유닛 100개 데이터
    /// <summary>
    /// 유닛 100개, 10개당 1Page. [10][10]과 동일함.
    /// </summary>
    public UnitDataClassification[] out_UDC
    {
        get
        {
            return in_UDC;
        }
        set
        {
            in_UDC = value;
        }
    }

    #endregion


    public void OnEnable()
    {
        LoadUnitDataClassification();
        InventoryRefresh();
    }

    // 인벤토리는 한 페이지당 10개로 한정.
    // 처음 게임 시작하고 난 다음에, 딱 1번만 실행된다.
    // 인벤토리 데이터가 있다면 불러오고, 없다면 0 값으로 새롭게 생성한다.
    // 100개의 인벤토리 데이터를 한 번에 불러들인다.

    // 쪼개진 유닛의 데이터를 읽어들여서, 하나의 유닛 데이터로 합성시켜서 로컬 데이터(out_UDC)로 저장
    public void LoadUnitDataClassification()
    {
        // 인벤토리 1~100까지 작동 (만약에 값이 비어있다면, 멈춤. 100이전에 멈춘다는 의미)
        // 해당 반복문 작동 방식
        // 1. 최대 100개의 인벤토리 데이터를 읽어들인다.
        // 2. 시작값을 지정한다. (nameCount = 0) (unitEachCount = 1) (attributeCount = 0)
        // 3. 내부의 반복문은 attribute 값을 전부 읽어들이는 반복문이다. (attributeCount는 0~8 까지)
        // 4. 한번 attribute를 전부 읽어들이면, 해당 name은 그대로 유지한 상태로 unitEachCount만 늘린다. (nameCount는 0~4까지)
        // 5. 해당 유닛의 unitEachCount가 끝(100)에 도달하면, nameCount를 1 올리고 unitEachCount를 0으로 만든다.
        // 6. nameCount가 끝에 도달하면, 더이상 조사할 대상이 없다는 뜻이 된다.
        int nameCount = 0; // 현재 검색하고 있는 대상의 이름 (AllEnum.Name 을 뜻함)
        int unitEachCount = 1; // 유닛1 유닛2 라는 이름이 있을 때, 그 뒤의 숫자 (1, 2 ...)를 뜻함
        for (int invenCount = 0; invenCount < 100;)
        {
            // attributeCount는 현재 검색하고 있는 대상의 속성 (AllEnum.Attribute 를 뜻함)
            for (int attributeCount = 0; attributeCount < MAX_ATTRIBUTE_ENUM; attributeCount++)
            {
                // 해당 조건문을 읽으면 다음과 같다.
                // Unit_(UnitName의 nameCount에 있는 이름)_(UnitAttribute의 attributeCount에 있는 이름)_(해당 유닛의 동명이인을 구분하는 unitEachCount 값)
                // ex)) Unit_용병전사_code_1 <- 이런식으로 나올 수 있음.
                // willSearchString은 앞으로 검색하게 될 Key의 이름(PlayerPrefs 기준, Key를 뜻함)
                string willSearchString = "unit_" + Enum.GetName(typeof(UnitName), nameCount) + "_" + Enum.GetName(typeof(UnitAttribute), attributeCount) + "_" + unitEachCount;
                if (PlayerPrefs.HasKey(willSearchString))
                {
                    // attributeCount 값에 따라서, 어떤 속성 값을 대입해야 되는지 알 수 있다.
                    switch (attributeCount)
                    {
                        case 0:
                            in_UDC[invenCount].code = PlayerPrefs.GetInt(willSearchString);
                            in_UDC[invenCount].sprite = allUnitSO[nameCount].BasedSprite; // 한번만 넣는 경우인데, 어디에 넣어야 할지 몰라서 일단 0번 코드를 넣을 때에 같이 들어가게끔 해놓음.
                            in_UDC[invenCount].name = Enum.GetName(typeof(UnitName), nameCount);
                            in_UDC[invenCount].isEmpty = false; // 내부 데이터가 비어있지 않다고 표현함.
                            break;
                        case 1:
                            in_UDC[invenCount].grade = PlayerPrefs.GetInt(willSearchString);
                            break;
                        case 2:
                            in_UDC[invenCount].hp = PlayerPrefs.GetInt(willSearchString);
                            break;
                        case 3:
                            in_UDC[invenCount].maxHp = PlayerPrefs.GetInt(willSearchString);
                            break;
                        case 4:
                            in_UDC[invenCount].atk = PlayerPrefs.GetInt(willSearchString);
                            break;
                        case 5:
                            in_UDC[invenCount].def = PlayerPrefs.GetInt(willSearchString);
                            break;
                        case 6:
                            in_UDC[invenCount].atkSp = PlayerPrefs.GetInt(willSearchString);
                            break;
                        case 7:
                            in_UDC[invenCount].tile = PlayerPrefs.GetInt(willSearchString);
                            break;
                        case 8:
                            in_UDC[invenCount].location = PlayerPrefs.GetInt(willSearchString);
                            invenCount++; // 해당 데이터가 성공적으로 저장되었다는 것을 의미하며, 다음 인벤토리 창에 값을 넣으라는 의미이기도 함. 마지막 값을 넣는 타이밍.
                            break;
                    }
                }
                else
                {
                    break;  // Unit_유닛이름_속성_숫자 의 값이 존재하지 않는다면, 바로 break 넘어감.
                }
            }
            unitEachCount++; // 이전 유닛은 이미 데이터를 읽어들였으니까. 새로운 데이터를 읽어들이기 위해서 unitEachCount를 먼저 올린다. (무조건 100까지 검사)
            // 만약에, unit100까지 도달했다면? 이제 nameCount를 올려서 다음 유닛을 검색하라는 의미가 됨.
            if (unitEachCount == 100)
            {
                nameCount++; // AllEnum.Name의 0번째 대상이 끝났으면 ++해줘서 다음 대상을 검색하게끔 만듦.
                unitEachCount = 1; // 유닛1 부터 다시 검색하라는 의미라서, 1로 지정. (1~100 -> 다시 1~ 100 .. 총 MAX_NAME_ENUM번 반복하게 됨)
                // 유닛 Enum의 최대 종류까지 확인했다면, 반복문을 그만두도록 하는 조건문
                if (nameCount == MAX_NAME_ENUM)
                {
                    for (int insertEmptyUDC = invenCount; insertEmptyUDC < 100; insertEmptyUDC++)
                    {
                        in_UDC[insertEmptyUDC].isEmpty = true;
                    }
                    break; // break는 모든 조건문을 뚫고, 가장 가까운 반복문을 벗어난다.
                }
            }
        }
    }

    // Page 버튼을 눌렀거나, 데이터 변경이 있었을 때 Refresh 해주는 메서드
    public void InventoryRefresh()
    {
        for (int countOrder = 0; countOrder < 10; countOrder++)
        {
            //inventory로 지정된 버튼의 이미지와 이름을 변경해주는 내용.
            if (in_UDC[(pageNumber - 1) * 10 + countOrder].isEmpty == false)
            {
                // in_UDC의 isEmpty가 False 라면, 값이 있다는 뜻이니까? 해당 조건문을 수행할 수 있다.
                // pageNumber는 1부터 시작하니까, (pageNumber - 1)을 사용함
                inventory[countOrder].GetComponentsInChildren<Image>()[2].sprite = in_UDC[(pageNumber - 1) * 10 + countOrder].sprite[0];
                //inventory[countOrder].GetComponentInChildren<Image>().sprite = null;
                inventory[countOrder].GetComponentInChildren<Text>().text = in_UDC[(pageNumber - 1) * 10 + countOrder].name;
            }
            else
            {
                inventory[countOrder].GetComponentsInChildren<Image>()[2].sprite = null;
                inventory[countOrder].GetComponentInChildren<Text>().text = "NoData";
            }
        }
    }

    // 인벤토리 버튼을 누르면, 대상 버튼이 갖고 있는 내용을 가지고 옴.
    public void ShowInventory(int inventoryOrder)
    {
        // 현재 몇 페이지인지는 이미 내부에 Static 변수로 작성되어 있어서 동일하게 사용 가능.
        // inventoryType이 0이면 유닛, 1이면 건축물을 뜻함. (추가 가능)
        // 외부에서 해당 메서드 실행하면, 항상 0 혹은 1의 값을 넣어줘야 함 (그 외에 값에 따라서 인벤토리 표현도 가능.
        selectedButtonNumber = inventoryOrder; // 지금 누른 버튼의 값이 inventoryOrder라서, public 변수에 할당해준다.
        UnitDataClassification tmpUDC = in_UDC[(pageNumber - 1) * 10 + inventoryOrder - 1]; // 인벤토리 오더는 1~10칸이니까. 0부터 시작하려면 1을 빼줘야 함.
        if (tmpUDC.isEmpty == true)
        {
            //만약에 누른 버튼이 isEmpty == true 라면, 데이터가 없다며 표시한다.
            showingData.GetComponentsInChildren<Image>()[1].sprite = null;
            showingData.GetComponentInChildren<Text>().text = "No Data";
            return;
        }
        showingData.GetComponentsInChildren<Image>()[1].sprite = tmpUDC.sprite[0];
        //showingData.GetComponentsInChildren<Image>()[1].sprite = null;
        showingData.GetComponentInChildren<Text>().text = "Name : " + tmpUDC.name + "\n";
        showingData.GetComponentInChildren<Text>().text += "Hp : " + tmpUDC.hp + "\n";

        showingData.GetComponentInChildren<Text>().text += "Atk : " + tmpUDC.atk + "\n";
        showingData.GetComponentInChildren<Text>().text += "Def : " + tmpUDC.def + "\n";
        showingData.GetComponentInChildren<Text>().text += "AtkSp : " + tmpUDC.atkSp + "\n";

        LoadUnitDataClassification();
    }

    public void MovingPage(bool isUping)
    {
        // isUping 페이지를 Next 하시겠습니까? is~upPage? 랑 같은 맥락
        if (isUping)
        {
            if (pageNumber >= 10)
                return;   // 10쪽에서 안 올라감
            pageNumber++;
        }
        else
        {
            // Prev 버튼 눌렀을 때 작동
            if (pageNumber <= 1)
                return; // 1쪽에서 안 내려감
            pageNumber--;
        }
        pageText.GetComponent<Text>().text = "현재 쪽 : " + pageNumber + " / 10";
        InventoryRefresh();
    }

    public void OrganizingInventoryData()
    {
        int dataIndex = 0;
        for (int excuteCount = 0; excuteCount < 100; excuteCount++)
        {
            if (in_UDC[dataIndex].isEmpty == true)
            {
                // in_UDC의 현재 index 값이 비어 있다면, 정렬을 시작한다.
                if (in_UDC[dataIndex + 1].isEmpty == true)
                {
                    // 현재 값과 다음 값이 연속으로 비어있다는 의미는 "마지막 데이터를 지웠기에" 정렬할 필요가 없다거나 "할당된 데이터가 없다"는 뜻이다.
                    break; // break를 하게 되면, 이제 for문을 벗어나서 InventoryRefresh를 하게 된다.
                }
                else
                {
                    in_UDC[dataIndex] = in_UDC[dataIndex + 1]; // 앞에 있는 데이터를 현재 위치로 옮긴다. isEmpty 라서 값이 비어있으니 가능하다.
                    UnitDataClassification emptyUDC = new UnitDataClassification();
                    in_UDC[dataIndex + 1] = emptyUDC;// 앞에 있는 데이터를 현재 위치로 옮겼으니, 앞에 있는 데이터를 지워버린다.
                    in_UDC[dataIndex + 1].isEmpty = true; // 지웠기에, 값은 없으니? 기본 초기화만 해준다. isEmpty를 True 해주면 기본 초기화가 끝난다.
                    //다음 반복에는 in_UDC[dataIndex + 1]이 지워졌고 기본 초기화만 되어 있기 때문에, 없다고 뜰 것이고? 데이터 정리를 다시 할 것이다.
                }
                dataIndex++; // dataIndex의 값을 올려줘서, 다음 반복 검사를 가능하게 한다.
            }
        }
        InventoryRefresh(); // 정렬이 끝나고 인벤토리 다시 보여주기
    }

    public void DeletingInventoryData()
    {
        if (selectedButtonNumber == 0)
        {
            //Debug.Log("선택된 버튼이 없음."); //버튼을 눌러서 데이터를 삭제하면, selectedButtonNumber가 0이 된다. 그럼, 삭제할 수 없으니까 return을 만난다.
            // 또한, 아무 버튼도 선택하지 않았다면 초기값이 0이라서 삭제할 수 없으니까 return을 만난다.
            return;
        }
        UnitDataClassification tmpUDC = in_UDC[(pageNumber - 1) * 10 + selectedButtonNumber - 1];
        if (tmpUDC.isEmpty == true)
        {
            //Debug.Log("해당 UDC가 없음."); // 유닛 데이터(UDC)가 없다는 뜻. 비어있다는 뜻은 없다는 뜻입니다..
            return;
        }
        tmpUDC = new UnitDataClassification(); // 해당 코드가 작동하는 지 확실하지 않음.
        tmpUDC.isEmpty = true; // UDC의 기본 값은 isEmpty가 True여야 한다.
        in_UDC[(pageNumber - 1) * 10 + selectedButtonNumber - 1] = tmpUDC; //새롭게 만든 tmpUDC를 기존 in_UDC 값에 덮어씌운다.
        selectedButtonNumber = 0;
        OrganizingInventoryData();
    }

}
