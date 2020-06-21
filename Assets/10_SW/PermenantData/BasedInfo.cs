using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasedInfo : ScriptableObject
{
    [SerializeField]
    private int basedCode;
    public int BasedCode { get { return basedCode; } }

    [SerializeField]
    private string basedName;
    public string BasedName { get { return basedName; } }

    [SerializeField]
    private Sprite basedSprite;
    public Sprite BasedSprite { get { return basedSprite; } }

    [SerializeField]
    private int basedGrade;
    public int BasedGrade { get { return basedGrade; } }

    [SerializeField]
    private string basedDescript;
    public string BasedDescript { get { return basedDescript; } }
}