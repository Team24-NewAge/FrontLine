using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 확장메소드
public static class FrontExtension
{
    public static Tween DoAlpha(this Image image, float startAlpha, float endAlpha, float duration)
    {
        // 람다
        return DOTween.To(() => startAlpha, alpha => image.SetAlpha(alpha), endAlpha, duration);
    }

    public static void SetAlpha(this Image image, float alpha)
    {
        var color = image.color;
        color.a = alpha;
        image.color = color;
    }

    // 제네릭
    public static void SetActiveAll<T>(this T components, bool isActive) where T : IEnumerable<Component>
    {
        foreach (var component in components)
        {
            component.gameObject.SetActive(isActive);
        }
    }
}
