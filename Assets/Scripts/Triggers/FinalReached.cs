using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalReached : MonoBehaviour
{
    [SerializeField] private GameObject resultsPanel;
    [SerializeField] private Button pauseButton;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.root.gameObject.TryGetComponent<Character>(out Character character))
        {
            Time.timeScale = 1f;
            CameraFollower.stopFollowing?.Invoke();
            resultsPanel.SetActive(true);
            pauseButton.enabled = false;
        }
    }
}
