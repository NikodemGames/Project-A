using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
	private static SceneController instance;
	[SerializeField]
	private Image loadingBar;
	[SerializeField]
	private static int index;

	public static int Index
	{
		get { return index; }
		set { index = value; }
	}


	public Image LoadingBar
	{
		get { return loadingBar; }
		set { loadingBar = value; }
	}

	public static SceneController Instance
	{
		get { return instance; }
	}

	AsyncOperation async = null;
	private void Awake()
	{
		if(instance != this)
		{
			instance = this;
		}
	}
	private void Start()
	{
		loadingBar.fillAmount = 0;
		StartCoroutine(LoadingLevel(index));
	}
	private void Update()
	{
		if(async != null)
		{
			loadingBar.fillAmount = async.progress;
		}
	}
	IEnumerator LoadingLevel(int i)
	{
		async = SceneManager.LoadSceneAsync(i);
		yield return null;
	}
	public static void LoadLevel(int i)
	{
		index = i;
		SceneManager.LoadScene(GameConstants.LOADING_SCENE);
	}

}
