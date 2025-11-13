using Animation;
using Cloth;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cloth;

public class HealthBase : MonoBehaviour, IDamageable
{

    public float startLife = 10f;
    public bool destroyOnKill = false;
    public float DeathDuration = 1.5f;

    public Action<HealthBase> OnDamage;
    public Action<HealthBase> OnKill;


    public List<UIFillUpdater> uiUpdater;

    public float damageMultiply = 1f;

    [SerializeField] public float _currentLife;


    private void Awake()
    {
        Init();
    }
    public void ResetLife()
    {
        _currentLife = startLife;
        UpdateUI();
    }

    protected virtual void Init()
    {
        ResetLife();
        //if (startWithAnimation) BornAnimation();
    }

    protected virtual void Kill()
    {
        if( destroyOnKill)
        {
            Destroy(gameObject, DeathDuration);
        }
        OnKill?.Invoke(this);
    }

    [NaughtyAttributes.Button]
    public void Damage()
    {
        Damage(5);
    }

    public void Damage(float f)
    {
        _currentLife -= f * damageMultiply;
        if (_currentLife <= 0)
        {
            Kill();
        }
        UpdateUI();
        OnDamage?.Invoke(this);
    }

    public void Damage(float damage, Vector3 dir)
    {
        Damage(damage);
    }

    private void UpdateUI()
    {
        if (uiUpdater != null)
        {
            uiUpdater.ForEach(i => i.UpdateValue((float)_currentLife / startLife));
        }
    }

    public void ChangeDamageMultiply(float damage, float duration)
    {
        StartCoroutine(ChangeDamageMultiplyCoroutine(damageMultiply, duration));
    }

    IEnumerator ChangeDamageMultiplyCoroutine(float damageMultiply, float duration)
    {
        this.damageMultiply = damageMultiply;
        yield return new WaitForSeconds(duration);
        this.damageMultiply = 1;

    }

}
