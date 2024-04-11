using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScreen : MonoBehaviour
{
    private readonly float maxTimer = 4f;
    private float timer = .0f;

    private void Update()
    {
        if (timer < maxTimer)
            timer += Time.unscaledDeltaTime;
        else
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }
    }
}
