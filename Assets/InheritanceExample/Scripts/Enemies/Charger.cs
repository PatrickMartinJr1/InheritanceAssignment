using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charger : EnemyBase
{
   // [SerializeField] private Transform _powerUpSpawnLoc;
    [SerializeField] private GameObject _powerUpToSpawn;
    protected override void OnHit()
    {
        //increase speed when hit
        MoveSpeed *= 2;
    }

    public override void Kill()
    {
        Instantiate(_powerUpToSpawn, transform.position, transform.rotation);
        base.Kill();
    }
    
}
