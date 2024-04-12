using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    private readonly List<Transform> spawners = new();
    private float maxTimer = 2.5f;
    private float timer = .0f;
    private float totalTimer = .0f;
    private int spawnAmount = 2;
    private bool maxReached = false;

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

        if (!maxReached)
        {
            if (totalTimer > 60)
            {
                maxTimer -= .5f;
                totalTimer = .0f;
            }
            else totalTimer += Time.deltaTime;

            if (maxTimer <= .0f)
            {
                maxTimer = .3f;
                spawnAmount = 1;
                maxReached = true;
            }
        }
    }

    private void Spawn()
    {
        int rand = Random.Range(0, 2);

        for (int i = 0; i < spawnAmount; i++)
            Instantiate(enemy, spawners[rand]);
    }
}
