using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamSlotsUI : MonoBehaviour
{
    public Transform slotParent;
    TeamSlots teamSlots;
    InvSlot[] slots;
    void Start()
    {   
        teamSlots = TeamSlots.instance;
        teamSlots.onTeamSlotChangedCallback += UpdateUI;
        slots = slotParent.GetComponentsInChildren<InvSlot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateUI()
    {
        Debug.Log("Updating UI");
        for (int i = 0; i < slots.Length; i++)
        {
            if(i< teamSlots.units.Count)
            {
                slots[i].AddUnit(teamSlots.units[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
