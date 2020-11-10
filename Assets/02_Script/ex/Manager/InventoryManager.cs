using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    //여기에 아무 변수 추가

    public static InventoryManager Instance { get; private set; }

    public void Awake()
    {
        Instance = this;
    }

    public void Open_Inventory()//인벤토리 열어주는 매서드
    {

    }

    public void Close_Inventory()//인벤토리 닫는 매서드
    {

    }
    public void Open_Fusion()//합성창 여는 메서드
    {

    }
    public void Close_Fusion()//합성창 닫는 메서드
    {

    }
    public void Open_Reinforce()//강화창 여는 메서드
    {

    }
    public void Close_Reinforce()//강화창 닫는 매서드
    {

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
