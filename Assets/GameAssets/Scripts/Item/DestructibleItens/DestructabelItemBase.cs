using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DestructabelItemBase : MonoBehaviour
{
    public float ShakeDuration = .1f;
    public int ShakeForce = 1;
    public HealthBase HealthBase;

    public int dropCoinsAmount = 10;
    public GameObject coinPrefab;
    public Transform dropPosition;

    private void Onvalidade()
    {
        if(HealthBase == null ) HealthBase = GetComponent<HealthBase>();

    }

    private void Awake()
    {
        Onvalidade();
        HealthBase.OnDamage += OnDamage;
    }

    private void OnDamage(HealthBase h)
    {
        transform.DOShakeScale(ShakeDuration, Vector3.up, ShakeForce);
        DropCoins();
    }
    private void DropCoins() 
    {
        var i = Instantiate(coinPrefab);
        i.transform.position = dropPosition.position;
        i.transform.DOScale(0, .2f).SetEase(Ease.OutBack).From();
    }

    [NaughtyAttributes.Button]
    private void DropCoinGroupAmount() 
    {
        StartCoroutine(DropCoinGroupAmountCoroutine());
    }

    IEnumerator DropCoinGroupAmountCoroutine()
    {
        for (int i = 0;i < dropCoinsAmount; i++)
        {
            DropCoins();
            yield return new WaitForSeconds(.1f);
        }
    }

}
