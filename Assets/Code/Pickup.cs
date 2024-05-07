using System.Collections;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private Transform[] lights;
    [SerializeField] private float minY, maxY;
    [SerializeField] private float modifier = .02f, cooldown = .01f;
    private bool goingDown = false;

    //Sprites
    [SerializeField] private GameObject banzaiSprite;
    [SerializeField] private GameObject healSprite;
    [SerializeField] private GameObject lifeStealSprite;
    [SerializeField] private GameObject piercingSprite;
    [SerializeField] private GameObject rapidFireSprite;
    [SerializeField] private GameObject speedBoostSprite;
    [SerializeField] private GameObject splitShotSprite;

    private void Start()
    {
        StartCoroutine(nameof(Flicker));

        if (gameObject.name.Contains("BanzaiBill"))
            banzaiSprite.SetActive(true);
        if (gameObject.name.Contains("Heal"))
            healSprite.SetActive(true);
        if (gameObject.name.Contains("Lifesteal"))
            lifeStealSprite.SetActive(true);
        if (gameObject.name.Contains("Piercing"))
            piercingSprite.SetActive(true);
        if (gameObject.name.Contains("Rapidfire"))
            rapidFireSprite.SetActive(true);
        if (gameObject.name.Contains("Speed"))
            speedBoostSprite.SetActive(true);
        if (gameObject.name.Contains("SplitShot"))
            splitShotSprite.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerUpgrades>().AddUpgrade(name);
            Destroy(gameObject);
        }
    }

    private IEnumerator Flicker()
    {
        while (true)
        {
            if (goingDown)
            {
                lights[1].position += new Vector3(0, -modifier, 0);

                if (lights[1].localPosition.y <= minY)
                    goingDown = false;
            }
            else
            {
                lights[1].position += new Vector3(0, modifier, 0);

                if (lights[1].localPosition.y >= maxY)
                    goingDown = true;
            }
            yield return new WaitForSeconds(cooldown);
        }
    }
}
