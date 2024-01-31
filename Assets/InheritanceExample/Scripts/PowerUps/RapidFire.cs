using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFire : PowerUpBase
{
    [SerializeField] private float _duration = 2f;
    float _rof;
    float _poweredROF;

    private void Awake()
    {
        gameObject.GetComponent<Collider>().enabled = true;
        _art.enabled = true;
        TurretController _turretCon = FindObjectOfType<TurretController>();
       
       _rof = _turretCon.FireCooldown;
       _poweredROF = _rof / 2f;
    }

    protected override void PowerUp()
    {
        _powerUpDuration = _duration;
        if (_poweredUp == true)
        {
            FindObjectOfType<TurretController>().FireCooldown = _poweredROF;
        }

    }
    protected override void PowerDown()
    {
        FindObjectOfType<TurretController>().FireCooldown = _rof;
        base.PowerDown();
    }
}
