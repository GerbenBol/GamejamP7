using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject pickup;

    private UIManager ui;
    private Transform player;
    private NavMeshAgent agent;
    private bool quitting = false;
    private readonly List<string> upgrades = new()
    {
        "SplitShot", "Heal",
        "BanzaiBill", "Speed",
        "Ricochet", "Rapidfire",
        "Lifesteal"
    };

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        ui = GameObject.Find("UI").GetComponent<UIManager>();
    }

    private void Update()
    {
        agent.SetDestination(player.position);
    }

    private void OnDestroy()
    {
        int rand = Random.Range(0, 20);

        if (!quitting)
        {
            if (rand < upgrades.Count)
            {
                GameObject gO = Instantiate(pickup, transform.position, Quaternion.identity);
                gO.name = upgrades[rand];
            }
            ui.AddPoints(50);
        }
    }

    private void OnApplicationQuit()
    {
        quitting = true;
    }
}
