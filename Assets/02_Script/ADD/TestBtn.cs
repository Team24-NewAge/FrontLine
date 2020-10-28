using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBtn : MonoBehaviour
{

    public GameObject btn_1;
    public GameObject btn_2;
    public GameObject c;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        btn_1.SetActive(false);
        c.SetActive(false);
        btn_2.SetActive(true);
    }
}
