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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            BanzaiBill();
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
        StartCoroutine(nameof(shooting.SplitShot));
    }

    private void Heal()
    {
        StartCoroutine(nameof(health.Heal));
    }

    private void BanzaiBill()
    {
        shooting._banzaiReady = true;
    }

    private void Speed()
    {
        StartCoroutine(nameof(movement.SpeedBoost));
    }

    private void Piercing()
    {
        StartCoroutine(nameof(shooting.Pierce));
    }

    private void RapidFire()
    {
        StartCoroutine(nameof(shooting.Rapidfire));
    }

    private void Lifesteal()
    {
        StartCoroutine(nameof(shooting.Lifesteal));
    }
}
