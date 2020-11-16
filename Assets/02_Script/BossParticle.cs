using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossParticle : MonoBehaviour
{
    public Color oric;
    public Color ranc;
    public ParticleSystem par1, par2;
    ParticleSystem.MainModule main,main2;
    // Start is called before the first frame update
    void Start()
    {
        main = par1.main;
        main2 = par2.main;
        StartCoroutine(Color1());
    }

    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator Color1()
    {
        float curT = 0; //현재시간 초기화
        oric = main.startColor.color;
        ranc = new Vector4(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
        while (curT < 3)
        {
          
            curT += Time.deltaTime; //현재시간 ++
            main2.startColor = Color.Lerp(oric, ranc, curT); //현재시간 값 만큼 러프
            main.startColor = Color.Lerp(oric, ranc, curT); //현재시간 값 만큼 러프

            yield return null;
        }
        StartCoroutine(Color1());
        yield return null;
    }

    
    
}
