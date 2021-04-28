using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonClick : MonoBehaviour
{
    public GameObject Title;
    public GameObject StartButton;
    public GameObject Intro;
    public GameObject ContinueButton;

    public void OnButtonClick()
    {
        Intro.SetActive(true);
        ContinueButton.SetActive(true);

        Title.SetActive(false);
        StartButton.SetActive(false);
    }

    public void OnContinueClick()
    {
        SceneManager.LoadScene("LevelOne");
    }
}
