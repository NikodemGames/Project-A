using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmParentController : MonoBehaviour
{
    public GameManager gameManager;
    public EnemyAI enemyAI;
    bool killable=false;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        enemyAI = FindObjectOfType<EnemyAI>();
    }
    private void Update()
    {
        
    }
    private void Start()
    {
        StartCoroutine(CheckKillability());
        InvokeRepeating(nameof(KillParent), .1f, .1f);
    }
    public void KillParent()
    {
        if (transform.childCount == 0 && killable)
        {
            Destroy(gameObject);
            if (gameObject.CompareTag("Ally"))
            {
                gameManager.unitList.Remove(gameObject);
            }
            else enemyAI.enemyList.Remove(gameObject);
        }

    }
    private IEnumerator CheckKillability()
    {
        while (!killable)
        {
            if (transform.childCount > 0)
            {
                // Set killable to true if at least one child is present
                killable = true;
            }
            yield return null;
        }
    }
}
