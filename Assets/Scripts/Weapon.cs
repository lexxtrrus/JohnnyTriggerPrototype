using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public abstract WeaponData WeaponData{get;}

    public abstract void Shoot();
}
