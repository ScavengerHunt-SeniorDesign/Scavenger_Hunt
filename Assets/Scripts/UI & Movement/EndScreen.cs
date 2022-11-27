/*Christian Cerezo*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private string _mainLevel;
    [SerializeField] private string _mainMenu;
    [SerializeField] private TextMeshProUGUI elapsedTime;
    [SerializeField] private GameObject _difficultyScreen;
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private GameObject _playScreen;
    private SaveObject SaveData;

   

    public void OpenEndScreen()
    {
        _endScreen.SetActive(true);
        SaveData = SaveManager.Load();
        string seconds = SaveData.TimeElapsed.ToString("0.00");
        elapsedTime.text = "Total Time Elapsed: " + seconds + "s";
        _playScreen.SetActive(false);
    }


    public void QuitToMain()
    {
        SceneManager.LoadScene(_mainMenu);
    }

    public void PlayAgain()
    {
        _difficultyScreen.SetActive(true);
        _endScreen.SetActive(false);
    }

    public void SetDifficulty(int x)
    {
        // 0, 1, 2 correspond to easy, medium, hard respectively
        SaveData.GameDifficulty = x;
        SaveManager.Save(SaveData);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(_mainLevel);
    }
}
