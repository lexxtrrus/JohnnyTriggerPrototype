using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Assets/WeaponData", order = 1)]
public class WeaponData : ScriptableObject 
{
    public int capacityOfBullets;
    public GameObject bulletPrefab;
    public float fireRate;
    public float reloadTime;
    public float bulletSpeed;
    public int damage;
}