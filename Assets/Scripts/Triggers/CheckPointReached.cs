using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointReached : MonoBehaviour
{
    [SerializeField] private Material matGreen;
    [SerializeField] private int countOfCheckpoint = 1;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.root.gameObject.TryGetComponent<Character>(out Character character))
        {
            GameManager.OnCheckpointReached(countOfCheckpoint);
            gameObject.GetComponent<Renderer>().material.color = matGreen.color;

            
        }
    }
}

