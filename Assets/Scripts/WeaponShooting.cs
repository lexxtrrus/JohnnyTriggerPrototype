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

        positions[0] = pointOfShoot.position;


        Physics.Raycast(pointOfShoot.position, pointOfShoot.right, out hit, 5f);
        
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
    }

    private void EndTargeting()
    {
        IsTargeting = false;
        lineRenderer.SetPosition(0, Vector3.zero);
        lineRenderer.SetPosition(1, Vector3.zero);
    }
}
