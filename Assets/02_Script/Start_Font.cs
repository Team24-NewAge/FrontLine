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
        main = transform.GetComponent<Text>();//텍스트 할당
        x = gameObject.GetComponent<Text>().color; //텍스트 오브젝트(컬러) 할당
    }

    void Update()
    {
        if (plus == false)//불값이 false이면
        {
            x.a = x.a - 0.01f;//오브젝트의 알파값(투명도)을 매 프레임마다 감소
            main.color = x; //텍스트의 투명도를 변수값으로 설정
            if (x.a < 0f) //만약 투명도가 0이하로 낮아지면
            { plus = true; } //불값 변환
        }
        else//true면
        {
            x.a = x.a + 0.01f; //반대로 투명도 프레임마다 증가
            main.color = x;
            if (x.a >= 1f) //만약 투명도가 1(100퍼센트)보다 높아지면
            { plus = false; }//불값 변환
        }

    }
}
