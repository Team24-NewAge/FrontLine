using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class End_Fade : MonoBehaviour
{
    public Image fade;
    float fadetime = 1;
    public Color Now;
    public Color End;
    Color oriC;
    AudioSource BGM;
    public  ParticleSystem[] endparticle = new ParticleSystem[6]; 
    object tweenId = new object();


    void Start()
    {
        StartCoroutine("Fadein"); //코루틴 시작
        //oriC = fade.color; //색 할당
        BGM = gameObject.GetComponent<AudioSource>(); //bgm 할당

        fade.gameObject.SetActive(true);

        var sequence = DOTween.Sequence();
        sequence.Append(fade.DoAlpha(1f, 0f, 3f));
        sequence.Join(DOTween.To(() => 0f, volume => BGM.volume = volume, 1f, 3f));
        // sequence.SetLoops(3);
        sequence.onComplete = () => {fade.gameObject.SetActive(false);};
        sequence.SetEase(Ease.InCirc);
        sequence.SetId(tweenId);

        // DOTween.Kill(tweenId, true);
    }

    IEnumerator Fadein()
    {
        float curT = 0; //현재시간 초기화
        fade.gameObject.SetActive(true); //오브젝트 활성화
        while (curT < fadetime)
        {
            curT += Time.deltaTime; //현재시간 ++
            foreach (ParticleSystem par in endparticle)
            {
                ParticleSystem.MainModule main = par.main;
                main.startColor = Color.Lerp(oriC, Now, curT); //현재시간 값 만큼 러프
            }
            yield return null;


        }

    }


    public void Gotomain() {

        foreach (ParticleSystem par in endparticle)
        {
            ParticleSystem.MainModule main = par.main;
            main.startColor = End; //현재시간 값 만큼 러프
        }
        fade.gameObject.SetActive(true);
        var sequence = DOTween.Sequence();
        sequence.Append(fade.DoAlpha(0f, 1f, 1f));
        sequence.Join(DOTween.To(() => 1f, volume => BGM.volume = volume, 0f, 2f));
        // sequence.SetLoops(3);
        sequence.onComplete = () => { SceneManager.LoadScene("select-menu"); };
        sequence.SetEase(Ease.InCirc);
        sequence.SetId(tweenId);

       

    }

}
