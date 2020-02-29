using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private Button pauseButton;
    [SerializeField] private GameObject pausePanel;


    private void OnEnable()
    {
        pauseButton.onClick.AddListener(ShowPausePanel);

        GameManager.OnRestartFromCheckPoint += ShowButton;
        Character.OnDeath += HideButton;
    }

    private void OnDisable()
    {
        GameManager.OnRestartFromCheckPoint -= ShowButton;
        Character.OnDeath -= HideButton;
    }

    private void ShowPausePanel()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        pauseButton.enabled = false;
    }

    private void ShowButton()
    {
        gameObject.SetActive(true);
    }

    private void HideButton()
    {
        gameObject.SetActive(false);
    }
 }
