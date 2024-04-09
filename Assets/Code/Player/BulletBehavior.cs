using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private Rigidbody _rb;

    private float _bulletSpeed = 1000;
    private float _bulletLifeTime = 5; // in seconds
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(Vector3.forward * _bulletSpeed);
    }
    void Update()
    {
        Destroy(gameObject, _bulletLifeTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
