using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    //여기에 아무 변수 추가

    //(승원)변수 정의
    public GameObject invenUI, fusionUI, reinforceUI;   //on,off할 패널

    public static InventoryManager Instance { get; private set; }

    public void Awake()
    {
        Instance = this;
    }

    public void Open_Inventory()//인벤토리 열어주는 매서드
    {
        invenUI.transform.SetAsLastSibling();
        invenUI.SetActive(true);
    }

    public void Close_Inventory()//인벤토리 닫는 매서드
    {
        invenUI.SetActive(false);
    }
    public void Open_Fusion()//합성창 여는 메서드
    {
        Open_Inventory();
        fusionUI.SetActive(true);
        reinforceUI.SetActive(false);
    }
    public void Close_Fusion()//합성창 닫는 메서드
    {
        Close_Inventory();
        fusionUI.SetActive(false);
    }
    public void Open_Reinforce()//강화창 여는 메서드
    {
        Open_Inventory();
        fusionUI.SetActive(false);
        reinforceUI.SetActive(true);
    }
    public void Close_Reinforce()//강화창 닫는 매서드
    {
        Close_Inventory();
        reinforceUI.SetActive(false);
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
