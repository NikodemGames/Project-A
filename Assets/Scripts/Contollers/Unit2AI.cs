using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit2AI : UnitController
{
    public override void Die()
    {
        if (gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            gameManager.stats.Technology += 150;
            gameManager.stats.Resource += 75;
            enemyAI.enemyList.Remove(gameObject);
        }
        else if (gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            enemyAI.stats.Technology += 150;
            enemyAI.stats.Resource += 75;
            gameManager.unitList.Remove(gameObject);
        }
        base.Die();
        
    }
}
