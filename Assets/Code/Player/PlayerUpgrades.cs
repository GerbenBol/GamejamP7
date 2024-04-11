using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{
    private PlayerShooting shooting;
    private PlayerMovement movement;
    private Health health;
    private IconOnOff icons;

    private void Start()
    {
        shooting = GetComponent<PlayerShooting>();
        movement = GetComponent<PlayerMovement>();
        health = GetComponent<Health>();
        icons = GameObject.Find("Items").GetComponent<IconOnOff>();
    }

    public void AddUpgrade(string upgradeName)
    {
        switch (upgradeName)
        {
            case "SplitShot": SplitShot(); break;
            case "Heal": Heal(); break;
            case "BanzaiBill": BanzaiBill(); break;
            case "Speed": Speed(); break;
            case "Piercing": Piercing(); break;
            case "Rapidfire": RapidFire(); break;
            case "Lifesteal": Lifesteal(); break;
        }
    }

    private void SplitShot()
    {
        StopCoroutine(shooting.SplitShot());
        StartCoroutine(shooting.SplitShot());
    }

    private void Heal()
    {
        StopCoroutine(health.Heal());
        StartCoroutine(health.Heal());
    }

    private void BanzaiBill()
    {
        icons.Banzai(true);
        shooting._banzaiReady = true;
    }

    private void Speed()
    {
        StopCoroutine(movement.SpeedBoost());
        StartCoroutine(movement.SpeedBoost());
    }

    private void Piercing()
    {
        StopCoroutine(shooting.Pierce());
        StartCoroutine(shooting.Pierce());
    }

    private void RapidFire()
    {
        StopCoroutine(shooting.Rapidfire());
        StartCoroutine(shooting.Rapidfire());
    }

    private void Lifesteal()
    {
        StopCoroutine(shooting.Lifesteal());
        StartCoroutine(shooting.Lifesteal());
    }
}
