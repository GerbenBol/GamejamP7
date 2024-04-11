using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _Timer;
    [SerializeField] TextMeshProUGUI _Points;
    private void Start()
    {
        _Timer.text = UIManager.FormatTime();
        _Points.text = UIManager.points.ToString();
        Cursor.lockState = CursorLockMode.None;
    }
    public void OnRetryButton()
    {
        SceneManager.LoadScene("Main Game");
    }
    public void OnExitButton()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
