using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject pickup;

    private Transform player;
    private NavMeshAgent agent;
    private bool quitting = false;
    private readonly List<string> upgrades = new()
    {
        "SplitShot", "Heal",
        "BanzaiBill", "Speed",
        "Ricochet", "Rapidfire",
        "None"
    };

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        agent.SetDestination(player.position);
    }

    private void OnDestroy()
    {
        int rand = Random.Range(0, 20);

        if (!quitting && rand < upgrades.Count)
        {
            GameObject gO = Instantiate(pickup);
            gO.name = upgrades[rand];
        }
    }

    private void OnApplicationQuit()
    {
        quitting = true;
    }
}
