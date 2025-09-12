using Animation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthBase : MonoBehaviour
{

    public float startLife = 10f;
    public bool destroyOnKill = false;
    public float DeathDuration = 1.5f;
    [SerializeField] private float _currentLife;

    public Action<HealthBase> OnDamage;
    public Action<HealthBase> OnKill;


    private void Awake()
    {
        Init();
    }
    protected void ResetLife()
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
        OnDamage?.Invoke(this);
    }

}
