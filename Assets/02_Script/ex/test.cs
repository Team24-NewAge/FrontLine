using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class test : MonoBehaviour
{
    public GameObject buff;
    public GameObject skill2;
    public GameObject skill3;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            PanelManager.Instance.ShowTestPanel("선택했다");
           
        }
        
    }


   public void testimage()
    {
        PopupManager.Instance.ShowRebuild_Popup();
    }


    public void testPotion1()
    {

        if (BattleManager.Instance.Hero_Mana >= 10)
        {
            BattleManager.Instance.Hero_Mana -= 10f;
            BarManager.Instance.Hero.GetComponent<Unit>().Skill1_Motion_on();
            SoundManager.Instance.attack_buff_Play();

            GameObject unitList = GameObject.Find("Unit");
            Unit[] units = unitList.gameObject.GetComponentsInChildren<Unit>();

            Hero_Skill_Popup hr =PopupManager.Instance.ShowHero_Skill_Popup();
            hr.SetText("전두 지휘", "아군의 다음 공격이 1.5배의 데미지를 입힙니다.");
            foreach (Unit unit in units)
            {
                unit.rage++;
                GameObject buffs =  Instantiate(buff,unit.transform.position,unit.transform.rotation);
                Destroy(buffs, 1);
            }

        }

    }
    public void Skill2()
    {

        if (BattleManager.Instance.Hero_Mana >= 30)
        {
            BattleManager.Instance.Hero_Mana -= 30f;
            BarManager.Instance.Hero.GetComponent<Unit>().Skill2_Motion_on();
            SoundManager.Instance.Hero_Warrior_Skill(2);

            GameObject Mons = GameObject.Find("Monsters");
            int random = Mons.transform.childCount;
            GameObject target = Mons.transform.GetChild(Random.Range(0, random)).gameObject;
            if (target != null)
            {
                GameObject skill = Instantiate(skill2, target.transform.position + new Vector3(0, 1, 0), target.transform.rotation);
                Destroy(skill, 1);
                int dmg = BattleManager.Instance.Damage_Skill(BarManager.Instance.Hero, target, 3f);
                target.GetComponent<Monster>().hp -= dmg;
            }

            Hero_Skill_Popup hr = PopupManager.Instance.ShowHero_Skill_Popup();
            hr.SetText("혼신의 일격", "랜덤한 적 하나에게 공격력의 3배의 피해를 입힙니다");

        }

    }

    public void Skill3()
    {

        if (BattleManager.Instance.Hero_Mana >= 100)
        {
            BattleManager.Instance.Hero_Mana -= 100f;
            BarManager.Instance.Hero.GetComponent<Unit>().Skill3_Motion_on();
            SoundManager.Instance.Hero_Warrior_Skill(3);

            GameObject Mons = GameObject.Find("Monsters");
            int count = Mons.transform.childCount;
            for (int i = 0; i < count; i++)
            {
                GameObject target = Mons.transform.GetChild(i).gameObject;
                GameObject skill = Instantiate(skill3, target.transform.position + new Vector3(0, 1, 0), Quaternion.Euler(0,90,0));
                Destroy(skill, 1);
                int dmg = BattleManager.Instance.Damage_Skill(BarManager.Instance.Hero, target, 2f);
                target.GetComponent<Monster>().hp -= dmg;
            }

            Hero_Skill_Popup hr = PopupManager.Instance.ShowHero_Skill_Popup();
            hr.SetText("폭풍 참격", "적 전체에게 공격력의 2배의 피해를 입힙니다.");

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
