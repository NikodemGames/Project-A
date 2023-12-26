using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public List<GameObject> unitList = new();
    public TextMeshProUGUI resourceText;
    public Button[] spawnButtons;
    public BuildingStats stats;
    private float resourceCost;
    public IEnumerator SpawnUnit(int buttonIndex)
    {
        switch (buttonIndex)
        {
            case 0:
                resourceCost = TeamSlots.instance.units[0].Cost;
                if (stats.Resource >= resourceCost)
                {
                    stats.Resource -= resourceCost;
                    yield return new WaitForSeconds(TeamSlots.instance.units[0].Prefab.GetComponent<UnitController>().stats.SpawnDelay);
                    if (TeamSlots.instance.units[0].Prefab.GetComponent<UnitController>().stats.Copies >1)
                    {
                        GameObject unitGroup = new("UnitGroup");
                        unitGroup.AddComponent<SwarmParentController>();
                        unitGroup.tag = "Ally";
                        
                        for (int j = 0; j<TeamSlots.instance.units[0].Prefab.GetComponent<UnitController>().stats.Copies; j++)
                        {
                            yield return new WaitForSeconds(.1f);
                            GameObject newUnit = Instantiate(TeamSlots.instance.units[0].Prefab, stats.SpawnPoint.position, Quaternion.identity);
                            newUnit.transform.SetParent(unitGroup.transform);


                            UnitController unitController = newUnit.GetComponent<UnitController>();

                            if (unitController != null)
                            {
                                unitController.SetTargetBase(false);
                            }
                            else break;
                        }
                        unitList.Add(unitGroup);
                    }
                    else
                    {
                        yield return new WaitForSeconds(TeamSlots.instance.units[0].Prefab.GetComponent<UnitController>().stats.SpawnDelay);
                        GameObject newUnit = Instantiate(TeamSlots.instance.units[0].Prefab, stats.SpawnPoint.position, Quaternion.identity);
                        unitList.Add(newUnit);
                        UnitController unitController = newUnit.GetComponent<UnitController>();

                        if (unitController != null)
                        {
                            unitController.SetTargetBase(false);
                        }
                        else break;
                    }


                }
                else break;
                break;
            case 1:
                resourceCost = TeamSlots.instance.units[1].Cost;
                if (stats.Resource >= resourceCost)
                {
                    stats.Resource -= resourceCost;
                    yield return new WaitForSeconds(TeamSlots.instance.units[1].Prefab.GetComponent<UnitController>().stats.SpawnDelay);
                    if (TeamSlots.instance.units[1].Prefab.GetComponent<UnitController>().stats.Copies > 1)
                    {

                        GameObject unitGroup = new("UnitGroup");
                        unitGroup.AddComponent<SwarmParentController>();
                        unitGroup.tag = "Ally";

                        for (int j = 0; j < TeamSlots.instance.units[1].Prefab.GetComponent<UnitController>().stats.Copies; j++)
                        {
                            yield return new WaitForSeconds(.1f);
                            GameObject newUnit = Instantiate(TeamSlots.instance.units[1].Prefab, stats.SpawnPoint.position, Quaternion.identity);
                            newUnit.transform.SetParent(unitGroup.transform);


                            UnitController unitController = newUnit.GetComponent<UnitController>();

                            if (unitController != null)
                            {
                                unitController.SetTargetBase(false);
                            }
                            else break;
                        }
                        unitList.Add(unitGroup);
                    }
                    else
                    {
                        yield return new WaitForSeconds(TeamSlots.instance.units[1].Prefab.GetComponent<UnitController>().stats.SpawnDelay);
                        GameObject newUnit = Instantiate(TeamSlots.instance.units[1].Prefab, stats.SpawnPoint.position, Quaternion.identity);
                        unitList.Add(newUnit);
                        UnitController unitController = newUnit.GetComponent<UnitController>();

                        if (unitController != null)
                        {
                            unitController.SetTargetBase(false);
                        }
                        else break;
                    }


                }
                else break;
                break;
            case 2:
                resourceCost = TeamSlots.instance.units[2].Cost;
                if (stats.Resource >= resourceCost)
                {
                    stats.Resource -= resourceCost;
                    yield return new WaitForSeconds(TeamSlots.instance.units[2].Prefab.GetComponent<UnitController>().stats.SpawnDelay);
                    if (TeamSlots.instance.units[2].Prefab.GetComponent<UnitController>().stats.Copies > 1)
                    {
                        GameObject unitGroup = new("UnitGroup");
                        unitGroup.AddComponent<SwarmParentController>();
                        unitGroup.tag = "Ally";

                        for (int j = 0; j < TeamSlots.instance.units[2].Prefab.GetComponent<UnitController>().stats.Copies; j++)
                        {
                            yield return new WaitForSeconds(.1f);
                            GameObject newUnit = Instantiate(TeamSlots.instance.units[2].Prefab, stats.SpawnPoint.position, Quaternion.identity);

                            newUnit.transform.SetParent(unitGroup.transform);


                            UnitController unitController = newUnit.GetComponent<UnitController>();

                            if (unitController != null)
                            {
                                unitController.SetTargetBase(false);
                            }
                            else break;
                        }
                        unitList.Add(unitGroup);
                    }
                    else
                    {
                        yield return new WaitForSeconds(TeamSlots.instance.units[2].Prefab.GetComponent<UnitController>().stats.SpawnDelay);
                        GameObject newUnit = Instantiate(TeamSlots.instance.units[2].Prefab, stats.SpawnPoint.position, Quaternion.identity);
                        unitList.Add(newUnit);
                        UnitController unitController = newUnit.GetComponent<UnitController>();

                        if (unitController != null)
                        {
                            unitController.SetTargetBase(false);
                        }
                        else break;
                    }


                }
                else break;
                break;
            case 3:
                resourceCost = TeamSlots.instance.units[3].Cost;
                if (stats.Resource >= resourceCost)
                {
                    stats.Resource -= resourceCost;
                    yield return new WaitForSeconds(TeamSlots.instance.units[3].Prefab.GetComponent<UnitController>().stats.SpawnDelay);
                    if (TeamSlots.instance.units[3].Prefab.GetComponent<UnitController>().stats.Copies > 1)
                    {
                        GameObject unitGroup = new("UnitGroup");
                        unitGroup.AddComponent<SwarmParentController>();
                        unitGroup.tag = "Ally";

                        for (int j = 0; j < TeamSlots.instance.units[3].Prefab.GetComponent<UnitController>().stats.Copies; j++)
                        {
                            yield return new WaitForSeconds(.1f);
                            GameObject newUnit = Instantiate(TeamSlots.instance.units[3].Prefab, stats.SpawnPoint.position, Quaternion.identity);
                            newUnit.transform.SetParent(unitGroup.transform);


                            UnitController unitController = newUnit.GetComponent<UnitController>();

                            if (unitController != null)
                            {
                                unitController.SetTargetBase(false);
                            }
                            else break;
                        }
                        unitList.Add(unitGroup);
                    }
                    else
                    {
                        yield return new WaitForSeconds(TeamSlots.instance.units[3].Prefab.GetComponent<UnitController>().stats.SpawnDelay);
                        GameObject newUnit = Instantiate(TeamSlots.instance.units[3].Prefab, stats.SpawnPoint.position, Quaternion.identity);
                        unitList.Add(newUnit);
                        UnitController unitController = newUnit.GetComponent<UnitController>();

                        if (unitController != null)
                        {
                            unitController.SetTargetBase(false);
                        }
                        else break;
                    }


                }
                else break;
                break;
        }
    }
    public void Button1()
    {
        StartCoroutine(SpawnUnit(0));
    }
    public void Button2()
    {
        StartCoroutine(SpawnUnit(1));
    }
    public void Button3()
    {
        StartCoroutine(SpawnUnit(2));
    }
    public void Button4()
    {
        StartCoroutine(SpawnUnit(3));
    }

    private void Update()
    {
        resourceText.text = stats.Resource.ToString();
    }
    private void Start()
    {
        InvokeRepeating(nameof(PayTime), 0.5f, 0.5f);
    }
    public void PayTime()
    {
        stats.Resource += stats.Payment;
    }
    public void RemoveUnit(GameObject unit)
    {
        unitList.Remove(unit);
    }
}
