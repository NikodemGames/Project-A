using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public float attackRange;
    public float attackSpeed;
    public float attackCD;
    public int projectileSpeed;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public Transform target;

    private void Start()
    {
        InvokeRepeating(nameof(TurretBehaviour), 0f, 0.5f);
    }
    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        Attack(target);
        attackCD -= Time.deltaTime;
    }
    public void TurretBehaviour()
    {
        Collider2D[] unitsInRange = null;
        float shortestDistance = Mathf.Infinity;
        Collider2D nearestEnemy=null;

        if (gameObject.CompareTag("PlayerTurret"))
        {
            unitsInRange = Physics2D.OverlapCircleAll(transform.position, attackRange, LayerMask.GetMask("Enemy"));
            
        }
        else if (gameObject.CompareTag("EnemyTurret"))
        {
            unitsInRange = Physics2D.OverlapCircleAll(transform.position, attackRange, LayerMask.GetMask("Player"));
        }
        foreach (Collider2D unit in unitsInRange)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, unit.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = unit;
            }
        }
        if(nearestEnemy != null&&shortestDistance <= attackRange)
        {
            target = nearestEnemy.transform;
        }
        else target = null;
    }
    
    public void Attack(Transform unitTransform)
    {
        if (attackCD <= 0)
        {

            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            if (gameObject.CompareTag("PlayerTurret"))
            {
                projectile.tag = "PlayerProjectile";
            }
            else projectile.tag = "EnemyProjectile";


            ProjectileController projectileController = projectile.GetComponent<ProjectileController>();
            projectileController.LaunchProjectile(unitTransform, projectileSpeed);
            attackCD = 1f / attackSpeed;
        }
       

    }
}
