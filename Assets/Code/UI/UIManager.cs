using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerTMP;
    [SerializeField] private TextMeshProUGUI pointsTMP;

    private float timer = .0f;
    private int points = 0;

    private void Update()
    {
        timer += Time.deltaTime;
        timerTMP.text = FormatTime();
    }

    public void AddPoints(int addPoints)
    {
        points += addPoints;
        pointsTMP.text = points.ToString();
    }

    private string FormatTime()
    {
        // Geef geformatteerde tijd terug
        TimeSpan ts = TimeSpan.FromSeconds(Convert.ToInt32(timer));
        return ts.ToString(@"mm") + ":" + ts.ToString(@"ss");
    }
}
