using UnityEngine;
using System.Collections;

public class BleedStatusEffect : StatusEffect
{
    public int DamagePerTick { get; private set; }
    public float TickInterval { get; private set; }

    public BleedStatusEffect(int damagePerTick, float tickInterval, float duration)
    {
        Name = "Bleed";
        //Icon = // Set the icon sprite for bleed status
        DamagePerTick = damagePerTick;
        TickInterval = tickInterval;
        Duration = duration;
    }

    public override void ApplyEffect(UnitController unit)
    {
        base.ApplyEffect(unit);
        unit.StartCoroutine(InflictBleed(unit));
    }

    public override void RemoveEffect(UnitController unit)
    {
        base.RemoveEffect(unit);
        unit.StopCoroutine(InflictBleed(unit));
    }

    private IEnumerator InflictBleed(UnitController unit)
    {
        while (Duration > 0)
        {
            unit.TakeDamage(DamagePerTick);
            yield return new WaitForSeconds(TickInterval);
            Duration -= TickInterval;
        }
        RemoveEffect(unit);
    }
}
