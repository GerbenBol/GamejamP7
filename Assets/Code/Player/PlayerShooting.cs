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

    private bool _Lifesteal;
    private bool _Ricochet;
    private bool _SplitShot;

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
            GameObject bullet = Instantiate(_Bullet, _BulletSpawn.transform.position, transform.rotation);
            bullet.GetComponent<BulletBehavior>().ricochet = _Ricochet;

            if (_RapidFire)
                _spawnCoolDown = 1 / (_fireRate * _RapidFireMultiplier);
            else
                _spawnCoolDown = 1 / _fireRate;
        }
    }

    public IEnumerator SplitShot()
    {
        _SplitShot = true;
        yield return new WaitForSeconds(5);
        _SplitShot = false;
    }

    public void BanzaiBill()
    {

    }

    public IEnumerator Ricochet()
    {
        _Ricochet = true;
        yield return new WaitForSeconds(5);
        _Ricochet = false;
    }

    public IEnumerator Rapidfire()
    {
        _RapidFire = true;
        yield return new WaitForSeconds(5);
        _RapidFire = false;
    }

    public IEnumerator Lifesteal()
    {
        _Lifesteal = true;
        yield return new WaitForSeconds(5);
        _Lifesteal = false;
    }
}
