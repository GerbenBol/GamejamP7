using UnityEngine;

public class Health : MonoBehaviour
{
    private int health;
    private bool player = false;

    private void Start()
    {
        if (CompareTag("Player"))
        {
            player = true;
            health = 100;
        }
        else health = 20;
    }

    private void Update()
    {
        if (player)
            health++;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collider = collision.gameObject;

        if (collider.CompareTag("Bullet") || collider.CompareTag("Enemy"))
            TakeHit();
        else if (collider.CompareTag("Player"))
            TakeHit(100);
    }

    private void TakeHit(int damage = 10)
    {
        health -= damage;

        if (health <= 0)
            Destroy(gameObject);
    }
}
