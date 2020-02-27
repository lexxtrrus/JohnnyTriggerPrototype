using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 1;

    private void OnEnable()
    {
        health = 1;
        var rigidbody = gameObject.GetComponent<Rigidbody>();
        rigidbody.isKinematic = true;
        rigidbody.velocity = Vector3.zero;
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
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
