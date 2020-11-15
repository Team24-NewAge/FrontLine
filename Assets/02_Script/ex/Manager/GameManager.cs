using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int UnitBuyStack=0;
    public int UnitFusionStack = 0;
    public int UnitReinForceStack=0;


    public GameObject inventory;
    public GameObject Units;

    public float[] unitper = new float[6];
    public float[] unitper_add = new float[6];

    public float[] Hero_traning_per = new float[3];
    public float[] Hero_traning_add = new float[3];
    public enum battleState {nomal,elite,boss };
    public battleState Battle = battleState.nomal;

    public GameObject SavePopup;

    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
        ////////////////////////////////////
        unitper[0] = 0.0f;
        unitper[1] = 0.4f;
        unitper[2] = 0.3f;
        unitper[3] = 0.15f;
        unitper[4] = 0.1f;
        unitper[5] = 0.05f;

        unitper_add[0] = 0f;

        for (int i=0; i < (unitper_add.Length)-1; i++) {

            unitper_add[i+1] = unitper_add[i] + unitper[i+1];
        }
        ///////////////////////////////////
        Hero_traning_per[0] = 0.3f;
        Hero_traning_per[1] = 0.5f;
        Hero_traning_per[2] = 0.2f;

        Hero_traning_add[0] = Hero_traning_per[0];

        for (int i = 0; i < (Hero_traning_add.Length) - 1; i++)
        {

            Hero_traning_add[i + 1] = Hero_traning_add[i] + Hero_traning_per[i + 1];
        }


    }


    // Start is called before the first frame update
    void Start()
    {

        float BGM = PlayerPrefs.GetFloat("bgm", 0f);
        float BGS = PlayerPrefs.GetFloat("bgs", 0f);
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat("bgm", BGM);
        PlayerPrefs.SetFloat("bgs", BGS);

        for (int i = 1; i <= 6; i++)
        {
            PlayerPrefs.SetInt("unit_용병전사_code_" + i.ToString(), 0);
            PlayerPrefs.SetInt("unit_용병전사_grade_" + i.ToString(), 1);
            PlayerPrefs.SetInt("unit_용병전사_hp_" + i.ToString(), 10);
            PlayerPrefs.SetInt("unit_용병전사_maxhp_" + i.ToString(), 10);
            PlayerPrefs.SetInt("unit_용병전사_atk_" + i.ToString(), 2);
            PlayerPrefs.SetInt("unit_용병전사_def_" + i.ToString(), 0);
            PlayerPrefs.SetInt("unit_용병전사_atkSp_" + i.ToString(), 100);

        }
        PlayerPrefs.SetInt("unit_용병전사_tile_1", 5);
        PlayerPrefs.SetInt("unit_용병전사_location_1",2);
        PlayerPrefs.SetInt("unit_용병전사_tile_2", 5);
        PlayerPrefs.SetInt("unit_용병전사_location_2", 1);
        PlayerPrefs.SetInt("unit_용병전사_tile_3", 5);
        PlayerPrefs.SetInt("unit_용병전사_location_3", 3);
        PlayerPrefs.SetInt("unit_용병전사_tile_4", 8);
        PlayerPrefs.SetInt("unit_용병전사_location_4", 1);
        PlayerPrefs.SetInt("unit_용병전사_tile_5", 8);
        PlayerPrefs.SetInt("unit_용병전사_location_5", 1);
        PlayerPrefs.SetInt("unit_용병전사_tile_6", 8);
        PlayerPrefs.SetInt("unit_용병전사_location_6", 3);

    }

    // Update is called once per frame
    void Update()
    {
        if (BarManager.Instance.Hero.GetComponent<Unit>().hp <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }


    }



}
