using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuLoad : MonoBehaviour 
{ 
    [SerializeField] private Button menuButton;

    private void Awake()
    {
        menuButton.onClick.AddListener(LoadMenu);
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene(0);
        GameManager.OnCheckpointReached?.Invoke(0);
    }
}

