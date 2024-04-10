using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private Rigidbody _rb;

    private float _bulletSpeed = 1000;
    private float _bulletLifeTime = 5; // in seconds

    public bool ricochet = false;
    private int ricochets = 5;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.AddRelativeForce(Vector3.forward * _bulletSpeed);
    }

    void Update()
    {
        Destroy(gameObject, _bulletLifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (ricochet && ricochets > 0)
            Ricochet();
        else
            Destroy(gameObject);
    }

    private void Ricochet()
    {
        //bounce to nearest enemy
        ricochets--;
    }
}
