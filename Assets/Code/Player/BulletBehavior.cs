using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private Rigidbody _rb;

    private float _bulletSpeed = 1000;
    private float _bulletLifeTime = 5; // in seconds

    public bool piercing;
    private int pierce = 2;

    public bool banzai;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.AddRelativeForce(Vector3.forward * _bulletSpeed);

        if (banzai)
            transform.localScale *= 4;
    }

    void Update()
    {
        if (banzai)
            Destroy(gameObject, _bulletLifeTime * 2);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup") || banzai)
            return;

        if (!piercing || pierce < 0)
            Destroy(gameObject);
        else pierce--;
    }
}
