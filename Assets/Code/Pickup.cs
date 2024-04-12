using System.Collections;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private Transform[] lights;
    [SerializeField] private float minY, maxY;
    [SerializeField] private float modifier = .02f, cooldown = .005f;
    private bool goingDown = false;

    private void Start()
    {
        StartCoroutine(nameof(Flicker));
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
