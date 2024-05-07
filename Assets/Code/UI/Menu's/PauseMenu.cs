using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool SwitchingScenes = false;

    [SerializeField] private GameObject canvas;

    public void OnResumeButton()
    {
        Cursor.lockState = CursorLockMode.Locked;
        canvas.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void OnMainMenuButton()
    {
        SwitchingScenes = true;
        SceneManager.LoadScene("Main Menu");
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}
