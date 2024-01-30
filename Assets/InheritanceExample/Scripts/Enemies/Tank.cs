using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : EnemyBase
{
    private float _elapsedStunTime;
    private bool _isStunned = false;
    private float _stunCooldown = 1f;

    private void Update()
    {
        StunTracker();
    }
    protected override void OnHit()
    {
        Stun();
    }

    void StunTracker()
    {
        if (_isStunned == true)
        {
            _elapsedStunTime += Time.deltaTime;
            if (_elapsedStunTime >= _stunCooldown)
            {
                _isStunned = false;
                MoveSpeed = 0.05f;
            }
        }
        
    }
    void Stun()
    {
        MoveSpeed = 0f;
        _elapsedStunTime = 0;
        _isStunned = true;
    }
}
