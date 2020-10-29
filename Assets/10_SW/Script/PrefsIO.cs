using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefsIO : MonoBehaviour
{
    // PlayerPrefs에 data 저장, 불러오기
    public static PrefsIO Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    // 포션 내용 저장, 최초 1회 한번 사용할 것, 추후 필요에 따라 사용할 것
    public void initPortionSet()
    {

        // 분류    class: item
        // 이름     name: portion1, portion2, portion3, portion4
        // 속성 property: code, value, count, durationType, quantity

        // 게임중 수정 가능한 속성은 quantitiy만 한정해서 사용, 다른 속성은 추후 상수형으로 바꿀 것임


        // portion1: 일회용으로 사용시 다음회차 공격에 한해 모든 유닛 공격력 증가
        PlayerPrefs.SetInt("item_portion1_code", 1);
        PlayerPrefs.SetInt("item_portion1_value", 1);           // 모든 유닛 공격력 증가
        PlayerPrefs.SetInt("item_portion1_count", 1);           // 사용제한 횟수 1회
        PlayerPrefs.SetInt("item_portion1_durationType", 1);    // 사용 즉시 사용 회수가 1 줄어들고 능력은 다음 행동에 한함
        PlayerPrefs.SetInt("item_portion1_quantity", 1);        // 남은 수량 1

        // portion2: 5초동안 모든 유닛 공격력을 강화
        PlayerPrefs.SetInt("item_portion2_code", 2);
        PlayerPrefs.SetInt("item_portion2_value", 1);           // 모든 유닛 공격력 증가
        PlayerPrefs.SetInt("item_portion2_count", 5);           // 지속시간 5초
        PlayerPrefs.SetInt("item_portion2_durationType", 2);    // 매초마다 지속시간이 1 감소하고 지속시간이 있는동안 효과받음
        PlayerPrefs.SetInt("item_portion2_quantity", 1);        // 남은 수량 1

        // portion3: 모든 유닛이 다음 3번 공격 동안 공격력 강화, 모두 따로 적용
        PlayerPrefs.SetInt("item_portion3_code", 3);
        PlayerPrefs.SetInt("item_portion3_value", 1);           // 모든 유닛 공격력 증가
        PlayerPrefs.SetInt("item_portion3_count", 3);           // 사용제한 횟수 3회
        PlayerPrefs.SetInt("item_portion3_durationType", 3);    // 유닛 공격시 1 차감하고, 이 계산은 각 유닛 별로 이루어짐
        PlayerPrefs.SetInt("item_portion3_quantity", 1);        // 남은 수량 1

        // portion4: 모든 유닛이 다음 2번 공격 이후 공격력 강화, 모두 따로 적용
        PlayerPrefs.SetInt("item_portion4_code", 4);
        PlayerPrefs.SetInt("item_portion4_value", 1);           // 모든 유닛 공격력 증가
        PlayerPrefs.SetInt("item_portion4_count", 2);           // 스택 횟수 2회
        PlayerPrefs.SetInt("item_portion4_durationType", 3);    // 유닛 공격시 1 차감하고, 이 계산은 각 유닛 별로 이루어짐
                                                                // ㄴ 공격력 증가는 count가 0이 되고 1회에 한하여 발동
        PlayerPrefs.SetInt("item_portion4_quantity", 1);        // 남은 수량 1
    }

    // 유닛 예시 저장, 사용해도 그만 안해도 그만
    public void initUnitSet()
    {
        // 분류 class: unit
        // 이름     name: knight(예시)
        // 속성 property: code, grade, hp, maxHp, atk, def, atkSp, location,title 

        // knight(예시):  

        PlayerPrefs.SetInt("unit_knight_code", 1);
        PlayerPrefs.SetInt("unit_knight_grade", 1);
        PlayerPrefs.SetInt("unit_knight_maxHp", 30);
        PlayerPrefs.SetInt("unit_knight_hp", 30);
        PlayerPrefs.SetInt("unit_knight_atk", 2);
        PlayerPrefs.SetInt("unit_knight_def", 2);
        PlayerPrefs.SetInt("unit_knight_atkSp", 150);
        PlayerPrefs.SetInt("unit_knight_location", 0);
        PlayerPrefs.SetInt("unit_knight_tile", 0);

    }

    // 정보 가져오기
    public int getPrefs(string prefsClass, string prefsName, string prefsProperty)
    {
        if (PlayerPrefs.HasKey(prefsClass + "_" +prefsName + "_" +prefsProperty))	// 해당 키값있는지 확인
			return PlayerPrefs.GetInt(prefsClass + "_" + prefsName + "_" + prefsProperty);
		else
			return -1;		// 없다면 -1 반환
    }

    // 정보 저장
    public void setPrefs(string prefsClass, string prefsName, string prefsProperty, int prefsValue)
    {
        PlayerPrefs.SetInt(prefsClass + "_" + prefsName + "_" + prefsProperty, prefsValue);
    }

}
