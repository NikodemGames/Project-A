using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class Database : MonoBehaviour
{
	private static Database instance;
	[SerializeField]
	private List<UnitToken> tokens;
	[SerializeField]
	private List<CatalogItem> catalogTokens;

	public List<CatalogItem> CatalogTokens
	{
		get { return catalogTokens; }
		set { catalogTokens = value; }
	}

	public List<UnitToken> Tokens
	{
		get { return tokens; }
		set { tokens = value; }
	}

	public static Database Instance
	{
		get { return instance; }
		set { instance = value; }
	}
	public void Awake()
	{
		if(instance != this) instance = this;
		DontDestroyOnLoad(gameObject);
	}
	public static void UpdateDatabase()
	{
		GetCatalogItemsRequest request = new GetCatalogItemsRequest()
		{
			CatalogVersion = GameConstants.CATALOG_ITEMS,

		};
        PlayFabClientAPI.GetCatalogItems(request,OnUpdateDatabase, GameFunctions.OnAPIError);
    }
	static void OnUpdateDatabase(GetCatalogItemsResult result)
	{
		for (int i = 0; i< result.Catalog.Count; i++)
		{
			if (result.Catalog[i].ItemClass == GameConstants.ITEM_TOKENS)
			{
				Instance.CatalogTokens.Add(result.Catalog[i]);
				Instance.Tokens.Add(GameFunctions.CreateToken(result.Catalog[i], i));
			}
        }
	}
}
