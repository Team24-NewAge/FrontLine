using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Start_Font : MonoBehaviour
{
    Text main;
    Color x;
    bool plus = true;
    
    void Start()
    {
        main = transform.GetComponent<Text>();
        x = gameObject.GetComponent<Text>().color;
    }

    void Update()
    {
        if (plus == false)
        {
            x.a = x.a - 0.01f;
            main.color = x;
            if (x.a < 0f)
            { plus = true; }
        }
        else
        {
            x.a = x.a + 0.01f;
            main.color = x;
            if (x.a >= 1f)
            { plus = false; }
        }

    }
}
