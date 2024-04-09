using UnityEngine;

public class Health : MonoBehaviour
{
    private int health;

    private void Start()
    {
        if (CompareTag("Player"))
            health = 100;
        else health = 20;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collider = collision.gameObject;

        if (collider.CompareTag("Bullet") || collider.CompareTag("Player") || collider.CompareTag("Enemy"))
            TakeHit();
    }

    private void TakeHit()
    {
        health -= 10;

        if (health <= 0)
            Destroy(gameObject);
    }
}
