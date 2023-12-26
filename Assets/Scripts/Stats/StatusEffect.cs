using UnityEngine;

public class StatusEffect
{
    public string Name { get; protected set; }
    public float Duration { get; protected set; }
    public Sprite Icon { get; protected set; }

    public virtual void ApplyEffect(UnitController unit)
    {
        // Apply the effect to the unit
    }

    public virtual void RemoveEffect(UnitController unit)
    {
        // Remove the effect from the unit
    }
}