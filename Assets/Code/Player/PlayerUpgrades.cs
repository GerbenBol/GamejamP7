using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{
    private PlayerShooting shooting;
    private PlayerMovement movement;
    private Health health;

    private void Start()
    {
        shooting = GetComponent<PlayerShooting>();
        movement = GetComponent<PlayerMovement>();
        health = GetComponent<Health>();
    }

    public void AddUpgrade(string upgradeName)
    {
        switch (upgradeName)
        {
            case "SplitShot": SplitShot(); break;
            case "Heal": Heal(); break;
            case "BanzaiBill": BanzaiBill(); break;
            case "Speed": Speed(); break;
            case "Ricochet": Ricochet(); break;
            case "Rapidfire": RapidFire(); break;
            case "Lifesteal": Lifesteal(); break;
        }
    }

    private void SplitShot()
    {

    }

    private void Heal()
    {
        StartCoroutine(nameof(health.Heal));
    }

    private void BanzaiBill()
    {

    }

    private void Speed()
    {
        StartCoroutine(nameof(movement.SpeedBoost));
    }

    private void Ricochet()
    {

    }

    private void RapidFire()
    {

    }

    private void Lifesteal()
    {

    }
}
