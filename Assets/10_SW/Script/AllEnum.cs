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
        방패병,
        도적,
        용병검사,
        엑스워리어,
        수호대장,
        용병창술사,
        견습술사,
        검투사,
        용병대장,
        프리스트,
        역병의사,
        기사단장,
        엘프마법사,
        하이프리스티스
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
