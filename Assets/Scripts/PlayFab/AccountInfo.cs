using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class AccountInfo : MonoBehaviour
{
	private static AccountInfo instance;
	[SerializeField]
	private GetPlayerCombinedInfoResultPayload info;

	public GetPlayerCombinedInfoResultPayload Info
	{
		get { return info; }
		set { info = value; }
	}

	public static AccountInfo Instance
	{
		get { return instance; }
		set { instance = value; }
	}
	private void Awake()
	{
		if(instance != this) instance = this;
		DontDestroyOnLoad(gameObject);
	}

	public static void Register(string username, string email, string password)
	{
		RegisterPlayFabUserRequest request = new RegisterPlayFabUserRequest()
		{
			TitleId=PlayFabSettings.TitleId,
			Email=email,
			Username=username,
			Password=password
		};
		PlayFabClientAPI.RegisterPlayFabUser(request, OnRegister,GameFunctions.OnAPIError);
	}
    public static void Login(string username, string password)
    {
        LoginWithPlayFabRequest request = new LoginWithPlayFabRequest()
        {
            TitleId = PlayFabSettings.TitleId,
            Username = username,
            Password = password
        };
        PlayFabClientAPI.LoginWithPlayFab(request, OnLogin, GameFunctions.OnAPIError);
    }
	public static void GetAccountInfo(string playfabId)
	{
		GetPlayerCombinedInfoRequestParams paramInfo = new GetPlayerCombinedInfoRequestParams()
		{
			GetTitleData = true,
			GetUserInventory = true,
			GetUserAccountInfo = true,
			GetUserVirtualCurrency = true,
			GetPlayerProfile = true,
			GetPlayerStatistics = true,
			GetUserData = true,
			GetUserReadOnlyData = true
		};
		GetPlayerCombinedInfoRequest request = new GetPlayerCombinedInfoRequest()
		{
			PlayFabId = playfabId,
			InfoRequestParameters = paramInfo
		};

		PlayFabClientAPI.GetPlayerCombinedInfo(request, OnGotAccountInfo,GameFunctions.OnAPIError);
	}
    static void OnRegister(RegisterPlayFabUserResult result)
	{
		Debug.Log("Registered with: " + result.PlayFabId);
	}
   
    static void OnLogin(LoginResult result)
    {
        Debug.Log("Login with: " + result.PlayFabId);
		GetAccountInfo(result.PlayFabId);
		Database.UpdateDatabase();
		SceneController.LoadLevel(GameConstants.MAIN_SCENE);
    }
	static void OnGotAccountInfo(GetPlayerCombinedInfoResult result)
	{
		Debug.Log("Updated Account Info!");
		instance.Info = result.InfoResultPayload;
	}

}
