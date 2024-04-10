using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    private int health;
    private bool player = false;
    private readonly float originalHealCD = 2;
    private float healCD;
    private float healTimer = .0f;

    private void Start()
    {
        healCD = originalHealCD;

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
        {
            if (healTimer > healCD)
            {
                healTimer = .0f;
                health++;
            }
            else healTimer += Time.deltaTime;
        }
    }

    private void LateUpdate()
    {
        if (player && health > 100)
            health = 100;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collider = collision.gameObject;

        if (collider.CompareTag("Bullet") || collider.CompareTag("Enemy"))
            TakeHit();
        else if (collider.CompareTag("Player"))
            TakeHit(100);
    }

    public void Lifesteal()
    {
        health += 5;
    }

    public IEnumerator Heal()
    {
        healCD = .2f;
        yield return new WaitForSeconds(5);
        healCD = originalHealCD;
    }

    private void TakeHit(int damage = 10)
    {
        health -= damage;

        if (health <= 0 && !player)
            Destroy(gameObject);
        else if (health <= 0 && player)
            SceneManager.LoadScene("Lose Screen");
    }
}
