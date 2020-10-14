using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class test : MonoBehaviour
{

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            PanelManager.Instance.ShowTestPanel("선택했다");
           
        }
        
    }


   public void testimage() 
    {
        print("클릭작동");
        EventManager.Instance.Event();
    }


    public void testPotion1()
    {
        GameObject unitList = GameObject.Find("Unit");
        Unit[] units = unitList.gameObject.GetComponentsInChildren<Unit>();

        foreach (Unit unit in units) 
        {
            unit.rage++;
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
