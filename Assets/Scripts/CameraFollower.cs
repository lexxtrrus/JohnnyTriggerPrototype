using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private AnimationCurve cameraRoute;
    private bool IsFollowing;
    private float speed = 2f;
    private float startY = -3f;
    private float iteration = 0f;
    private float jumpHeight = 1f;
    private float speedJump = 1f;

    public static Action stopFollowing;

    private void Awake()
    {
        TapForStartCheck.OnTapForStartAction += StartFollowing;
        stopFollowing += StopFollowing;
    }

    private void OnDisable()
    {
        TapForStartCheck.OnTapForStartAction -= StartFollowing;
        stopFollowing -= StopFollowing;
    }
    /*
    private void Update()
    {
        

        CameraMovement();
    }*/

    private void StartFollowing()
    {
        IsFollowing = true;
    }

    private void StopFollowing()
    {
        IsFollowing = false;
    }

    public void CameraMovement()
    {
        if (!IsFollowing) return;

        transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);

        var pos = transform.position;

        pos.y = startY + cameraRoute.Evaluate(iteration) * jumpHeight;

        transform.position = pos;
        iteration += Time.deltaTime * speedJump;

        if (iteration < 30f) return;
        iteration = 0f;
    }

    public void SetIteration(float iteration)
    {
        this.iteration = iteration;
    }


}
