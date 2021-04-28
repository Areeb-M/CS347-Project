using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSceneButtonManager : MonoBehaviour
{
    public void OnReplayClick()
    {
        SceneManager.LoadScene("Start Menu");
    }

    public void OnQuitClick()
    {
        Application.Quit();
    }
}
