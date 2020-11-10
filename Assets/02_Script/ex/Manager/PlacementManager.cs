using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{

    //여기에 아무 변수 추가
    public static PlacementManager Instance { get; private set; }

    public void Awake()
    {
        Instance = this;
    }



    public void Open_Placement()//배치 환경으로 만들어주는 매서드
    { 
    
    }

    public void Close_Placement()//배치 닫고 다시 paper선택으로 돌아가게 하는 매서드
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
