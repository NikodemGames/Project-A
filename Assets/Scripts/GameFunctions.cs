using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public static class GameFunctions
{
    public static void ChangeMenu(GameObject[] menus,int id)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            menus[i].SetActive(i ==id?true: false);
        }
    }
    public static void OnAPIError(PlayFabError error)
    {
        Debug.Log(error);
    }
    public static UnitToken CreateToken(CatalogItem item, int i)
    {
        UnitToken token = new UnitToken();
        token.Index = i;
        token.Name = item.DisplayName;
        token.Cost = float.Parse(GetCatalogCustomData(GameConstants.ITEM_COST, item));
        Sprite icon = Resources.Load(GetCatalogCustomData(GameConstants.ITEM_ICON, item), typeof(Sprite)) as Sprite;
        token.Sprite = icon;
        GameObject prefab = Resources.Load(GetCatalogCustomData(GameConstants.ITEM_PREFAB, item), typeof(GameObject)) as GameObject;
        token.Prefab = prefab;

        return token;
    }
    public static string GetCatalogCustomData(int i, CatalogItem item)
    {
        Debug.Log(item.CustomData);
        string cDataTemp = item.CustomData.Trim();
        cDataTemp = cDataTemp.TrimStart('{');
        cDataTemp = cDataTemp.TrimEnd('}');
        string[] newCData;
        newCData = cDataTemp.Split(',', ':');
        for (int s=0; s<newCData.Length; s++)
        {
            if(i == s)
            {
                newCData[s] = newCData[s].Trim();
                newCData[s] = newCData[s].TrimStart('"');
                newCData[s] = newCData[s].TrimEnd('"');
                newCData[s] = newCData[s].Trim();
                return newCData[s];
            }
        }
        Debug.Log(string.Format("GetCatalogCustomData - could not find ID: {0} in {1}",i, item.DisplayName));
        return "ERROR";
    }
}
