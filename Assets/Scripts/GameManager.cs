using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField] private Character player;
    [SerializeField] private CameraFollower camera;
    [SerializeField] private Transform[] enemies;
    [SerializeField] private Transform[] enemiesPlaces;
    [SerializeField] private Transform[] checkPoints;
    [SerializeField] private GameObject[] triggers;

    [SerializeField] private int countOfCheckpoint = 0;

    private Profile profile;

    public static Action<int> OnCheckpointReached;
    public static Action OnRestartFromCheckPoint;

    private void Awake()
    {
        OnCheckpointReached += SetCountOfCheckpoint;
        OnRestartFromCheckPoint += RestartFromCheckpoint;
        RestartFromCheckpoint();        
    }

    private void OnDisable()
    {
        OnCheckpointReached -= SetCountOfCheckpoint;
        OnRestartFromCheckPoint -= RestartFromCheckpoint;
    }

    private void SetCountOfCheckpoint(int index)
    {
        countOfCheckpoint = index;
    }

    public void RestartFromCheckpoint()
    {
        if (countOfCheckpoint == 0)
        {
            SetAllFirstCheckPoint();
        }

        if (countOfCheckpoint == 1)
        {
            SetAllSecondCheckPoint();
        }

    }

    public void SetAllFirstCheckPoint()
    {
        player.gameObject.SetActive(true);
        player.transform.position = checkPoints[0].position;
        player.transform.rotation = checkPoints[0].rotation;
        camera.transform.position = player.transform.position + new Vector3(1f, 0.75f, -15f);

        player.SetIteration(0f);
        camera.SetIteration(0f);

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].position = enemiesPlaces[i].position;
            enemies[i].rotation = enemiesPlaces[i].rotation;
            enemies[i].gameObject.SetActive(true);
        }

        foreach (var trigger in triggers)
        {
            trigger.SetActive(true);
        }
    }

    public void SetAllSecondCheckPoint()
    {
        player.gameObject.SetActive(true);
        player.SetIteration(10.5f);
        player.transform.position = checkPoints[1].position;
        player.transform.rotation = Quaternion.identity;
        camera.SetIteration(15f);
        camera.transform.position = player.transform.position + new Vector3(1f, 4.55f, -15f);

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].position = enemiesPlaces[i].position;
            enemies[i].rotation = enemiesPlaces[i].rotation;
            enemies[i].gameObject.SetActive(true);
        }

        foreach (var trigger in triggers)
        {
            trigger.SetActive(true);
        }
    }

}
