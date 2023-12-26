using UnityEngine;
using UnityEngine.UI;

public class InvSlot : MonoBehaviour
{
    public UnitToken unit;
    public Image icon;

    public void AddUnit(UnitToken newUnit)
    {
        unit = newUnit;
        icon.sprite = unit.Sprite;
        icon.enabled = true;
    }
    public void ClearSlot()
    {
        unit = null;
        icon.sprite = null;
        icon.enabled=false;
    }
    public void OnRemoveButton()
    {
        TeamSlots.instance.Remove(unit);
    }
}
