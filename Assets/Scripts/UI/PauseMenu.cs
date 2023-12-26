using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public void OnPauseButtonClicked()
    {
        bool isPaused = !gameObject.activeSelf;
        gameObject.SetActive(isPaused);

        Time.timeScale = isPaused ? 0 : 1; // Pause the game by setting Time.timeScale to 0
    }
}
