using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOpen : MonoBehaviour
{
    public bool isClosedInven = true; // 처음 시작하면, 인벤토리는 Closed 되어 있음. UI로 유저에게 보여지고 있지 않다는 의미.
    public GameObject invenUI; // 인벤토리 UI를 참조하는 게임 오브젝트 변수

    // 인벤토리가 열렸는지 확인하는 메서드
    // 인벤토리가 닫혀있다면(보이지 않는다면) 인벤토리를 열어준다.
    // 인벤토리가 열려있다면(보인다면) 인벤토리를 닫아준다.
    // 인벤토리를 열고 닫는지 파악하는 변수는 isClosedInven 변수 사용.
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

    public void DataReset()
    {
        PlayerPrefs.DeleteAll();
    }
}
