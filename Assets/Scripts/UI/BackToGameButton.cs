using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BackToGameButton : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Button backToGameButton;
    [SerializeField] private Button pauseButton;

    private void Awake()
    {
        backToGameButton.onClick.AddListener(BackTogame);
    }

    private void BackTogame()
    {
        pauseButton.enabled = true;
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        //Character.OnStartWaiting?.Invoke();
    }
}
