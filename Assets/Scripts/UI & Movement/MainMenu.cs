/*Christian Cerezo */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject _optionsScreen;
    [SerializeField] private GameObject _difficultyScreen;
    [SerializeField] private GameObject _mainMenuScreen;

    public void OpenOptions()
    {
        _mainMenuScreen.SetActive(false);
        _optionsScreen.SetActive(true);
    }

    public void QuitGame()
    {
        //Won't do anything in editor
        Application.Quit();
        Debug.Log("Quitting");
    }

    public void OpenDifficulty()
    {
        _mainMenuScreen.SetActive(false);
        _difficultyScreen.SetActive(true);
    }


}
