using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine.UIElements;

public class Flashcolor : MonoBehaviour
{

    public MeshRenderer MeshRenderer;

    [Header("Setup")]
    public Color color = Color.red;

    public float duration = 0.2f;

    private Color defaultColor;
    private Tween _currTween;

    private void Start()
    {
        defaultColor = MeshRenderer.material.GetColor("_EmissionColor");
    }

    [NaughtyAttributes.Button]
    public void Flash()
    {
        if(!_currTween.IsActive())
        MeshRenderer.material.DOColor(color, "_EmissionColor", duration).SetLoops(2, LoopType.Yoyo);
    }



}
