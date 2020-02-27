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
    private float speedJump = 0.9f;

    private void Awake()
    {
        TapForStartCheck.OnTapForStartAction += StartFollowing;
    }

    private void OnDisable()
    {
        TapForStartCheck.OnTapForStartAction -= StartFollowing;
    }
    private void Update()
    {
        if (!IsFollowing) return;

        CameraMovement();
    }

    private void StartFollowing()
    {
        IsFollowing = true;
    }

    private void CameraMovement()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        var pos = transform.position;

        pos.y = startY + cameraRoute.Evaluate(iteration) * jumpHeight;

        transform.position = pos;
        iteration += Time.deltaTime * speedJump;

        if (iteration < 30f) return;
        iteration = 0f;
    }


}
