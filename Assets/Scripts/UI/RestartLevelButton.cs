using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class RestartLevelButton : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button pauseButton;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Text tapToStartText;

    private void Awake()
    {
        restartButton.onClick.AddListener(CheckpointLoad);
    }

    private void CheckpointLoad()
    {
        pauseButton.enabled = true;
        tapToStartText.gameObject.SetActive(true);
        GameManager.OnRestartFromCheckPoint?.Invoke();
        Character.OnStartWaiting?.Invoke();
        CameraFollower.stopFollowing?.Invoke();
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
