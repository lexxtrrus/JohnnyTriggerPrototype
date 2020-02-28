using UnityEngine;
using System.Collections;

public class ResultPanel : MonoBehaviour
{
    [SerializeField] private GameObject resultPanel;

    private void Awake()
    {
        GameManager.OnRestartFromCheckPoint += HidePanel;
        Character.OnDeath += ShowPanel;
    }

    private void OnDisable()
    {
        GameManager.OnRestartFromCheckPoint -= HidePanel;
        Character.OnDeath -= ShowPanel;
    }

    private void ShowPanel()
    {
        resultPanel.SetActive(true);
    }

    private void HidePanel()
    {
        resultPanel.SetActive(false);
    }
}
