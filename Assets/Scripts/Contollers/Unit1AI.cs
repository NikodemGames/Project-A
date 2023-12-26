using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit1AI : UnitController
{
    public override void Die()
    {
        base.Die();
        if (gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            gameManager.stats.Technology += 50;
            gameManager.stats.Resource += 25;
        }
        else if(gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            enemyAI.stats.Technology += 50;
            enemyAI.stats.Resource += 25;
        }
        
            
    }
}
