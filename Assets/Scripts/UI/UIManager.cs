using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    public static UIManager Instance
    {
        get { return instance; }
        set { instance = value; }
    }
    private void Awake()
    {
        if (instance != this) instance = this;
    }
    public void StartGame()
    {
        if (TeamSlots.instance.units.Count == 4) SceneController.LoadLevel(GameConstants.GAME_SCENE);
        else Debug.LogWarning("Your team is incomplete!");

    }
    public void LogOut()
    {
        SceneController.LoadLevel(GameConstants.LOGIN_SCENE);
        TeamSlots.instance.units.Clear();
    }

}
