using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class RestartFinalPanel : MonoBehaviour //pause panel
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button pauseButton;
    [SerializeField] private GameObject finalpanel;
    [SerializeField] private Text tapToStartText;

    private void Awake()
    {
        restartButton.onClick.AddListener(RestartLevel);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }
}
