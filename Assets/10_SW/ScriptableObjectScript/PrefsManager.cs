using UnityEngine;

public static class PrefsManager
{
    //BGM 입출력
    private const string bgmKey = "bgm";

    public static void Save_Bgm(float data)
    {
        PlayerPrefs.SetFloat(bgmKey, data);
    }

    public static float Load_Bgm()
    {
        return PlayerPrefs.GetFloat(bgmKey, 0.0f);
    }

    //BGS 입출력
    private const string bgsKey = "bgs";

    public static void Save_Bgs(float data)
    {
        PlayerPrefs.SetFloat(bgsKey, data);
    }

    public static float Load_Bgs()
    {
        return PlayerPrefs.GetFloat(bgsKey, 0.0f);
    }

    //플레이어 레벨, 없으면 -1 반환
    private const string levelKey = "lv";

    public static void Save_PlayerLevel(int data)
    {
        PlayerPrefs.SetInt(levelKey, data);
    }

    public static int Load_PlayerLevel()
    {
        return PlayerPrefs.GetInt(levelKey, -1);
    }

    //플레이어 경험치, 없으면 -1 반환
    private const string expKey = "exp";

    public static void Save_PlayerExperience(int data)
    {
        PlayerPrefs.SetInt(expKey, data);
    }

    public static int Load_PlayerExperience()
    {
        return PlayerPrefs.GetInt(expKey, -1);
    }

    //플레이어 경험치, 없으면 -1 반환
    private const string scrKey = "scr";

    public static void Save_PlayerScore(int data)
    {
        PlayerPrefs.SetInt(scrKey, data);
    }

    public static int Load_PlayerScore()
    {
        return PlayerPrefs.GetInt(scrKey, -1);
    }

    //플레이어 재화, 없으면 -1 반환
    private const string moneyKey = "money";

    public static void Save_PlayerMoney(int data)
    {
        PlayerPrefs.SetInt(moneyKey, data);
    }

    public static int Load_PlayerMoney()
    {
        return PlayerPrefs.GetInt(moneyKey, -1);
    }

    //경과 일 수, 없으면 -1 반환
    private const string dayKey = "day";

    public static void Save_Day(int data)
    {
        PlayerPrefs.SetInt(dayKey, data);
    }

    public static int Load_Day()
    {
        return PlayerPrefs.GetInt(dayKey, -1);
    }

    //예언, 없으면 "" 반환
    private const string prophecyKey = "ppc";

    public static void Save_Prophecy(string data)
    {
        PlayerPrefs.SetString(prophecyKey, data);
    }

    public static string Load_Prophecy()
    {
        return PlayerPrefs.GetString(prophecyKey, "");
    }

    //소유한 아이템, 

    struct item
    {
        int code;   //id
        int num;    //개수
    }

    private const string itemKey = "itm";

    public static void Save_PlayerItem(int data)
    {
        PlayerPrefs.SetInt(itemKey, data);
    }

    public static int Load_PlayerItem()
    {
        return PlayerPrefs.GetInt(itemKey, -1);
    }
}
