using System;
using UnityEngine;
using UnityEngine.UI;


public class OptionPopup: PopupBase

{
    public Slider _bgmSlider;
    public Action _HideAction;
    public GameObject soundmanager;

    private void Awake()
    {
        _bgmSlider.onValueChanged.AddListener(OnSliderValueChanged);

        soundmanager = GameObject.Find("SoundManager");
        soundmanager.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("bgm", 0f);
    }

    private void Start()
    {
        _bgmSlider.value = PlayerPrefs.GetFloat("bgm", 0f);
    }

    private void OnSliderValueChanged(float value)
    {
        PlayerPrefs.SetFloat("bgm", value);
        soundmanager.GetComponent<AudioSource>().volume = value;
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
