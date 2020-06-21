using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMN : MonoBehaviour
{
    public struct UnitDataClassification
    {
        public bool isEmpty; // 구조체가 비어있는지 판단. 삭제 된다면 없다는 것을 알려줘야 하니까 만듦.
        // Load한 유닛들의 모든 정보를 변수로 저장하기 위해서 필요한 구조체
        public int basedCode; // 유닛을 구분(식별)하기 위한 ID
        public string basedName; // 유닛의 이름
        public Sprite basedSprite; // 유닛의 이미지
        public int basedGrade; // 유닛의 등급
        public string basedDescript; // 유닛의 설명
        public int lifeHp; //유닛의 생명력
        public int lifeAtk; //유닛의 공격력
        public int lifeDef; //유닛의 방어력
        public int lifeAtkSp; //유닛의 공격 속도
        public int mvSp; // 유닛의 이동 속도
        public int[] lifeSkill; //유닛의 스킬 (2개 이상 가능)
        public int[] synergy; //유닛의 시너지 (2개 이상 가능)
        public int price; // 유닛의 가격
        public int unlockLv; // 유닛의 ?? <- 이거 뭔지 모르겠음

    }
    public struct TowerDataClassification
    {
        public bool isEmpty; // 구조체가 비어있는지 판단. 삭제 된다면 없다는 것을 알려줘야 하니까 만듦.
        // Load한 건축물들의 모든 정보를 변수로 저장하기 위해서 필요한 구조체
        public int basedCode; // 건축물을 구분(식별)하기 위한 ID
        public string basedName; // 건축물의 이름
        public Sprite basedSprite; // 건축물의 이미지
        public int basedGrade; // 건축물의 등급
        public string basedDescript; // 건축물의 설명
        public int unlifeAtk;  // 건축물의 공격력
        public int unlifeAtkSp;  // 건축물의 공격 속도
        public int[] unlifeSkill;  // 건축물의 스킬 (2개 이상 가능)
        public int[] synergy; // 건축물의 시너지 (2개 이상 가능)
        public int price; // 건축물의 가격
        public int unlockLv; // 건축물의 ??
    }

    public UnitInfo[] allUnitObject; // 게임 내에서 사용하는 모든 Unit 의 Prefab이 저장되는 변수
    public TowerInfo[] allTowerObject; // 게임 내에서 사용하는 모든 Tower 의 Prefab이 저장되는 변수
    public GameObject[] inventory = new GameObject[10]; // 게임 내의 인벤토리 (10칸)
    public GameObject showingData;  // 데이터를 보여주는 UI 및 상호 작용 Button.
    public GameObject pageText; // 현재 페이지를 알려주는 텍스트 오브젝트;
    public Sprite[] allUnitSprite; // 유닛 이미지를 저장하는 변수. 1001 - 0번 이미지, 1002 - 1번 이미지.. 이런 식으로 나열할 예정.
    public Sprite[] allTowerSprite; // 건축물 이미지를 저장하는 변수. 2001 - 0번 이미지, 2002 - 1번 이미지.. 이런 식으로 나열할 예정.
    public int selectedButtonNumber = 0; // 현재 선택된 버튼이 몇번째 버튼인지 알려주는 변수. (해당 변수를 통해서, 선택한 데이터의 정보를 확인할 수 있음.)
    public int pageNumber = 1;  // 현재 Page Number를 알려주는 변수
    public int showingType = 0; // 기본 값은 유닛이며, 0을 의미. (0은 유닛, 1은 건축물)

    //Inventory Local Data Manager를 담당함.
    #region

    private static string[] in_UnitCode = new string[100];
    /// <summary>
    /// 유닛 100개, 10개당 1Page. [10][10]과 동일함.
    /// </summary>
    public string[] out_UnitCode
    {
        get
        {
            return in_UnitCode;
        }
        set
        {
            in_UnitCode = value;
        }
    }

    private static string[] in_TowerCode = new string[100];
    /// <summary>
    /// 건축물 100개, 10개당 1Page. [10][10]과 동일함.
    /// </summary>
    public string[] out_TowerCode
    {
        get
        {
            return in_TowerCode;
        }
        set
        {
            in_TowerCode = value;
        }
    }

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

    private static TowerDataClassification[] in_TDC = new TowerDataClassification[100]; // 유닛 100개 데이터
    /// <summary>
    /// 건축물 100개, 10개당 1Page. [10][10]과 동일함.
    /// </summary>
    public TowerDataClassification[] out_TDC
    {
        get
        {
            return in_TDC;
        }
        set
        {
            in_TDC = value;
        }
    }

    #endregion

    // (그외 범위) 레벨: int 1 ~ 100 ###, 현재 (남은)체력: int 1 ~ 300 ###, 등급: int 1 ~ 5 #
    // 코드 예시: !1002#33#44  // 코드 해석: !유닛id#유닛레벨#유닛hp
    // 유닛 초기화 디폴트 값 : 0
    // 코드 예시: @2001#11<- 코드 해석: @건축물id#건축물등급
    // 건축물 초기화 디폴트 값 : 0
    // 코드를 읽어들일 때, 첫 구분자에 따라서 해당 인벤토리의 Data를 분류(유닛 or 건축물)
    // 분류된 Data에 따라서, 메서드를 다르게 실행.
    // 인벤토리는 한 페이지당 10개로 한정.

    // 처음 게임 시작하고 난 다음에, 딱 1번만 실행된다.
    // 인벤토리 데이터가 있다면 불러오고, 없다면 0 값으로 새롭게 생성한다.
    // 200개의 인벤토리 데이터를 한 번에 불러들인다.
    public void firstGameLoadALLInventroy()
    {
        string tmpLoadString; //임시로 PlayerPrefs.GetString을 한다. 값을 비교하기 위해서, 일단 할당하려고 한다.
        string[] codeFactor; //구분자(#) 사이의 숫자를 분별해주기 위해서 저장하는 변수
        string[] innorCodeFactor; //구분자($) 사이의 숫자를 분별해주기 위해서 저장하는 변수
        int unitKeyCount = 0, towerKeyCount = 0; // Inventory의 앞부분부터 전체적으로 탐색하여, Unit과 Tower를 분할해서 저장하는 단계. 
        if (PlayerPrefs.HasKey("Inventory_1"))
        {
            //1번 Key가 존재한다면, 세이브는 1회 초과하여 작동했기에 아래 문구가 작동한다. 그게 아니라면 전부 0로 초기화된다.
            for (int keyCount = 1; keyCount <= 200; keyCount++)
            {
                //in_UnitCode[count - 1] = PlayerPrefs.GetString("Inventory_" + count);
                tmpLoadString = PlayerPrefs.GetString("Inventory_" + keyCount); // keyCount번째의 key를 읽어서, 해당 key에 연결된 Value를 가져온다. 
                if (tmpLoadString[0] == '!')
                {
                    // 만약에 임시로 Load한 String의 값에 1번째로 놓여있는 구분자가 '!' 라면? 유닛을 뜻한다.
                    in_UnitCode[unitKeyCount] = tmpLoadString; // 해당 tmpLoadString을 UnitCode에 저장하는 1차 저장 단계
                    tmpLoadString = tmpLoadString.Remove(0, 1); // 앞에 있는 기본 구분자 !, @, 0 등등을 없애주기 위한 작업
                    codeFactor = tmpLoadString.Split('#');  // 구분자 사이의 숫자를 분별해주는 작업
                    int tmpCodeFactorLength = codeFactor.Length;  //codeFactor의 길이는 값의 개수를 뜻한다. ??#??#?? 라면, ??가 3개라서 값은 3이 나온다.
                    //후위 연산자 --를 했기 때문에? 불러들이고 난 다음, 값을 -1 해주는 형태.
                    in_UDC[unitKeyCount].isEmpty = false; // 값이 비어있지 않다는 것을 뜻함.
                    in_UDC[unitKeyCount].basedCode = int.Parse(codeFactor[codeFactor.Length - tmpCodeFactorLength--]);
                    in_UDC[unitKeyCount].basedName = codeFactor[codeFactor.Length - tmpCodeFactorLength--];
                    in_UDC[unitKeyCount].basedSprite = allUnitObject[int.Parse(codeFactor[codeFactor.Length - tmpCodeFactorLength--])].BasedSprite;  // 해당 부분은 Unit Sprite로 추후 변경할 수 있음.
                    in_UDC[unitKeyCount].basedGrade = int.Parse(codeFactor[codeFactor.Length - tmpCodeFactorLength--]);
                    in_UDC[unitKeyCount].basedDescript = codeFactor[codeFactor.Length - tmpCodeFactorLength--];
                    in_UDC[unitKeyCount].lifeHp = int.Parse(codeFactor[codeFactor.Length - tmpCodeFactorLength--]);
                    in_UDC[unitKeyCount].lifeAtk = int.Parse(codeFactor[codeFactor.Length - tmpCodeFactorLength--]);
                    in_UDC[unitKeyCount].lifeDef = int.Parse(codeFactor[codeFactor.Length - tmpCodeFactorLength--]);
                    in_UDC[unitKeyCount].lifeAtkSp = int.Parse(codeFactor[codeFactor.Length - tmpCodeFactorLength--]);
                    in_UDC[unitKeyCount].mvSp = int.Parse(codeFactor[codeFactor.Length - tmpCodeFactorLength--]);

                    innorCodeFactor = codeFactor[codeFactor.Length - tmpCodeFactorLength--].Split('$'); // $로 구분되는 사이의 값을 저장한다 #4$2$1$3#였을때, (4, 2, 1, 3)을 반환한다.
                    in_UDC[unitKeyCount].lifeSkill = new int[6]; // 지금 최대 값이 6이라서 6을 할당.
                    for (int lifeSkillCount = 0; lifeSkillCount < innorCodeFactor.Length; lifeSkillCount++)
                    {
                        in_UDC[unitKeyCount].lifeSkill[lifeSkillCount] = int.Parse(innorCodeFactor[lifeSkillCount]);
                    }
                    innorCodeFactor = codeFactor[codeFactor.Length - tmpCodeFactorLength--].Split('$'); // $로 구분되는 사이의 값을 저장한다 #4$2$1$3#였을때, (4, 2, 1, 3)을 반환한다.
                    in_UDC[unitKeyCount].synergy = new int[6];
                    for (int synergyCount = 0; synergyCount < innorCodeFactor.Length; synergyCount++)
                    {
                        in_UDC[unitKeyCount].synergy[synergyCount] = int.Parse(innorCodeFactor[synergyCount]);
                    }
                    in_UDC[unitKeyCount].price = int.Parse(codeFactor[codeFactor.Length - tmpCodeFactorLength--]);
                    in_UDC[unitKeyCount].unlockLv = int.Parse(codeFactor[codeFactor.Length - tmpCodeFactorLength]);
                    unitKeyCount++; // in_UDC 하나를 다 채웠으니, unitKeyCount를 +1해줘서 다음 값이 들어갈 수 있게 해준다.
                }
                else if (tmpLoadString[0] == '@')
                {
                    // 만약에 임시로 Load한 String의 값에 1번째로 놓여있는 구분자가 '@' 라면? 건축물을 뜻한다.
                    in_TowerCode[towerKeyCount] = tmpLoadString; // 해당 tmpLoadString을 TowerCode에 저장하는 1차 저장 단계
                    tmpLoadString = tmpLoadString.Remove(0, 1); // 앞에 있는 기본 구분자 !, @, 0 등등을 없애주기 위한 작업
                    codeFactor = tmpLoadString.Split('#');  // 구분자 사이의 숫자를 분별해주는 작업
                    int tmpCodeFactorLength = codeFactor.Length;  //codeFactor의 길이는 값의 개수를 뜻한다. ??#??#?? 라면, ??가 3개라서 값은 3이 나온다.
                    //후위 연산자 --를 했기 때문에? 불러들이고 난 다음, 값을 -1 해주는 형태.
                    in_TDC[unitKeyCount].isEmpty = false; // 값이 비어있지 않다는 것을 뜻함.
                    in_TDC[towerKeyCount].basedCode = int.Parse(codeFactor[codeFactor.Length - tmpCodeFactorLength--]);
                    in_TDC[towerKeyCount].basedName = codeFactor[codeFactor.Length - tmpCodeFactorLength--];
                    in_TDC[towerKeyCount].basedSprite = allTowerObject[int.Parse(codeFactor[codeFactor.Length - tmpCodeFactorLength--])].BasedSprite; // 해당 부분은 Tower Sprite로 추후 변경할 수 있음.
                    in_TDC[towerKeyCount].basedGrade = int.Parse(codeFactor[codeFactor.Length - tmpCodeFactorLength--]);
                    in_TDC[towerKeyCount].basedDescript = codeFactor[codeFactor.Length - tmpCodeFactorLength--];
                    in_TDC[towerKeyCount].unlifeAtk = int.Parse(codeFactor[codeFactor.Length - tmpCodeFactorLength--]);
                    in_TDC[towerKeyCount].unlifeAtkSp = int.Parse(codeFactor[codeFactor.Length - tmpCodeFactorLength--]);
                    innorCodeFactor = codeFactor[codeFactor.Length - tmpCodeFactorLength--].Split('$'); // $로 구분되는 사이의 값을 저장한다 #4$2$1$3#였을때, (4, 2, 1, 3)을 반환한다.
                    in_TDC[towerKeyCount].unlifeSkill = new int[6];
                    for (int unlifeSkillCount = 0; unlifeSkillCount < innorCodeFactor.Length; unlifeSkillCount++)
                    {
                        in_TDC[towerKeyCount].unlifeSkill[unlifeSkillCount] = int.Parse(innorCodeFactor[unlifeSkillCount]);
                    }
                    innorCodeFactor = codeFactor[codeFactor.Length - tmpCodeFactorLength--].Split('$'); // $로 구분되는 사이의 값을 저장한다 #4$2$1$3#였을때, (4, 2, 1, 3)을 반환한다.
                    in_TDC[towerKeyCount].synergy = new int[6];
                    for (int synergyCount = 0; synergyCount < innorCodeFactor.Length; synergyCount++)
                    {
                        in_TDC[towerKeyCount].synergy[synergyCount] = int.Parse(innorCodeFactor[synergyCount]);
                    }
                    in_TDC[towerKeyCount].price = int.Parse(codeFactor[codeFactor.Length - tmpCodeFactorLength--]);
                    in_TDC[towerKeyCount].unlockLv = int.Parse(codeFactor[codeFactor.Length - tmpCodeFactorLength]);
                    towerKeyCount++; // in_TDC 하나를 다 채웠으니, towerKeyCount를 +1해줘서 다음 값이 들어갈 수 있게 해준다.
                }
                else if (tmpLoadString[0] == '0')
                {
                    // 만약에 임시로 Load한 String의 값에 1번째로 놓여있는 값이 0이라면? 더이상 데이터가 없다는 걸 뜻한다.
                    // 데이터는 자동 정렬되기에, 앞자리부터 계속 값을 넣어갈 것이다. 즉, 0이 나왔다면 그 뒤로는 더이상 데이터가 없다는 뜻이다.
                    // 데이터가 없으니까. 이미 생성된 UDC와 TDC에 isEmpty를 True로 설정해줘야 한다.
                    if (unitKeyCount < 100)
                    {
                        in_UDC[unitKeyCount++].isEmpty = true;
                    }
                    if (towerKeyCount < 100)
                    {
                        in_TDC[towerKeyCount++].isEmpty = true;
                    }

                }
            }
        }
        else
        {
            for (int count = 1; count <= 200; count++)
            {
                PlayerPrefs.SetString("Inventory_" + count, "0");
            }
            for (int count = 0; count < 100; count++)
            {
                in_UDC[count].isEmpty = true;
                in_TDC[count].isEmpty = true;
            }
            SampleData(); // 데이터가 없다면 일단 0으로 전부 초기화 시키고, 그다음 샘플 데이터를 넣는다.
            firstGameLoadALLInventroy(); //샘플 데이터를 다 입력했다면, 다시 시작해서 샘플 데이터를 일반 데이터로 넣는다.
        }
    }

    private void Awake()
    {
        firstGameLoadALLInventroy(); // 게임이 시작하면, 자동적으로 실행됨..
        pageText.GetComponent<Text>().text = "현재 쪽 : " + pageNumber + " / 10";
        InventoryRefresh(0); // 기본 인벤토리는 유닛 인벤토리
    }

    // Page 버튼을 눌렀거나, 데이터 변경이 있었을 때 Refresh 해주는 메서드
    public void InventoryRefresh(int changeType)
    {
        // showingType이 0이면 유닛, 1이면 건축물을 뜻함. (추가 가능)
        // 유닛 인벤토리를 눌렀다면, showingType으로 0번을 받아서, 유닛이 나온다. OnClick 이벤트 처리를 통해 작동.
        // 건축물 인벤토리를 눌렀다면, showingType으로 1번을 받아서, 건축물이 나온다. OnClick 이벤트 처리를 통해 작동.
        showingType = changeType; // showingType 변수를 전체적으로 변경해주는 부분. 다른 메서드에서 showingType을 사용하기에 만듦.
        if (showingType == 0) // 유닛
        {
            for (int countOrder = 0; countOrder < 10; countOrder++)
            {
                //inventory로 지정된 버튼의 이미지와 이름을 변경해주는 내용.
                if (in_UDC[(pageNumber - 1) * 10 + countOrder].isEmpty == false)
                {
                    // in_UDC의 isEmpty가 False 라면, 값이 있다는 뜻이니까? 해당 조건문을 수행할 수 있다.
                    // pageNumber는 1부터 시작하니까, (pageNumber - 1)을 사용함
                    inventory[countOrder].GetComponentInChildren<Image>().sprite = in_UDC[(pageNumber - 1) * 10 + countOrder].basedSprite;
                    inventory[countOrder].GetComponentInChildren<Text>().text = in_UDC[(pageNumber - 1) * 10 + countOrder].basedName;
                }
                else
                {
                    inventory[countOrder].GetComponentInChildren<Image>().sprite = null;
                    inventory[countOrder].GetComponentInChildren<Text>().text = "NoData";
                }
            }
        }
        else if (showingType == 1) // 건축물
        {
            for (int countOrder = 0; countOrder < 10; countOrder++)
            {
                //inventory로 지정된 버튼의 이미지와 이름을 변경해주는 내용.
                if (in_TDC[(pageNumber - 1) * 10 + countOrder].isEmpty == false)
                {
                    //in_TDC의 isEmpty가 False 라면, 값이 있다는 뜻이니까? 해당 조건문을 수행할 수 있다.
                    // pageNumber는 1부터 시작하니까, (pageNumber - 1)을 사용함
                    inventory[countOrder].GetComponentInChildren<Image>().sprite = in_TDC[(pageNumber - 1) * 10 + countOrder].basedSprite;
                    inventory[countOrder].GetComponentInChildren<Text>().text = in_TDC[(pageNumber - 1) * 10 + countOrder].basedName;
                }
                else
                {
                    inventory[countOrder].GetComponentInChildren<Image>().sprite = null;
                    inventory[countOrder].GetComponentInChildren<Text>().text = "NoData";
                }
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
        if (showingType == 0) // 유닛
        {
            UnitDataClassification tmpUDC = in_UDC[(pageNumber - 1) * 10 + inventoryOrder - 1]; // 인벤토리 오더는 1~10칸이니까. 0부터 시작하려면 1을 빼줘야 함.
            if (tmpUDC.isEmpty == true)
            {
                //만약에 누른 버튼이 isEmpty == true 라면, 데이터가 없다며 표시한다.
                showingData.GetComponentsInChildren<Image>()[1].sprite = null;
                showingData.GetComponentInChildren<Text>().text = "No Data";
                return;
            }
            showingData.GetComponentsInChildren<Image>()[1].sprite = tmpUDC.basedSprite;
            showingData.GetComponentInChildren<Text>().text = "Name : " + tmpUDC.basedName + "\n";
            showingData.GetComponentInChildren<Text>().text += "Hp : " + tmpUDC.lifeHp + "\n";
            showingData.GetComponentInChildren<Text>().text += "Atk : " + tmpUDC.lifeAtk + "\n";
            showingData.GetComponentInChildren<Text>().text += "Def : " + tmpUDC.lifeDef + "\n";
            showingData.GetComponentInChildren<Text>().text += "AtkSp : " + tmpUDC.lifeAtkSp + "\n";
            showingData.GetComponentInChildren<Text>().text += "MvSp : " + tmpUDC.mvSp + "\n";
            showingData.GetComponentInChildren<Text>().text += "Skill : ";
            for (int count = 0; count < tmpUDC.lifeSkill.Length; count++)
            {
                showingData.GetComponentInChildren<Text>().text += tmpUDC.lifeSkill[count];
            }
            showingData.GetComponentInChildren<Text>().text += "\n";
            showingData.GetComponentInChildren<Text>().text += "Synergy : ";
            for (int count = 0; count < tmpUDC.synergy.Length; count++)
            {
                showingData.GetComponentInChildren<Text>().text += tmpUDC.synergy[count];
            }
            showingData.GetComponentInChildren<Text>().text += "\n";
            showingData.GetComponentInChildren<Text>().text += "Price : " + tmpUDC.price + "\n";
        }
        else if (showingType == 1) // 건축물
        {
            TowerDataClassification tmpTDC = in_TDC[(pageNumber - 1) * 10 + inventoryOrder - 1]; // 인벤토리 오더는 1~10칸이니까. 0부터 시작하려면 1을 빼줘야 함.
            if (tmpTDC.isEmpty == true)
            {
                //만약에 누른 버튼이 isEmpty == true 라면, 데이터가 없다며 표시한다.
                showingData.GetComponentsInChildren<Image>()[1].sprite = null;
                showingData.GetComponentInChildren<Text>().text = "No Data";
                return;
            }
            showingData.GetComponentsInChildren<Image>()[1].sprite = tmpTDC.basedSprite;
            showingData.GetComponentInChildren<Text>().text = "Name : " + tmpTDC.basedName + "\n";
            showingData.GetComponentInChildren<Text>().text += "Atk : " + tmpTDC.unlifeAtk + "\n";
            showingData.GetComponentInChildren<Text>().text += "AtkSp : " + tmpTDC.unlifeAtkSp + "\n";
            showingData.GetComponentInChildren<Text>().text += "Skill : ";
            for (int count = 0; count < tmpTDC.unlifeSkill.Length; count++)
            {
                showingData.GetComponentInChildren<Text>().text += tmpTDC.unlifeSkill[count];
            }
            showingData.GetComponentInChildren<Text>().text += "\n";
            showingData.GetComponentInChildren<Text>().text += "Synergy : ";
            for (int count = 0; count < tmpTDC.synergy.Length; count++)
            {
                showingData.GetComponentInChildren<Text>().text += tmpTDC.synergy[count];
            }
            showingData.GetComponentInChildren<Text>().text += "\n";
            showingData.GetComponentInChildren<Text>().text += "Price : " + tmpTDC.price + "\n";
        }
    }

    public void SaveInventory()
    {

    }

    public void OrganizingInventoryData()
    {
        int dataIndex = 0;
        for (int excuteCount = 0; excuteCount < 100; excuteCount++)
        {
            if (showingType == 0)
            {
                // showingType이 0이라는 이야기는, 유닛을 정렬해야 한다는 의미이다.
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
                }
                dataIndex++; // dataIndex의 값을 올려줘서, 다음 반복 검사를 가능하게 한다.
            }
            else if (showingType == 1)
            {
                // showingType이 0이라는 이야기는, 건축물을 정렬해야 한다는 의미이다.
                if (in_TDC[dataIndex].isEmpty == true)
                {
                    // in_UDC의 현재 index 값이 비어 있다면, 정렬을 시작한다.
                    if (in_TDC[dataIndex + 1].isEmpty == true)
                    {
                        // 현재 값과 다음 값이 연속으로 비어있다는 의미는 "마지막 데이터를 지웠기에" 정렬할 필요가 없다거나 "할당된 데이터가 없다"는 뜻이다.
                        break; // break를 하게 되면, 이제 for문을 벗어나서 InventoryRefresh를 하게 된다.
                    }
                    else
                    {
                        in_TDC[dataIndex] = in_TDC[dataIndex + 1]; // 앞에 있는 데이터를 현재 위치로 옮긴다. isEmpty 라서 값이 비어있으니 가능하다.
                        TowerDataClassification emptyTDC = new TowerDataClassification();
                        in_TDC[dataIndex + 1] = emptyTDC; // 앞에 있는 데이터를 현재 위치로 옮겼으니, 앞에 있는 데이터를 지워버린다.
                        in_TDC[dataIndex + 1].isEmpty = true; // 지웠기에, 값은 없으니? 기본 초기화만 해준다. isEmpty를 True 해주면 기본 초기화가 끝난다.
                                                              //다음 반복에는 in_TDC[dataIndex + 1]이 지워졌고 기본 초기화만 되어 있기 때문에, 없다고 뜰 것이고? 데이터 정리를 다시 할 것이다.
                    }
                }
                dataIndex++; // dataIndex의 값을 올려줘서, 다음 반복 검사를 가능하게 한다.
            }
        }
        InventoryRefresh(showingType); // 정렬이 끝나고 인벤토리 다시 보여주기
    }

    public void DeletingInventoryData()
    {
        if (selectedButtonNumber == 0)
        {
            Debug.Log("선택된 버튼이 없음."); //버튼을 눌러서 데이터를 삭제하면, selectedButtonNumber가 0이 된다. 그럼, 삭제할 수 없으니까 return을 만난다.
            // 또한, 아무 버튼도 선택하지 않았다면 초기값이 0이라서 삭제할 수 없으니까 return을 만난다.
            return;
        }
        if (showingType == 0)
        {
            // showingType이 0이라는 의미는, 현재 보여지고 있는 창이 Unit 창이라는 뜻. Unit Data를 눌렀다는 뜻이고, 삭제해야 한다는 뜻이다.
            UnitDataClassification tmpUDC = in_UDC[(pageNumber - 1) * 10 + selectedButtonNumber - 1];
            if (tmpUDC.isEmpty == true)
            {
                Debug.Log("해당 UDC가 없음."); // 유닛 데이터(UDC)가 없다는 뜻. 비어있다는 뜻은 없다는 뜻입니다..
                return;
            }
            tmpUDC = new UnitDataClassification(); // 해당 코드가 작동하는 지 확실하지 않음.
            tmpUDC.isEmpty = true; // UDC의 기본 값은 isEmpty가 True여야 한다.
            in_UDC[(pageNumber - 1) * 10 + selectedButtonNumber - 1] = tmpUDC; //새롭게 만든 tmpUDC를 기존 in_UDC 값에 덮어씌운다.
        }
        else if (showingType == 1)
        {
            // showingType이 1이라는 의미는, 현재 보여지고 있는 창이 Tower 창이라는 뜻. Tower Data를 눌렀다는 뜻이고, 삭제해야 한다는 뜻이다.
            TowerDataClassification tmpTDC = in_TDC[(pageNumber - 1) * 10 + selectedButtonNumber - 1];
            if (tmpTDC.isEmpty == true)
            {
                Debug.Log("해당 TDC가 없음."); // 건축물 데이터(TDC)가 없다는 뜻. 비어있다는 뜻은 없다는 뜻입니다..
                return;
            }
            tmpTDC = new TowerDataClassification(); // 해당 코드가 작동하는 지 확실하지 않음.
            tmpTDC.isEmpty = true; // TDC의 기본 값은 isEmpty가 True여야 한다.
            in_TDC[(pageNumber - 1) * 10 + selectedButtonNumber - 1] = tmpTDC;  //새롭게 만든 tmpTDC를 기존 in_TDC 값에 덮어씌운다.
        }
        selectedButtonNumber = 0;
        OrganizingInventoryData();
    }

    public void AddingInventoryData()
    {

    }

    public void EditInventoryData()
    {

    }

    private void SampleData()
    {
        PlayerPrefs.SetString("Inventory_1", "!1004#미노타우로스#13#4#어차피안나옴#62#48#32#22#15#1$5$6$7#3$9$5#12#7");
        PlayerPrefs.SetString("Inventory_2", "@2007#라이트닝타워#11#3#어차피안나옴#33#33#7$2$1#4#22#1");
        PlayerPrefs.SetString("Inventory_3", "!1001#마노#10#5#어차피안나옴#60#8#2#2#5#1$5$6#3$1$7$4$5#22#2");
        PlayerPrefs.SetString("Inventory_4", "!1002#늑대#2#4#어차피안나옴#10#42#23#11#22#5$6$7#4$9$5#24#1");
        PlayerPrefs.SetString("Inventory_5", "!1008#가가가#7#3#어차피안나옴#20#23#11#51#51#1#3$4$5#44#8");
        PlayerPrefs.SetString("Inventory_6", "!1002#최재애로스#3#3#어차피안나옴#22#55#1#0#0#1$7#2$1$5#88#2");
        PlayerPrefs.SetString("Inventory_7", "@2001#라이닝타워#10#2#어차피안나옴#2#3#1$2#2$4#12#2");
        PlayerPrefs.SetString("Inventory_8", "!1010#마뇽타우로스#6#2#어차피안나옴#66#0#59#21#28#2$7#3$1$7$9$5#77#1");
        PlayerPrefs.SetString("Inventory_9", "@2012#커닝타워#1#1#어차피안나옴#31#31#1$2$5#2$4#1#3");
        PlayerPrefs.SetString("Inventory_10", "@2013#이닝타워#0#3#어차피안나옴#12#34#7$3#1$4#2#4");
        PlayerPrefs.SetString("Inventory_11", "@2003#라닝타워#12#2#어차피안나옴#85#3#7#1#5#2");
        PlayerPrefs.SetString("Inventory_12", "@2010#트레이닝타워#8#0#어차피안나옴#38#31#1#0#1#1");
        PlayerPrefs.SetString("Inventory_13", "@2002#라이토타워#7#2#어차피안나옴#32#13#7$2$6#2#99#1");
        PlayerPrefs.SetString("Inventory_14", "@2012#커닝타워#0#3#어차피안나옴#63#41#7$1#2#0#1");
        PlayerPrefs.SetString("Inventory_15", "!1003#뚫똷딵스#0#1#어차피안나옴#55#17#46#56#42#2$3$6$7#3$1$7$2#57#5");
        PlayerPrefs.SetString("Inventory_16", "!1001#미노타우로수#3#1#어차피안나옴#20#53#66#2#5#4$5$6$7#3$9$5#28#1");
        PlayerPrefs.SetString("Inventory_17", "!1005#미노타우로스#3#2#어차피안나옴#66#54#72#28#1#3$6$7#3$4$6$8$5#0#0");
        PlayerPrefs.SetString("Inventory_18", "@2002#라이토타워#3#1#어차피안나옴#21#63#2$1#2$1$3#18#3");
        PlayerPrefs.SetString("Inventory_19", "@2002#라이토2타워#3#5#어차피안나옴#53#13#2#1#8#0");
        PlayerPrefs.SetString("Inventory_20", "@2008#라스타워#11#1#어차피안나옴#3#3#2$1#2#21#1");
        PlayerPrefs.SetString("Inventory_21", "!1014#므너투아러스#1#1#어차피안나옴#32#28#82#18#47#3$7#3$2$6$2$5#0#2");
        PlayerPrefs.SetString("Inventory_22", "@2001#버닝타워#9#1#어차피안나옴#13#32#7$2#1#52#2");
        PlayerPrefs.SetString("Inventory_23", "@2002#라이토타워#10#2#어차피안나옴#22#44#2$1#0#40#4");
        PlayerPrefs.SetString("Inventory_24", "@2003#나이든타워#1#1#어차피안나옴#74#52#7$6#2#22#2");
        PlayerPrefs.SetString("Inventory_25", "!1011#미5타우3스#2#1#어차피안나옴#14#28#27#28#1#1#3$1$1$6$5#0#2");
        PlayerPrefs.SetString("Inventory_26", "@2006#포스타워#2#1#어차피안나옴#1#0#6$2$1#2#2#8");
        PlayerPrefs.SetString("Inventory_27", "@2007#랄라랄타워#10#2#어차피안나옴#87#27#7#1#35#1");
        PlayerPrefs.SetString("Inventory_28", "@2004#츄라이타워#1#4#어차피안나옴#80#76#1#2#18#2");
        PlayerPrefs.SetString("Inventory_29", "@2003#트닝타워#11#3#어차피안나옴#84#27#7$2$1#1#72#0");
        PlayerPrefs.SetString("Inventory_30", "!1004#미노타우로스#8#1#어차피안나옴#1#2#3#4#5#1$5#3$1$8$3$5#41#1");
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
        InventoryRefresh(showingType);
    }

}
