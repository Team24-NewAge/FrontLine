using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class test : MonoBehaviour
{
    public GameObject buff;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            PanelManager.Instance.ShowTestPanel("선택했다");
           
        }
        
    }


   public void testimage()
    {
        int digit = (int)Mathf.Floor(Mathf.Log10(58412)) + 1;

        for (int i = 0; i < digit; i++)
        {
            int num = (58412 / (int)Mathf.Pow(10, i)) % 10;
            print(num);
        }

        print("클릭작동");
        // EventManager.Instance.Event();
        PopupManager.Instance.ShowUnitShop_Popup();
    }


    public void testPotion1()
    {

        if (BattleManager.Instance.Hero_Mana > 10)
        {
            BattleManager.Instance.Hero_Mana -= 10f;
            SoundManager.Instance.attack_buff_Play();

            GameObject unitList = GameObject.Find("Unit");
            Unit[] units = unitList.gameObject.GetComponentsInChildren<Unit>();

            foreach (Unit unit in units)
            {
                unit.rage++;
                GameObject buffs =  Instantiate(buff,unit.transform.position,unit.transform.rotation);
                Destroy(buffs, 1);
            }

        }




    }


    public void testPotion2()
    {
        StartCoroutine(Potion2());
    }

    public IEnumerator Potion2() {

        float time=0.0f;

        GameObject unitList = GameObject.Find("Unit");
        Unit[] units = unitList.gameObject.GetComponentsInChildren<Unit>();

        foreach (Unit unit in units)
        {
            unit.Berserk=true;
        }

        while (time < 5.0f)
        {

            time += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }

        foreach (Unit unit in units)
        {
            unit.Berserk = false;
        }
    }


    public void testPotion3()
    {
        GameObject unitList = GameObject.Find("Unit");
        Unit[] units = unitList.gameObject.GetComponentsInChildren<Unit>();

        foreach (Unit unit in units)
        {
            unit.rage += 3;
        }

    }

    public void testPotion4()
    {
        GameObject unitList = GameObject.Find("Unit");
        Unit[] units = unitList.gameObject.GetComponentsInChildren<Unit>();

        foreach (Unit unit in units)
        {
            unit.stack = 0;
            unit.end_stack = 3;
            unit.stack_buff = 2;
        }

    }
}
