using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class start_fade : MonoBehaviour
{

    public Image fade;
    float fadetime = 1;
    public Color Now;
    Color oriC;
    AudioSource BGM;

    // Start is called before the first frame update
    void Start()
    {
        oriC = fade.color; //색 할당
        BGM = gameObject.GetComponent<AudioSource>(); //bgm 할당
        StartCoroutine("Fadeout"); //코루틴시작
    }



    IEnumerator Fadeout()
    {
        
        float curT = 0;
         fade.gameObject.SetActive(true);
        while (curT < fadetime)
        {
            BGM.volume = BGM.volume + 0.01F;
            curT += Time.deltaTime;
            fade.color = Color.Lerp(oriC, Now, curT);
           
            yield return null;
        }

        fade.gameObject.SetActive(false);
    }
}
