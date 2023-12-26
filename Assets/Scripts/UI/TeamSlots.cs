using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamSlots : MonoBehaviour
{

    #region Singleton
    public static TeamSlots instance;
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of team slots found!");
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    #endregion
    public delegate void OnTeamSlotChanged();
    public OnTeamSlotChanged onTeamSlotChangedCallback;
    public int space =4;
    public List<UnitToken> units = new();
    

    public void Add(UnitToken unit)
    {
        if(units.Count >= space)
        {
            Debug.Log("Full!");
            return;
        }
        units.Add(unit);
        if (onTeamSlotChangedCallback != null)
        {
            onTeamSlotChangedCallback.Invoke();
        }
    }
    public void Remove(UnitToken unit)
    {
        units.Remove(unit);
        if (onTeamSlotChangedCallback != null)
        {
            onTeamSlotChangedCallback.Invoke();
        }
    }
}
