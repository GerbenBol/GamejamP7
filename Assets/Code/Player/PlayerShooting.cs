using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject _Bullet;
    [SerializeField] private Vector3 _BulletSpawn;

    private Quaternion _bulletRotation;

    private float _fireRate;    // Bullets per second 
    private float _spawnCoolDown;

    private bool _RapidFire;
    private float _RapifFireMultiplier;

    void Start()
    {
        _bulletRotation = transform.rotation;

        _spawnCoolDown = 1 / _fireRate;
    }

    void Update()
    {
        _spawnCoolDown -= Time.deltaTime;

        if (_spawnCoolDown <= 0)
        {
            Instantiate(_Bullet, _BulletSpawn, _bulletRotation);
            if (_RapidFire)
            {
                _spawnCoolDown = 1 / (_fireRate * _RapifFireMultiplier);
            } 
            else
            {
                _spawnCoolDown = 1 / _fireRate;
            }
        }
    }
}
