using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private Button pauseButton;
    [SerializeField] private GameObject pausePanel;

    private void Awake()
    {
        pauseButton.onClick.AddListener(LoadGame);
    }

    private void LoadGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        pauseButton.enabled = false;
    }
}
