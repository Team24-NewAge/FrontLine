using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class start_fade : MonoBehaviour
{
    public Image fade;
   // float fadetime = 1;
    public Color Now;
    //Color oriC;
    AudioSource BGM;

    object tweenId = new object();

    void Start()
    {
        //oriC = fade.color; //색 할당
        BGM = gameObject.GetComponent<AudioSource>(); //bgm 할당

        fade.gameObject.SetActive(true);

        var sequence = DOTween.Sequence();
        sequence.Append(fade.DoAlpha(1f, 0f, 1f));
        sequence.Join(DOTween.To(() => 0f, volume => BGM.volume = volume,1f,2f));
       // sequence.SetLoops(3);
        sequence.onComplete = () => fade.gameObject.SetActive(false);
        sequence.SetEase(Ease.InCirc);
        sequence.SetId(tweenId);

        // DOTween.Kill(tweenId, true);
    }
}
