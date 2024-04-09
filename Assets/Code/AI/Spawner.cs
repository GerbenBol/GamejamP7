using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    private readonly List<Transform> spawners = new();
    private float maxTimer = 2.5f;
    private float timer = .0f;
    private float totalTimer = .0f;

    private void Awake()
    {
        spawners.Add(transform.GetChild(0));
        spawners.Add(transform.GetChild(1));
    }

    private void Update()
    {
        if (timer >= maxTimer)
        {
            Spawn();
            timer = .0f;
        }
        else timer += Time.deltaTime;

        if (totalTimer > 60)
        {
            maxTimer -= .5f;
            totalTimer = .0f;
        }
        else totalTimer += Time.deltaTime;
    }

    private void Spawn()
    {
        int rand = Random.Range(0, 2);
        Instantiate(enemy, spawners[rand]);
    }
}
