using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    [SerializeField] private GameObject canvas;

    private void Start()
    {
        UIManager.timer = 0;
        UIManager.points = 0;
        Time.timeScale = 0f;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            canvas.SetActive(true);
        }

        //Temp win condition
        if (Input.GetKeyDown(KeyCode.P) && Time.timeScale == 1)
        {
            SceneManager.LoadScene("Win Screen");
        }
    }
}
