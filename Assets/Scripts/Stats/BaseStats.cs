using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class BaseStats
{
	[SerializeField]
	private float currentHealth;
    [SerializeField]
    private float maxHelath;
    [SerializeField]
    private float range;
    [SerializeField]
    private float baseDamage;
    [SerializeField]
    private float attackDelay;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private Image healthBar;
	[SerializeField]
	private float attackSpeed;
	[SerializeField]
	
	private Targeting targeting;
    [SerializeField]
    private UnitType unitType;
    [SerializeField]
    private int copies;
    [SerializeField]
    private float spawnDelay;


    public float SpawnDelay
    {
        get { return spawnDelay; }
        set { spawnDelay = value; }
    }

    public int Copies
    {
        get { return copies; }
        set
        {
            if (unitType == UnitType.Swarm)
            {
                copies = value;
            }
            else copies = 1;
        }
    }




    public UnitType UnitType
    {
        get { return unitType; }
        set { unitType = value; }
    }

    public Targeting Targeting
	{
		get { return targeting; }
		set { targeting = value; }
	}







	public float AttackSpeed
	{
		get { return attackSpeed; }
		set { attackSpeed = value; }
	}


	public Image HealthBar
	{
		get { return healthBar; }
	}
	public float MoveSpeed
	{
		get { return moveSpeed; }
		set { moveSpeed = value; }
	}
	public float AttackDelay
	{
		get { return attackDelay; }
	}
	public float BaseDamage
	{
		get { return baseDamage; }
	}
	public float Range
	{
		get { return range; }
	}
	public float MaxHealth
	{
		get { return maxHelath; }
	}
	public float PercentHealth
	{
		get { return currentHealth / maxHelath; }
	}
	public float CurrentHealth
	{
		get { return currentHealth; }
		set 
		{
			if (value <= 0)
				currentHealth = 0;
			else if(value >= maxHelath)
			{
				currentHealth = maxHelath;
			}
			else currentHealth = value;
		}
	}

}
public enum UnitType { Swarm, Troop, Ranged, Titan }
public enum Targeting { Units, Base, Both }