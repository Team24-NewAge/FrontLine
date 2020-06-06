using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class MoveTest : MonoBehaviour
{
    [SerializeField] private DOTweenPath doTweenPath;

    void Start()
    {
        var moveTween = transform.DOPath(doTweenPath.path, 5f); //컨트롤 쉬프트 f (찾아주기) 쉬프트x2(파일,메서드)

        moveTween.onWaypointChange += wayPoint;
    }

    public void wayPoint(int a)
    {
        print(a);
    }
}