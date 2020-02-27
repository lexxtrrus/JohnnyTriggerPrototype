using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    [SerializeField] private WeaponData gunDataInfo;
    [SerializeField] Transform pointOfShoot;
    
    private GameObject bulletPrefab;
    private float startShootingTime = 0f;
    [SerializeField] private int bulletsInAction = 0;
    private int maxCountOfBullets;
    public List<GameObject> bullets = new List<GameObject>();

    public override WeaponData WeaponData { get => gunDataInfo; }

    public override void Shoot()
    {
        if(Time.time - startShootingTime > WeaponData.fireRate)
        {
            if(bulletsInAction < maxCountOfBullets)
            {
                RemoveBullet();
                bullets[bulletsInAction- 1].SetActive(true);
                bullets[bulletsInAction -1].transform.parent = null;
                bullets[bulletsInAction -1].GetComponent<Rigidbody>().velocity = pointOfShoot.right * WeaponData.bulletSpeed;
                StartCoroutine(AddBullet(bullets[bulletsInAction - 1]));
                startShootingTime = Time.time;
            }
        }
    }

    private void Awake() 
    {
        bulletPrefab = WeaponData.bulletPrefab;
        maxCountOfBullets = WeaponData.capacityOfBullets;

        for (int i = 0; i < WeaponData.capacityOfBullets; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity);
            bullet.GetComponent<Bullet>().SetDamage(WeaponData.damage);
            bullets.Add(bullet);
            SetBulletInRightPlace(bullet);
        }
    }

    private void RemoveBullet()
    {
        bulletsInAction++;
        BulletCapacityPanel.OnBulletRemoved?.Invoke();
    }

    private IEnumerator AddBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(WeaponData.reloadTime);
        bulletsInAction--;
        SetBulletInRightPlace(bullet);
        BulletCapacityPanel.OnBulletAdded?.Invoke();
    }

    private void SetBulletInRightPlace(GameObject bullet)
    {
        bullet.transform.SetParent(pointOfShoot);
        bullet.transform.localPosition = Vector3.zero;
        bullet.transform.localRotation = Quaternion.Euler(Vector3.zero);
        bullets[bullets.IndexOf(bullet)].SetActive(false);
    }
}
