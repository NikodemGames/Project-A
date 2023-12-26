using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitHolder : MonoBehaviour
{
    public UnitToken unitToken = null;
    Button button;
    private void Start()
    {
        button = GetComponent<Button>();
    }

    public void Recruit()
    {
        TeamSlots.instance.Add(unitToken);

    }
    private void Update()
    {

        if (TeamSlots.instance.units.Contains(unitToken))
        {

            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }
}
