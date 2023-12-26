using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private Rigidbody2D rb;
    public int damage;
    private bool hasHit=false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke(nameof(Die),3);
    }

    public void LaunchProjectile(Transform target, float speed)
    {
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * speed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        UnitController unitController = collision.gameObject.GetComponent<UnitController>();

        if (unitController != null && !hasHit)
        {
            bool isPlayerProjectile = gameObject.CompareTag("PlayerProjectile") && collision.gameObject.layer == LayerMask.NameToLayer("Enemy");
            bool isEnemyProjectile = gameObject.CompareTag("EnemyProjectile") && collision.gameObject.layer == LayerMask.NameToLayer("Player");

            if (isPlayerProjectile || isEnemyProjectile)
            {
                unitController.TakeDamage(damage);
                hasHit = true;
                Die();
            }
        }
        if (collision.gameObject.CompareTag("Terrain"))
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }

}
