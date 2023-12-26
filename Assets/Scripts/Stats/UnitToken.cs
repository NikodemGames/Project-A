using System;
using UnityEngine;
[System.Serializable]
public class UnitToken
{
	[SerializeField]
	private int index;

	public int Index
	{
		get { return index; }
		set { index = value; }
	}

	[SerializeField]
	private Sprite sprite;
	[SerializeField]
	private GameObject prefab;
	[SerializeField]
	private string name;
	[SerializeField]
	private float cost;

	public float Cost
	{
		get { return cost; }
		set { cost = value; }
	}
	public string Name
	{
		get { return name; }
		set { name = value; }
	}
	public GameObject Prefab
	{
		get { return prefab; }
		set { prefab = value; }
	}
	public Sprite Sprite
	{
		get { return sprite; }
		set { sprite = value; }
	}

}
