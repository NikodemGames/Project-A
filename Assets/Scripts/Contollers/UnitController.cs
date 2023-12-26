using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    public Transform playerBase;
    public Transform enemyBase;
    public Transform target;
    public BaseStats stats;

    [HideInInspector]public float attackCD = 0f;
    [SerializeField] private Transform targetBase;
    [HideInInspector] public GameManager gameManager;
    [HideInInspector] public EnemyAI enemyAI;
    private TextMeshPro healthText;

    private List<StatusEffect> activeEffects = new List<StatusEffect>();


    public void ApplyStatusEffect(StatusEffect effect)
    {
        if (!HasStatusEffect(effect))
        {
            activeEffects.Add(effect);
            effect.ApplyEffect(this);
        }
    }

    public void RemoveStatusEffect(StatusEffect effect)
    {
        if (HasStatusEffect(effect))
        {
            activeEffects.Remove(effect);
            effect.RemoveEffect(this);
        }
    }

    private bool HasStatusEffect(StatusEffect effect)
    {
        return activeEffects.Contains(effect);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        // Draw a wire sphere to represent the attack range
        Gizmos.DrawWireSphere(transform.position, stats.Range);
    }
    void Awake()
    {
        playerBase = GameObject.FindGameObjectWithTag("PlayerBase").transform;
        enemyBase = GameObject.FindGameObjectWithTag("EnemyBase").transform;

        gameManager = FindObjectOfType<GameManager>();
        enemyAI = FindObjectOfType<EnemyAI>();
        stats.CurrentHealth = stats.MaxHealth;
        GameObject healthTextObject = new GameObject("HealthText");
        healthTextObject.transform.SetParent(transform);
        healthTextObject.transform.localPosition = new Vector3(0f, 1.5f, 0f); // Adjust position above the unit

        healthText = healthTextObject.AddComponent<TextMeshPro>();
        healthText.alignment = TextAlignmentOptions.Center;
        healthText.fontSize = 6;
        healthText.color = Color.white;

    }
    //private void Start()
    //{
    //    BleedStatusEffect bleed = new BleedStatusEffect(maxHealth/20, .25f, 5);
    //    ApplyStatusEffect(bleed);
    //}
    private void Update()
    {
        if (healthText != null)
        {
            healthText.text = stats.CurrentHealth.ToString();
        }
        MoveToTargetBase();
        if (attackCD > 0)
        {
            attackCD -= Time.deltaTime;
        }

    }
    void MoveToTargetBase()
    {
        if (targetBase != null)
        {
            Collider2D[] unitsInRange = null;
            float shortestDistance = Mathf.Infinity;
            Collider2D nearestEnemy = null;

            if (gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                unitsInRange = Physics2D.OverlapCircleAll(transform.position, stats.Range, LayerMask.GetMask("Enemy"));
            }
            else if (gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                unitsInRange = Physics2D.OverlapCircleAll(transform.position, stats.Range, LayerMask.GetMask("Player"));
            }

            foreach (Collider2D unit in unitsInRange)
            {
                float distanceToEnemy = Vector2.Distance(transform.position, unit.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = unit;
                }
            }
            if (nearestEnemy != null && shortestDistance <= stats.Range)
            {
                target = nearestEnemy.transform;
                Attack(target);
            }
            else target = null;
            if(target == null)
            {

                Vector2 targetPosition = targetBase.position;
                targetPosition.y = transform.position.y;


                float targetX = gameObject.layer == LayerMask.NameToLayer("Player")
                    ? targetPosition.x - stats.Range
                    : targetPosition.x + stats.Range;

                if (gameObject.layer == LayerMask.NameToLayer("Player"))
                {
                    targetX -= targetBase.GetComponent<SpriteRenderer>().bounds.size.x / 2;
                }
                else
                {
                    targetX += targetBase.GetComponent<SpriteRenderer>().bounds.size.x / 2;
                }

                transform.position = Vector2.MoveTowards(transform.position, new Vector2(targetX, targetPosition.y), stats.MoveSpeed * Time.deltaTime);

                Collider2D theBase = null;

                if (gameObject.layer == LayerMask.NameToLayer("Player"))
                {
                    theBase = Physics2D.OverlapCircle(transform.position, stats.Range, LayerMask.GetMask("EnemyBase"));
                }
                else if (gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    theBase = Physics2D.OverlapCircle(transform.position, stats.Range, LayerMask.GetMask("PlayerBase"));
                }
                if(theBase != null)
                {
                    Attack(theBase.transform);
                }
            }
        }
    }


    public virtual void Attack(Transform enemyTransform)
    {
        if (attackCD <= 0)
        {

            StartCoroutine(DoDamage(enemyTransform, stats.AttackDelay));
            attackCD = 1f / stats.AttackSpeed;
        }

    }
    IEnumerator DoDamage(Transform enemyTransform, float delay)
    {
        yield return new WaitForSeconds(delay);
        if(enemyTransform.GetComponent<UnitController>() != null)
        {
            UnitController unitController = enemyTransform.GetComponent<UnitController>();
            unitController.TakeDamage(stats.BaseDamage);
        }
        else if (enemyTransform.GetComponent<BaseController>() != null)
        {
            BaseController baseController = enemyTransform.GetComponent<BaseController>();
            baseController.TakeDamage(stats.BaseDamage);
        }
        
    }
    public void TakeDamage(float damageAmount)
    {
        stats.CurrentHealth -= damageAmount;
        Debug.Log("ale mi pizgnal za" + damageAmount);
        if (stats.CurrentHealth <= 0)
        {
            Die();
            
        }
    }
    public virtual void Die()
    {
        Destroy(gameObject);
    }
    public void SetTargetBase(bool isEnemy)
    {
        Debug.Log("Live ssie");
        if (isEnemy)
        {
            targetBase = playerBase;
        }
        else
        {
            targetBase = enemyBase;
        }
    }
}
