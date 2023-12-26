using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit4AI : UnitController
{
    public override void Die()
    {
        base.Die();

        if (gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            gameManager.stats.Technology += 100;
            gameManager.stats.Resource += 50;
            enemyAI.enemyList.Remove(gameObject);
        }
        else if (gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            enemyAI.stats.Technology += 100;
            enemyAI.stats.Resource += 50;
            gameManager.unitList.Remove(gameObject);
        }
    }
}
