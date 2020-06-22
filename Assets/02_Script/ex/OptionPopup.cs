using System;
using UnityEngine;
using UnityEngine.UI;


public class OptionPopup: PopupBase

{
    public Slider _bgmSlider;
    public Action _HideAction;
    public GameObject soundmanager;

    private void Awake()//패널이 생성될 때
    {
        _bgmSlider.onValueChanged.AddListener(OnSliderValueChanged); //bgm슬라이더에 리스너 할당

        soundmanager = GameObject.Find("SoundManager"); //사운드 매니저 오브젝트를 찾아서 할당
        soundmanager.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("bgm", 0f);
        //볼륨을 저장시켜뒀던 값에 할당
    }

    private void Start()
    {
        _bgmSlider.value = PlayerPrefs.GetFloat("bgm", 0f);
        // 팝업이 실행될 때 bgm슬라이더 값을 기존 db에 저장해둔 값을 할당해 유지시킴
    }

    private void OnSliderValueChanged(float value)//bgm슬라이더 값이 바뀔때
    {
        PlayerPrefs.SetFloat("bgm", value);//데이터 값 저장
        soundmanager.GetComponent<AudioSource>().volume = value;//해당 값으로 볼륨 조정
    }


    public override void HidePopup()
    {
        base.HidePopup();

        _HideAction?.Invoke();
    }


    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Escape))

            {
            base.HidePopup();
            }

    }

}
