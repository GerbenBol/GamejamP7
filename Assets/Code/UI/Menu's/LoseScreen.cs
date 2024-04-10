using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{
    private void Start()
    {
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
