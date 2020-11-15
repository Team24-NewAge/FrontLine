using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    //여기에 아무 변수 추가

    //(승원)변수 정의
    public GameObject invenUI;   //on,off할 패널
    public GameObject fadeimage;
    public bool isClosedInven = true; // 처음 시작하면, 인벤토리는 Closed 되어 있음. UI로 유저에게 보여

    public static InventoryManager Instance { get; private set; }

    public void Awake()
    {
        Instance = this;
    }

    public void Open_Inventory()//인벤토리 열어주는 매서드
    {
        invenUI.transform.SetAsLastSibling();
        fadeimage.SetActive(true);
        invenUI.SetActive(true);

        SoundManager.Instance.menu_ok_Play();
    }

    public void Close_Inventory()//인벤토리 닫는 매서드
    {
        SoundManager.Instance.cancle_menu();
        fadeimage.SetActive(false);
        invenUI.SetActive(false);
    }
    public void Open_Fusion()//합성창 여는 메서드
    {
        Open_Inventory();
        CheckingInvenManager.instance.ShowFusionOptionUI(false);
    }
    public void Close_Fusion()//합성창 닫는 메서드
    {
        Close_Inventory();
        CheckingInvenManager.instance.ShowFusionOptionUI(true);
    }
    public void Open_Reinforce()//강화창 여는 메서드
    {
        Open_Inventory();
        CheckingInvenManager.instance.ShowReinforceOptionUI(false);
    }
    public void Close_Reinforce()//강화창 닫는 매서드
    {
        Close_Inventory();
        CheckingInvenManager.instance.ShowReinforceOptionUI(true);
    }

    public void CheckOpenInven()
    {
        // isClosedInven의 TF에 따라서, 인벤토리를 열고 닫는다.
        if (isClosedInven)
        {
            invenUI.SetActive(true);
            isClosedInven = false;
        }
        else
        {
            invenUI.SetActive(false);
            isClosedInven = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
