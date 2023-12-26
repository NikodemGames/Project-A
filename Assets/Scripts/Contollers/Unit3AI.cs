using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit3AI : UnitController
{
    // Counter for tracking attacks
    public int attackCounter = 0;

    public override void Attack(Transform enemyTransform)
    {
        if(attackCounter < 2)
        {
            if (attackCD <= 0)
            {
                base.Attack(enemyTransform);
                attackCounter++;
                attackCD = 1f / stats.AttackSpeed;
            }
            

        }
        else if (attackCounter == 2)
        {
            if (attackCD <= 0)
            {
                StartCoroutine(PerformAOEAttack(stats.AttackDelay));
                attackCD = 1f / stats.AttackSpeed;
            }

        }


    }

    IEnumerator PerformAOEAttack(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            LayerMask enemyLayerMask = LayerMask.GetMask("Enemy");
            int enemyBaseLayer = LayerMask.NameToLayer("EnemyBase");
            LayerMask enemyBaseLayerMask = 1 << enemyBaseLayer;

            // Combine the masks to include both enemy layer and enemy base layer
            LayerMask combinedLayerMask = enemyLayerMask | enemyBaseLayerMask;

            // Get all enemies within the attack range
            Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, stats.Range, combinedLayerMask);

            // Damage all enemies in the AOE
            foreach (Collider2D enemyCollider in enemiesInRange)
            {
                if (enemyCollider != null)
                {
                    UnitController unitController = enemyCollider.GetComponent<UnitController>();
                    BaseController baseController = enemyCollider.GetComponent<BaseController>();

                    if (unitController != null)
                    {
                        unitController.TakeDamage(stats.BaseDamage * 2);
                    }
                    else if (baseController != null)
                    {
                        Debug.Log("aoe w baze jeb?o");
                        baseController.TakeDamage(stats.BaseDamage * 2);
                    }

                }
            }
        }
        else
        {
            LayerMask playerLayerMask = LayerMask.GetMask("Player");
            int playerBaseLayer = LayerMask.NameToLayer("PlayerBase");
            LayerMask playerBaseLayerMask = 1 << playerBaseLayer;

            // Combine the masks to include both enemy layer and enemy base layer
            LayerMask combinedLayerMask = playerLayerMask | playerBaseLayerMask;

            // Get all enemies within the attack range
            Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, stats.Range, combinedLayerMask);

            // Damage all enemies in the AOE
            foreach (Collider2D enemyCollider in enemiesInRange)
            {
                if (enemyCollider != null)
                {
                    UnitController unitController = enemyCollider.GetComponent<UnitController>();
                    BaseController baseController = enemyCollider.GetComponent<BaseController>();

                    if (unitController != null)
                    {
                        unitController.TakeDamage(stats.BaseDamage * 2);
                    }
                    else if (baseController != null)
                    {
                        Debug.Log("aoe w baze jeb?o");
                        baseController.TakeDamage(stats.BaseDamage * 2);
                    }

                }
            }
        }
        // Combine the LayerMask and tags using bit manipulation
        
        attackCounter = 0;
    }

    public override void Die()
    {
        base.Die();
        
        if (gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            gameManager.stats.Technology += 250;
            gameManager.stats.Resource += 125;
            enemyAI.enemyList.Remove(gameObject);
        }
        else if (gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            enemyAI.stats.Technology += 250;
            enemyAI.stats.Resource += 125;
            gameManager.unitList.Remove(gameObject);
        }
    }

}
