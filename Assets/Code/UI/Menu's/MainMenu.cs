using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Main Game");
    }
    public void OnQuitButton()
    {
        Application.Quit();
    }
}
