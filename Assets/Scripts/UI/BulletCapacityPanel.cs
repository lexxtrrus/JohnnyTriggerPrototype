using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BulletCapacityPanel : MonoBehaviour
{
    [SerializeField] private List<Image> images = new List<Image>();
    private int count = 7;

    public static  Action OnBulletRemoved;
    public static  Action OnBulletAdded;


    private void OnEnable()
    {
        OnBulletAdded += AddImage;
        OnBulletRemoved += RemoveImage;
        GameManager.OnRestartFromCheckPoint += ResetBullets;
    }

    private void ResetBullets()
    {
        foreach (var image in images)
        {
            image.enabled = true;
        }

        count = 7;
    }

    private void OnDisable()
    {
        OnBulletAdded -= AddImage;
        OnBulletRemoved -= RemoveImage;
        GameManager.OnRestartFromCheckPoint -= ResetBullets;
    }

    private void RemoveImage()
    {
        if(count > 0)
        {
            count--;
            images[count].enabled = false;
        }
    }

    private void AddImage()
    {      
        if(count < 7)
        {
            images[count].enabled = true;
            count++;
        }
    }



}
