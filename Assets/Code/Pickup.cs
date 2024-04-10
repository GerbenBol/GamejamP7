using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerUpgrades>().AddUpgrade(name);
            Destroy(gameObject);
        }
    }
}
