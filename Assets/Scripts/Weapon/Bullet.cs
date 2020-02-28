using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int damage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.root.gameObject.TryGetComponent<Health>(out Health health))
        {
            if (health.lastTouched != null) return;
            health.SetDamage(damage);
            var rigidbody = health.gameObject.GetComponent<Rigidbody>();
            rigidbody.isKinematic = false;
            rigidbody.freezeRotation = false;            
            rigidbody.AddForce((transform.position - health.transform.position) * 1f, ForceMode.Impulse);

            if (collision.collider.TryGetComponent<HeadRotation>(out HeadRotation head))
            {
                health.lastTouched = this;
                MoneyCounter.OnBulletTouched?.Invoke(15);
                return;
            }

            if (collision.collider.TryGetComponent<BodyLogic>(out BodyLogic body))
            {
                health.lastTouched = this;
                MoneyCounter.OnBulletTouched?.Invoke(10);
                return;
            }
        }

        StartCoroutine(HideBullet());
    }

    public void SetDamage(int value)
    {
        damage = value;
    }

    private IEnumerator HideBullet()
    {
        yield return new WaitForSeconds(0f);
        gameObject.SetActive(false);
    }
}
