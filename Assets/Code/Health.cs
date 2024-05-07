using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health;
    private bool player = false;
    private readonly float originalHealCD = 2;
    private float healCD;
    private float healTimer = .0f;
    private IconOnOff icons;
    [SerializeField] private GameObject _HealMod;
    [SerializeField] private AudioSource hitSFX;

    private void Start()
    {
        icons = GameObject.Find("Items").GetComponent<IconOnOff>();
        healCD = originalHealCD;

        if (CompareTag("Player"))
        {
            player = true;
            health = 100;
        }
        else health = 30;
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

        if (collider.CompareTag("Enemy"))
            TakeHit();
        else if (collider.CompareTag("Player"))
            TakeHit(100);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
            TakeHit(Convert.ToInt32(other.GetComponent<BulletBehavior>().damage));
    }

    public void Lifesteal()
    {
        health += 5;
    }

    public IEnumerator Heal()
    {
        healCD = .2f;
        icons.Heal(true);
        _HealMod.SetActive(true);
        yield return new WaitForSeconds(5);
        healCD = originalHealCD;
        icons.Heal(false);
        _HealMod.SetActive(false);
    }

    private void TakeHit(int damage = 10)
    {
        health -= damage;

        if (health <= 0 && player)
        {
            PauseMenu.SwitchingScenes = true;
            SceneManager.LoadScene("Lose Screen");
        }
        else if (health <= 0 && !player)
            Destroy(gameObject);
        else if (player)
            hitSFX.Play();
    }
}
