
using UnityEngine;
[System.Serializable]
public class BuildingStats
{
	[SerializeField]
	private float resource;
    [SerializeField]
    private float technology;
    [SerializeField]
    private float payment;
    [SerializeField]
    private Transform spawnPoint;
	[SerializeField]



	public Transform SpawnPoint
	{
		get { return spawnPoint; }
		set { spawnPoint = value; }
	}


	public float Payment
	{
		get { return payment; }
		set { payment = value; }
	}


	public float Technology
	{
		get { return technology; }
		set { technology = value; }
	}

	public float Resource
	{
		get { return resource; }
		set { resource = value; }
	}


}
