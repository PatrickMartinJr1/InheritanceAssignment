using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class PowerUpBase : MonoBehaviour
{
    [SerializeField] private AudioClip _powerUpSound;
    [SerializeField] protected MeshRenderer _art;
    protected float _powerUpDuration;
    private float _elapsedTime;
    protected bool _poweredUp;

    protected abstract void PowerUp();

    private void Update()
    {
        DurationTracker();
    }

    private void OnTriggerEnter(Collider other)
    {
        Projectile projectile = other.GetComponent<Projectile>();
        if (projectile != null)
        {
            OnHit();
            
        }
    }

    private void OnHit()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        _art.enabled = false;
        _elapsedTime = 0;
        _poweredUp = true;
        PowerUp();


        
        if (_powerUpSound != null)
        {
            AudioHelper.PlayClip2D(_powerUpSound, 1, .1f);
        }

    }

    protected virtual void PowerDown()
    {

        gameObject.SetActive(false);
    }

    private void DurationTracker()
    {
        if (_poweredUp == true)
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= _powerUpDuration)
            {
                PowerDown();
            }
        }
    }

}
