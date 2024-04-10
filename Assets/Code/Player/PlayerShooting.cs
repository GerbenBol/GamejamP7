using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject _Bullet;
    [SerializeField] private GameObject _BulletSpawn;

    private Quaternion _bulletRotation;

    private float _fireRate = 0.75f;    // Bullets per second 
    private float _spawnCoolDown;

    private bool _RapidFire;
    private float _RapidFireMultiplier;

    void Start()
    {
        _spawnCoolDown = 1 / _fireRate;
    }

    void Update()
    {
        _spawnCoolDown -= Time.deltaTime;

        // instantiates bullet with cooldown depending on fire rate.
        if (_spawnCoolDown <= 0)
        {
            Instantiate(_Bullet, _BulletSpawn.transform.position, transform.rotation);
            if (_RapidFire)
                _spawnCoolDown = 1 / (_fireRate * _RapidFireMultiplier);
            else
                _spawnCoolDown = 1 / _fireRate;
        }
    }

    public IEnumerator SplitShot()
    {

    }

    public IEnumerator Rapidfire()
    {
        _RapidFire = true;
        yield return new WaitForSeconds(5);
        _RapidFire = false;
    }
}
