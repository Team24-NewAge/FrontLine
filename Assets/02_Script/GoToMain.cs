using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GoToMain : MonoBehaviour
{

    public Image fade;
    float fadetime = 1;
    public Color Now;
    Color oriC;
    AudioSource BGM;

    void Start()
    {
        BGM = gameObject.GetComponent<AudioSource>(); //bgm 할당
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)) //클릭하면
            {
            oriC = fade.color; //바뀔 색깔지정
            StartCoroutine("Fadein"); //코루틴 시작
        }


    }

    IEnumerator Fadein()
    {
        float curT = 0; //현재시간 초기화
        fade.gameObject.SetActive(true); //오브젝트 활성화
        while(curT < fadetime) 
        {
            BGM.volume = BGM.volume - 0.01F;//bgm점점 작게
            curT += Time.deltaTime; //현재시간 ++
            fade.color = Color.Lerp(oriC, Now, curT); //현재시간 값 만큼 러프


            if (curT > 1)
            {
                SceneManager.LoadScene("select-menu"); } //다음씬으로
            yield return null; 

   
        }

    }
}
