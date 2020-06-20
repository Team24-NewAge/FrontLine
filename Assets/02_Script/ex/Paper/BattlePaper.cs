using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePaper : PaperBase
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void ClickPaper()
    {
        //CameraManager.Instance.DoBattle();
        base.ClickPaper();
    }

}
