using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarManager : MonoBehaviour
{
    public Text date_text;
    public int date=1;
    public static BarManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        date_text.text = "D + " + date;
    }

    public void _SetDate() {
        print(PaperManager.Instance.today);
        date_text.text = "D + " + date;
    }

}
