using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine.UIElements;

public class Flashcolor : MonoBehaviour
{

    public MeshRenderer MeshRenderer;

    public string colorParameter = "_EmissionColor";

    [Header("Setup")]
    public Color color = Color.red;

    public float duration = 0.2f;

    private Color defaultColor;
    private Tween _currTween;

    private void Start()
    {
        defaultColor = MeshRenderer.material.GetColor(colorParameter);
    }

    [NaughtyAttributes.Button]
    public void Flash()
    {
        if(!_currTween.IsActive())
        _currTween = MeshRenderer.material.DOColor(color, colorParameter, duration).SetLoops(2, LoopType.Yoyo);
    }



}
