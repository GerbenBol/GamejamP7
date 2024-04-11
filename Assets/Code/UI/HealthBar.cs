using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image _Bar;
    [SerializeField] GameObject _Player;
    private int _playerHealth;
    private Health health;
    void Start()
    {
        //_Player.GetComponent<Health>();
        health = _Player.GetComponent<Health>();
    }

    void Update()
    {
        _playerHealth = health.health;
        _Bar.fillAmount = 1.0f / 100 * _playerHealth;
    }
}
