using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIFillUpdater : MonoBehaviour
{
    public Image uiImage;

    [Header("animation")]
    public float duration = 0.1f;
    public Ease ease = Ease.OutBack;

    private Tween _currTween;

    public void Onvalidade()
    {
        if(uiImage == null) uiImage = GetComponent<Image>();
    }



    public void UpdateValue(float f)
    {
        uiImage.fillAmount = f;   
    }

    public void UpdateValue(float max, float current) 
    {
        //uiImage.fillAmount = 1 - (current / max);
        if (_currTween != null) _currTween.Kill();
        _currTween = uiImage.DOFillAmount(1 - (current / max), duration).SetEase(ease);
        //animação invertida no final
    }
}
