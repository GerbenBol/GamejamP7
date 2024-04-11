using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject _Bullet;
    [SerializeField] private GameObject _BulletSpawn;
    [SerializeField] private GameObject _BanzaiBulletSpawn;
    [SerializeField] private Transform _SplitBulletSpawnMiddle;
    [SerializeField] private Transform _SplitBulletSpawnLeft;
    [SerializeField] private Transform _SplitBulletSpawnRight;

    private Quaternion _bulletRotation;

    private float _fireRate = 0.75f;    // Bullets per second 
    private float _spawnCoolDown;

    private bool _Pierce;
    private bool _SplitShot;
    private bool _Lifesteal;
    public bool _banzaiReady;
    private bool _banzaiUse;

    private bool _RapidFire;
    private float _RapidFireMultiplier;

    void Start()
    {
        _spawnCoolDown = 1 / _fireRate;
    }

    void Update()
    {
        _spawnCoolDown -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && _banzaiReady)
        {
            _banzaiReady = false;
            _banzaiUse = true;
        }

        // instantiates bullet with cooldown depending on fire rate.
        if (_spawnCoolDown <= 0)
        {
            if (_banzaiUse)
            {
                GameObject bullet = Instantiate(_Bullet, _BanzaiBulletSpawn.transform.position, transform.rotation);
                bullet.GetComponent<BulletBehavior>().banzai = true;
                _banzaiUse = false;
            }
            else if (_SplitShot)
            {
                GameObject[] bullets = new GameObject[3];

                bullets[0] = Instantiate(_Bullet, _SplitBulletSpawnMiddle.position, _SplitBulletSpawnMiddle.rotation);
                bullets[1] = Instantiate(_Bullet, _SplitBulletSpawnLeft.position, _SplitBulletSpawnLeft.rotation);
                bullets[2] = Instantiate(_Bullet, _SplitBulletSpawnRight.position, _SplitBulletSpawnRight.rotation);

                foreach (GameObject bullet in bullets)
                    bullet.GetComponent<BulletBehavior>().piercing = _Pierce;
            }
            else
            {
                GameObject bullet = Instantiate(_Bullet, _BulletSpawn.transform.position, transform.rotation);
                bullet.GetComponent<BulletBehavior>().piercing = _Pierce;
            }

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

    public IEnumerator Pierce()
    {
        _Pierce = true;
        yield return new WaitForSeconds(5);
        _Pierce = false;
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

    public void Heal()
    {
        if (_Lifesteal)
            GetComponent<Health>().Lifesteal();
    }
}
