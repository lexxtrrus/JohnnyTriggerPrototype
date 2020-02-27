using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeaponShooting : MonoBehaviour
{
    [SerializeField] private Transform pointOfShoot;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private float dinstanceOfLine = 4f;

    public static Action OnStartTargeting;
    public static Action OnEndTargeting;

    private Vector3[] positions = new Vector3[2];
    private RaycastHit hit;
    private bool IsTargeting = false;

    private void Awake()
    {
        OnStartTargeting += StartTargeting;
        OnEndTargeting += EndTargeting;
    }

    private void OnDisable()
    {
        OnStartTargeting -= StartTargeting;
        OnEndTargeting -= EndTargeting;
    }

    private void Update()
    {
        if (!IsTargeting) return;

        Debug.Log("draw line");

        positions[0] = pointOfShoot.position;

        Physics.Raycast(pointOfShoot.localPosition, pointOfShoot.right, out hit, dinstanceOfLine);
        
        if(hit.collider != null)
        {
            positions[1] = hit.point;
        }
        else
        {
            positions[1] = pointOfShoot.position + pointOfShoot.right * dinstanceOfLine;
        }

        lineRenderer.SetPositions(positions);
    }

    private void StartTargeting()
    {
        IsTargeting = true;
        Debug.Log("start");
    }

    private void EndTargeting()
    {
        IsTargeting = false;
        Debug.Log("finish");
    }
}
