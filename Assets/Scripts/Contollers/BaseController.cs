using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Linq;

public class BaseController : MonoBehaviour
{
    public TurretSlot[] turretSlots;
    public GameObject[] turretPrefabs;
    public int baseLevel;
    public float maxHealth = 500;
    public float currentHealth; 
    public TextMeshProUGUI baseHealth;
    public int turrets;
    private GameManager gameManager;
    private EnemyAI enemyAI;
    void Start()
    {
        currentHealth = maxHealth;
        baseLevel = 1;
        turrets = 0;
    }
    private void Update()
    {
        baseHealth.text = "HP: " + currentHealth + "/ " + maxHealth;
    }
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        enemyAI = FindObjectOfType<EnemyAI>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;


        if (currentHealth <= 0)
        {

            DestroyBase();
        }
    }

    public void PlaceTurret()
    {
        bool isPlayerBase = gameObject.CompareTag("PlayerBase");
        float technology = isPlayerBase ? gameManager.stats.Technology : enemyAI.stats.Technology;
        float resources = isPlayerBase ? gameManager.stats.Resource : enemyAI.stats.Resource;

        if (technology < 400 || resources < 200)
        {
            Debug.Log("Not enough Resources");
            return;

        }

        if (isPlayerBase)
        {
            gameManager.stats.Technology -= 400;
            gameManager.stats.Resource -= 200;
        }
        else if (!isPlayerBase)
        {
            enemyAI.stats.Technology -= 400;
            enemyAI.stats.Resource -= 200;
        }
        TurretSlot slot = null;
        foreach (TurretSlot turretSlot in turretSlots)
        {
            if (!turretSlot.isOccupied)
            {
                slot = turretSlot;
                break;
            }
            else
            {
                Debug.Log("this isn't empty");
            }
        }

        if (slot != null && turrets < baseLevel)
        {
            GameObject turret = Instantiate(turretPrefabs[0], slot.position, Quaternion.identity);
            slot.isOccupied = true;
            slot.placedTurret = turret;
            turrets++;
        }
        else
        {
            Debug.Log("no empty slots");
        }
    }


    public void UpgradeBase()
    {
        if (gameObject.CompareTag("PlayerBase"))
        {
            switch (baseLevel)
            {
                case 1:
                    if (gameManager.stats.Technology < 500) break;
                    gameManager.stats.Technology -= 500;
                    currentHealth += maxHealth / 2;
                    maxHealth += maxHealth/2;
                    baseLevel++;
                    break;
                case 2:
                    if(gameManager.stats.Technology < 1000) break;
                    gameManager.stats.Technology -= 1000;
                    currentHealth += maxHealth / 2;
                    maxHealth += maxHealth / 2;
                    baseLevel++;
                    break;
                default:
                    break;
            }
        }
        else
        {
            
        }
        

    }
    private void DestroyBase()
    {

        Destroy(gameObject);
    }
}

