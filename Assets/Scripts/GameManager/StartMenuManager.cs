using Assets.Scripts.Addons;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuManager : MonoBehaviour
{
    const string IniFilePath = "Assets/Settings/Params.ini";
    IniFile Ini;

    public InputField NicknameInput;

    void Start()
    {
        Ini = new IniFile(IniFilePath);
        SetNickname();
    }

    private void SetNickname()
    {
        const string DefaultNickname = "Player";
        NicknameInput.text = String.IsNullOrEmpty(Ini.Read("Nickname")) ? DefaultNickname : Ini.Read("Nickname");
    }

    public void ConfirmNickName()
    {
        const string DefaultNickname = "Player";
        Ini.Write( "Nickname", 
            String.IsNullOrEmpty(NicknameInput.text) ? DefaultNickname : NicknameInput.text);

        SetNickname();
    }

    public void OnSingleplayerButtonPress()
    {
        SceneManager.LoadScene(1);
    }

    public void OnMultiplayerButtonPress()
    {
        SceneManager.LoadScene(2);
    }

    public void OnQuitButtonPress()
    {
        Application.Quit();
    }

}
