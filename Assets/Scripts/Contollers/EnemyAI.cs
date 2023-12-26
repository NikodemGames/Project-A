using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour
{
    public UnitController[] enemyPrefab;
    [SerializeField]private float resourceCost;
    private GameManager gameManager;
    public List<GameObject> enemyList = new();
    private BaseController baseController;
    public BuildingStats stats;
    [SerializeField]
    private int SpawnLimit = 0;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        baseController = gameObject.GetComponent<BaseController>();
        InvokeRepeating(nameof(TechController), 5, 15);
        InvokeRepeating(nameof(PayTime), 0.5f, 0.5f);
        InvokeRepeating(nameof(SpawnerAI), 3f, 1.5f);
        InvokeRepeating(nameof(ResetSpawnLimit), 13, 10);
    }
    void SpawnerAI()
    {
        if (SpawnLimit > 2) return;
        float timeElapsed = Time.timeSinceLevelLoad;

        int chance = Random.Range(1, 1000);
        int unitToSpawn = 0;
        Debug.Log(chance);

        if (timeElapsed < 45)
        {
            if (chance <= 800) return;


            unitToSpawn = chance <= 950 ? 0 : 1;
        }
        else if (timeElapsed < 90)
        {
            if (chance <= 700) return;
            if (chance <= 825) unitToSpawn = 0;
            if (chance < 950) unitToSpawn = 1;
            else unitToSpawn = 2;
        }
        else if(timeElapsed >=90)
        {
            if (chance <= 600) return;
            if(chance <= 750) unitToSpawn= 0;
            if (chance <= 900) unitToSpawn = 1;
            unitToSpawn = chance <=960 ? 2 : 3;
        }

        StartCoroutine(SpawnUnit(unitToSpawn));
        SpawnLimit++;
    }
    public void ResetSpawnLimit()
    {
        SpawnLimit = 0;
    }


    IEnumerator SpawnUnit(int index)
    {
        Debug.Log("Spawning - " + enemyPrefab[index].name);
        yield return new WaitForSeconds(enemyPrefab[index].stats.SpawnDelay);

        if (enemyPrefab[index].stats.Copies>1)
        {
            GameObject unitGroup = new("EnemyUnitGroup");
            unitGroup.AddComponent<SwarmParentController>();
            unitGroup.tag = "Enemy";

            for (int i = 0; i < enemyPrefab[index].stats.Copies; i++)
            {
                yield return new WaitForSeconds(.1f);
                GameObject newUnit = Instantiate(enemyPrefab[index].gameObject, stats.SpawnPoint.position, Quaternion.identity);
                newUnit.transform.SetParent(unitGroup.transform);

                
                if (newUnit.TryGetComponent<UnitController>(out var unitController))
                {
                    unitController.SetTargetBase(true);
                }
                else yield break;
            }
            enemyList.Add(unitGroup);
        }
        else
        {
            GameObject newEnemy = Instantiate(enemyPrefab[index].gameObject, stats.SpawnPoint.position, Quaternion.identity);
            UnitController unitController = newEnemy.GetComponent<UnitController>();
            enemyList.Add(newEnemy);
            if (unitController != null)
            {
                unitController.SetTargetBase(true);
            }
            else yield break;
        }

    }

    public void TechController()
    {
        baseController.PlaceTurret();
        baseController.UpgradeBase();
    }

    public void PayTime()
    {
        
        stats.Resource += stats.Payment;
    }
}
