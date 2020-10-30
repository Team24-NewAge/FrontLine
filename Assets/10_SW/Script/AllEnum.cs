using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AllEnum
{

    /// <summary>
    /// 유닛의 종류에 대한 Name
    /// </summary>
    public enum UnitName
    {
        용병전사,
        용병검사,
        용병창술사,
        용병마법사,
        용병대장
    }
  
    /// <summary>
    /// 유닛 데이터를 읽어들이는 속성(Attribute)의 종류
    /// </summary>
    public enum UnitAttribute
    {
        code,
        grade,
        hp,
        maxhp,
        atk,
        def,
        atkSp,
        tile,
        location
    }


}
