using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 1;
    [SerializeField] private Rigidbody rigidbody;

    public Bullet lastTouched { get; set; }

    private void OnEnable()
    {
        health = 1;
        lastTouched = null;
        rigidbody.isKinematic = true;
    }

    public void SetDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            StartCoroutine(HideCharacter());
        }
    }

    private IEnumerator HideCharacter()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);
        gameObject.transform.rotation = Quaternion.identity;
    }
}
