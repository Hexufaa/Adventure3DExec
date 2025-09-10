using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityShoot : PlayerAbilityBase
{
    public List<GunBase> gunPrefabs;
    public List<UIGunUpdater> uiGunUpdater;

    public Transform gunPosition;

    private GunBase _currentGun;
    private int _currentGunIndex = 0;

    protected override void Init()
    {
        base.Init();
        CreateGun(_currentGunIndex);

        inputs.Gameplay.Shoot.performed += ctx => StartShoot();
        inputs.Gameplay.Shoot.canceled += ctx => CancelShoot();
    }

    private void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            SwitchGun(0);
        }

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            SwitchGun(1);
        }
    }

    private void SwitchGun(int index)
    {
        if (index >= 0 && index < gunPrefabs.Count)
        {
            _currentGunIndex = index;
            CreateGun(_currentGunIndex);
        }
    }

    private void CreateGun(int index)
    {
        if (_currentGun != null)
        {
            Destroy(_currentGun.gameObject);
        }

        _currentGun = Instantiate(gunPrefabs[index], gunPosition);
        _currentGun.transform.localPosition = Vector3.zero;
    }


    private void StartShoot()
    {
        _currentGun.StartShoot();
        Debug.Log("Start Shoot");
    }

    private void CancelShoot()
    {
        _currentGun.StopShoot();
        Debug.Log("Cancel Shoot");
    }
}

