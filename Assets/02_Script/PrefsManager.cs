using UnityEngine;

public static class PrefsManager
{
    private const string InventoryKey = "Inventory";

    public static void Save_Inventory(string inven)
    {
        PlayerPrefs.SetString(InventoryKey, inven);
    }


}
