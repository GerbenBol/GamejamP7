using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerTMP;
    [SerializeField] TextMeshProUGUI pointsTMP;

    public static float timer = .0f;
    public static int points = 0;

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Main Game")
            timer += Time.deltaTime;

        timerTMP.text = FormatTime();
    }

    public void AddPoints(int addPoints)
    {
        points += addPoints;
        pointsTMP.text = points.ToString();
    }

    public static string FormatTime()
    {
        // Geef geformatteerde tijd terug
        TimeSpan ts = TimeSpan.FromSeconds(Convert.ToInt32(timer));
        return ts.ToString(@"mm") + ":" + ts.ToString(@"ss");
    }
}
