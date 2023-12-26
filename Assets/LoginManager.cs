using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoginManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> menus = new List<GameObject>();

    [SerializeField]
    private TMP_InputField loginUsername;
    [SerializeField]
    private TMP_InputField loginPassword;
    [SerializeField]
    private TMP_InputField registerUsername;
    [SerializeField]
    private TMP_InputField registerEmail;
    [SerializeField]
    private TMP_InputField registerPassword;
    [SerializeField]
    private TMP_InputField registerConfirmPassword;

    public void Login()
    {
        AccountInfo.Login(loginUsername.text, loginPassword.text);
    }
    public void Register()
    {
        if (registerConfirmPassword.text == registerPassword.text) AccountInfo.Register(registerUsername.text, registerEmail.text, registerPassword.text);
        else Debug.LogError("Passwords do not match!");

    }
    public void ChangeMenu(int i)
    {
        GameFunctions.ChangeMenu(menus.ToArray(), i);
    }

}
