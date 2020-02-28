using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaitTimeBeforeShoot : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private Health health;

    private void OnEnable()
    {
        health = GetComponent<Health>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var character = other.gameObject.GetComponent<Character>();
        {
            if(character)
            {
                if (health.lastTouched == null)
                {
                    weapon.Shoot();
                }
            }            
        }
    }



}
