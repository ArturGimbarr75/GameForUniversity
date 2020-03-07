using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SingleplayerManager : MonoBehaviour
{
    public bool Pause = false;
    public Button BackToMenuButton;

    void Start()
    {
        Cursor.visible = false;
        BackToMenuButton.gameObject.SetActive(Pause);
    }

    // Update is called once per frame
    void Update()
    {
        CheckLeftGame();
    }

    void CheckLeftGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause = !Pause;
            Cursor.visible = Pause;
            BackToMenuButton.gameObject.SetActive(Pause);
        }
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
