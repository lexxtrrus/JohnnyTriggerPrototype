using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWeapon : MonoBehaviour
{
    [SerializeField] Transform player;

    //упорото, надо сделать лучше
    private void FixedUpdate()
    {
        Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 180f * Time.fixedDeltaTime);
    }
}
