using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BulletCapacityPanel : MonoBehaviour
{
    [SerializeField] private List<Image> images = new List<Image>();
    private int count = 0;

    public static  Action OnBulletRemoved;
    public static  Action OnBulletAdded;

    private void OnEnable()
    {
        count = images.Count;
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
    }

    private void OnDisable()
    {
        OnBulletAdded -= AddImage;
        OnBulletRemoved -= RemoveImage;
        GameManager.OnRestartFromCheckPoint -= ResetBullets;
    }

    private void RemoveImage()
    {
        count--;
        images[count].enabled = false;
    }

    private void AddImage()
    {        
        images[count].enabled = true; 
        count++;
    }



}
