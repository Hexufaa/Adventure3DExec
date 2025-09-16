using Animation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthBase : MonoBehaviour, IDamageable
{

    public float startLife = 10f;
    public bool destroyOnKill = false;
    public float DeathDuration = 1.5f;

    public Action<HealthBase> OnDamage;
    public Action<HealthBase> OnKill;


    public List<UIFillUpdater> uiUpdater;
 
    [SerializeField] private float _currentLife;


    private void Awake()
    {
        Init();
    }
    public void ResetLife()
    {
        _currentLife = startLife;
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
        _currentLife -= f;
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

}
